using System.Text.RegularExpressions;

public class LogReader
{
	IEnumerable<string> _paths;
	List<ReadLogFileStatus> _filesStatus;

	public IEnumerable<DayLog> ReadLog(IEnumerable<string> paths, out List<ReadLogFileStatus> status)
	{
		_paths = paths;
		_filesStatus = new();

		var dayLogs = new List<DayLog>();

		foreach(var path in _paths)
		{
			if (!File.Exists(path))
			{
				_filesStatus.Add(new ReadLogFileStatus { FileName = path, Status = "Not exist" });

				continue;
			}

			var dayLog = ReadLogFile(path);

			if (dayLog != null)
			{
				_filesStatus.Add(new ReadLogFileStatus { FileName = path, Status = "Succsesful read" });
				dayLogs.Add(dayLog);
			}
		}

		status = _filesStatus;
		return dayLogs;
	}

	private DayLog? ReadLogFile(string path)
	{
		var logLines = new List<string>();
		var titleLines = new List<string>();

		using(var stream = new StreamReader(path, System.Text.Encoding.UTF8))
		{
			var line = stream.ReadLine();

			if (line == null)
			{
				_filesStatus.Add(new ReadLogFileStatus { FileName = path, Status = "File empty" });
				return null;
			}

			for(int i = 0; i < 2; i++)
			{
					titleLines.Add(line);

					line = stream.ReadLine();
			}

			while(line != null)
			{
				logLines.Add(line);

				line = stream.ReadLine();
			}
		}

		var logTitle = GetTitleInfo(titleLines);

		var dayLog = new DayLog(logTitle.Item1, logTitle.Item2, logTitle.Item3);
		logLines.RemoveRange(0,1);
		dayLog.log = logLines;

		if (logTitle.Item2 == LogType.IncorrectLog)
		{
			_filesStatus.Add(new ReadLogFileStatus { FileName = path, Status = "Incorect data" });
			return null ;
		}

		return dayLog;
	}

	private (DateTime, LogType, string) GetTitleInfo(List<string> title)
	{
		string datePattern = @"^\d{1,2}-\d{1,2}-\d{4}";
		string instrumentNumberPattetn = @"[(]\d{4}[-]\d{3,4}[)]";
		
		LogType logType = LogType.IncorrectLog;
		
		if (Regex.IsMatch(title[0], "Event1Log"))
			logType = LogType.EventLog;
		else if (Regex.IsMatch(title[0], "Error1Log"))
			logType = LogType.ErrorLog;
		else
		{
			return (DateTime.Now.Date, logType, String.Empty);
		}

		DateTime date = DateTime.Parse(Regex.Match(title[0], datePattern).Value).Date;

		string instrumentNumber = Regex.Match(title[1], instrumentNumberPattetn).Value.Trim('(', ')');

		return (date, logType, instrumentNumber);
	}
}