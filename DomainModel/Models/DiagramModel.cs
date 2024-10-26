public class DiagramModel
{
    private DiagramModel(){}
    public DiagramModel(string excelFilePaht)
    {
		_excelOperator = new ExcelOperator(excelFilePaht);
    }
    public void GetCountPerDayAllTime()
	{
		var data = _excelOperator.ReadData();
	}

	public List<CalculatedStatistic> GetDayStatisticForPeriod(DateTime start, DateTime end, string instrumentNumber)
	{
		var statisticForActualInstrument = GetStatisticForInstrument(instrumentNumber);

		var result = StatisticProcessor.GetDayStatisticForPreriod(statisticForActualInstrument, start, end);

		return result;
	}

	public List<CalculatedStatistic> GetWorkShiftStatisticForPeriod(DateTime start, DateTime end, string instrumentNumber)
	{
		var statisticForActualInstrument = GetStatisticForInstrument(instrumentNumber);

		var result = StatisticProcessor.GetWorkShiftStatisticForPreriod(statisticForActualInstrument, start, end);

		return result;
	}

	public DateTime[] GetStatisticsDates(string instrumentNumber)
	{
		var statisticForActualInstrument = GetStatisticForInstrument(instrumentNumber);

		return statisticForActualInstrument.Select(d => d.LogDate).Order().Distinct().ToArray();
	}

	List<DayLogStatistic> GetStatisticForInstrument(string intstrumentNumber)
	{
		//TODO: chek NULL
		var statisticForActualInstrument = _excelOperator.ReadData().Where(l => l.InstrumentNumber == intstrumentNumber).ToList();

		return statisticForActualInstrument;
	}

	/*
	public List<CalculatedStatistic> GetDayStatisticForPeriod(DateTime start, DateTime end)
	{
		var result = StatisticProcessor.GetDayStatisticForPreriod(_statisticForActualInstrument, start, end);

		return result;
	}

	public List<CalculatedStatistic> GetWorkShiftStatisticForPeriod(DateTime start, DateTime end)
	{
		var result = StatisticProcessor.GetWorkShiftStatisticForPreriod(_statisticForActualInstrument, start, end);

		return result;
	}

	List<DayLogStatistic> _statisticForActualInstrument;
	*/

	ExcelOperator _excelOperator;
}