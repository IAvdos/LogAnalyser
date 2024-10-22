public class StartFormModel
{
	LogAnalisisManager _logAnalisisManager = null;
	ExcelOperator _excelOperator;

	public IEnumerable<ReadLogFileStatus> OperateLogs(string[] filePahts)
	{
		_logAnalisisManager = new ();
		_excelOperator = new ExcelOperator();

		List<ReadLogFileStatus> statusfiles;

		var logStatistic = _logAnalisisManager.GetDayLogStatistics(filePahts, out statusfiles);
		_excelOperator.SaveStatistic(logStatistic);

		return statusfiles;
	}
}