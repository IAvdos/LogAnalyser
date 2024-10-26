public class StartFormModel
{
	LogAnalisisManager _logAnalisisManager = null;
	ExcelOperator _excelOperator;

    public StartFormModel(string dataFilePath)
    {
		_logAnalisisManager = new ();
		_excelOperator = new ExcelOperator(dataFilePath);
    }

    public IEnumerable<ReadLogFileStatus> OperateLogs(string[] filePahts)
	{
		List<ReadLogFileStatus> statusfiles;

		var logStatistic = _logAnalisisManager.GetDayLogStatistics(filePahts, out statusfiles);
		_excelOperator.SaveStatistic(logStatistic);

		return statusfiles;
	}
}