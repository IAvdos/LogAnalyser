public class LogAnalisisManager
{
	List<ReadLogFileStatus> _readFilesStatus;
	List<DayLogStatistic> _dayLogStatistic;

	public List<DayLogStatistic> GetDayLogStatistics(IEnumerable<string> paths, out List<ReadLogFileStatus> readLogFileStatuses)
	{
		var dayLogs = ReadLogs(paths);
		ParsDayLogs(dayLogs);

		readLogFileStatuses = _readFilesStatus;
		return _dayLogStatistic;
	}

	IEnumerable<DayLog> ReadLogs(IEnumerable<string> paths)
	{
		var logReader = new LogReader();

		var dayLogs = logReader.ReadLog(paths, out var fileStatuses);

		_readFilesStatus = fileStatuses;
		return dayLogs;
	}

	void ParsDayLogs(IEnumerable<DayLog> dayLogs)
	{
		var logProcessor = new SimpleEventLogProcessor();
		_dayLogStatistic = new List<DayLogStatistic>();

		foreach (var dayLog in dayLogs)
		{
			DayLogStatistic[] temp = logProcessor.GetStatistic(dayLog);

			foreach (DayLogStatistic statistic in temp)
			{
				_dayLogStatistic.Add(statistic);
			}
		}
	}
}