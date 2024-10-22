public class DayLog
{
	public DayLog(DateTime logDate, LogType logType, string instrumentNumber)
	{
		LogType = logType;
		LogDate = logDate;
		InstrumentNumber = instrumentNumber;
	}

	public List<string> log = new List<string>();

	public readonly DateTime LogDate;
	public readonly LogType LogType;
	public readonly string InstrumentNumber;
}