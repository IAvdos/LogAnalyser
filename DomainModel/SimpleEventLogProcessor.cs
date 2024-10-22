using System.Diagnostics;
using System.Text.RegularExpressions;

public class SimpleEventLogProcessor : ILogProcessor
{
	DayLogStatistic[] _dayLogStatistics = null;
	List<string> _logs = null;

	public DayLogStatistic[] GetStatistic(DayLog dayLog)
	{
		_dayLogStatistics = new DayLogStatistic[3]
		{
			new DayLogStatistic(dayLog.LogDate, dayLog.InstrumentNumber)
			{
				DayPart = 1
			},
			new DayLogStatistic(dayLog.LogDate, dayLog.InstrumentNumber)
			{
				DayPart = 2
			},
			new DayLogStatistic(dayLog.LogDate, dayLog.InstrumentNumber)
			{
				DayPart = 3
			}
		};

		_logs = dayLog.log;

		DefineWorkShift(dayLog.LogDate);
		ParseLogs();

		return _dayLogStatistics;
	}

	void DefineWorkShift(DateTime logDate)
	{
		DateTime relativlyDate = new DateTime(2024, 10, 03);

		int[,] fourDaysWorkShifts = new int[4, 3]
		{
			{2, 1, 4},
			{4, 3, 1},
			{1, 2, 3},
			{3, 4, 2},
		};

		var days = (logDate - relativlyDate).Days;
		int dayOfCycle = 0;

		if (days < 0)
		{
			if (days % 4 != 0) 
				dayOfCycle = 4 - Math.Abs(days % 4);
		}
		else
		{
			dayOfCycle = Math.Abs(days % 4);
		}

		for (int i = 0; i < _dayLogStatistics.Length; i++)
		{
			_dayLogStatistics[i].NumberOfWorkShift = fourDaysWorkShifts[dayOfCycle, i];
		}
	}

	void ParseLogs()
	{
		int actualPart = 0;
		bool userAction = false;
		TimeOnly startErrorTime = new();

		foreach (string line in _logs)
		{
			TimeOnly messageTime = TimeOnly.Parse(Regex.Match(line, @"\d{2}:\d{2}:\d{2}").Value);

			if (messageTime < new TimeOnly(7, 30) && messageTime > new TimeOnly(0, 0)) actualPart = 0;
			else if (messageTime < new TimeOnly(19, 30) && messageTime > new TimeOnly(7, 30)) actualPart = 1;
			else actualPart = 2;

			if (Regex.IsMatch(line, "Change to Test Mode"))
			{
				userAction = true;
				continue;
			}

			if (Regex.IsMatch(line, "Start of procedure to abort the Automatic mode"))
			{
				if (userAction == false) _dayLogStatistics[actualPart].ErrorCount += 1;

				startErrorTime = messageTime;
				continue;
			}

			if (Regex.IsMatch(line, "Start Automatic Mode"))
			{
				_dayLogStatistics[actualPart].SummTestModeTime = _dayLogStatistics[actualPart].SummTestModeTime.Add(messageTime.Subtract(startErrorTime));
				userAction = false;
				continue;
			}

			if (Regex.IsMatch(line, "Start Worksheet execution"))
			{
				_dayLogStatistics[actualPart].SampleCount += 1;
				continue;
			}

			if (Regex.IsMatch(line, @"Run #"))
			{
				_dayLogStatistics[actualPart].RunsCount += 1;
				continue;
			}

			if (Regex.IsMatch(line, "Sample prepared"))
			{
				if(!userAction)
					_dayLogStatistics[actualPart].PreparetionCount += 1;

				continue;
			}

			if (Regex.IsMatch(line, "Bad Surface Rate"))
			{
				var value = Regex.Match(line, @"\d{1,2}[.]\d{1,2}\s[%]$").Value.Replace('.', ',').TrimEnd('%');
				_dayLogStatistics[actualPart].SummBadSurfaceRate += Decimal.Parse(value);
				continue;
			}

			if (Regex.IsMatch(line, "Allowed runs"))
			{

				var value = line.Substring(line.Length - 3, 3).Trim('(', ')');
				_dayLogStatistics[actualPart].NotAllowedRunsCount += 4 - Convert.ToInt32(value);
				continue;
			}

			if (Regex.IsMatch(line, "finished"))
			{
				var value = "00:" + Regex.Match(line, @"\d{2}[']\d{2}").Value.Replace('\'', ':');
				if (value == "00:") continue;

				_dayLogStatistics[actualPart].SummAnalysisTime = _dayLogStatistics[actualPart].SummAnalysisTime.Add(TimeOnly.Parse(value));
				continue;
			}

			if (Regex.IsMatch(line, "Sample out of Quality"))
			{
				_dayLogStatistics[actualPart].OutOfQualityAnalisisCount += 1;
				continue;
			}

			if (Regex.IsMatch(line, "Sample not reproducible"))
			{
				_dayLogStatistics[actualPart].NotReproducibleAnalisisCount += 1;
				continue;
			}

			if (Regex.IsMatch(line, "Bad sample K"))
			{
				_dayLogStatistics[actualPart].BadSurfaceSampleCount += 1;
				continue;
			}

			if (Regex.IsMatch(line, "Analysis ok"))
			{
				_dayLogStatistics[actualPart].AnalysisOkCount += 1;
				continue;
			}
			//sample was registered, but not introduced
			if (Regex.IsMatch(line, "deleted by system"))
			{
				_dayLogStatistics[actualPart].SampleCount -= 1;
				continue;
			}
		}
	}
}

