using System.Data;
using Xceed.Document.NET;

public class ReportModel
{
    public ReportModel(string excelFilePath)
    {
        _excelOperator = new ExcelOperator(excelFilePath);
		_wordOperator = new WordOperator();
    }

    public List<DayLogStatistic> GetUnionStatisticForPeriod(DateTime startPeriod, DateTime endPeriod, string instrumentNumber
		,out List<CalculatedStatistic> calculatedStatistic)
	{
		var statisticForActualInstrument = GetStatisticForInstrument(instrumentNumber).
				Where(i => i.LogDate >= startPeriod && i.LogDate <= endPeriod);

		var unionStatistic = statisticForActualInstrument.GroupBy(s => s.InstrumentNumber).Select(g => new DayLogStatistic
		{
			LogDate = startPeriod,
			InstrumentNumber = g.Key,
			SampleCount = g.Sum(i => i.SampleCount),
			DayPart = 0,
			NumberOfWorkShift = 0,
			PreparetionCount = g.Sum(i => i.PreparetionCount),
			RunsCount = g.Sum(i => i.RunsCount),
			AnalysisOkCount = g.Sum(i => i.AnalysisOkCount),
			NotAllowedRunsCount = g.Sum(i => i.NotAllowedRunsCount),
			OutOfQualityAnalisisCount = g.Sum(i => i.OutOfQualityAnalisisCount),
			BadSurfaceSampleCount = g.Sum(i => i.BadSurfaceSampleCount),
			SummAnalysisTime = g.Sum(i => i.SummAnalysisTime),
			SummBadSurfaceRate = g.Sum(i => i.SummBadSurfaceRate),
			SummTestModeTime = g.Sum(i => i.SummTestModeTime),
			ErrorCount = g.Sum(i => i.ErrorCount),
			NotReproducibleAnalisisCount = g.Sum(i => i.NotReproducibleAnalisisCount)
		}).ToList();

		calculatedStatistic = StatisticProcessor.ConvertToCalculatedStatistic(unionStatistic).ToList();

		return unionStatistic;
	}

	public List<DayLogStatistic> GetUnionWorkShiftStatisticForPeriod(DateTime startPeriod, DateTime endPeriod, int[] workShifts, string instrumentNumber,
			out List<CalculatedStatistic> calculatedStatistics)
	{
		var statisticForActualInstrument = GetStatisticForInstrument(instrumentNumber).
				Where(i => i.LogDate >= startPeriod && i.LogDate <= endPeriod).Where(j => workShifts.Contains(j.NumberOfWorkShift - 1));

		var unionStatistic = statisticForActualInstrument.GroupBy(s => s.NumberOfWorkShift).Select(g => new DayLogStatistic
		{
			LogDate = startPeriod,
			InstrumentNumber = g.First().InstrumentNumber,
			SampleCount = g.Sum(i => i.SampleCount),
			DayPart = 0,
			NumberOfWorkShift = g.Key,
			PreparetionCount = g.Sum(i => i.PreparetionCount),
			RunsCount = g.Sum(i => i.RunsCount),
			AnalysisOkCount = g.Sum(i => i.AnalysisOkCount),
			NotAllowedRunsCount = g.Sum(i => i.NotAllowedRunsCount),
			OutOfQualityAnalisisCount = g.Sum(i => i.OutOfQualityAnalisisCount),
			BadSurfaceSampleCount = g.Sum(i => i.BadSurfaceSampleCount),
			SummAnalysisTime = g.Sum(i => i.SummAnalysisTime),
			SummBadSurfaceRate = g.Sum(i => i.SummBadSurfaceRate),
			SummTestModeTime = g.Sum(i => i.SummTestModeTime),
			ErrorCount = g.Sum(i => i.ErrorCount),
			NotReproducibleAnalisisCount = g.Sum(i => i.NotReproducibleAnalisisCount)
		}).OrderBy(u => u.NumberOfWorkShift).ToList();

		calculatedStatistics = StatisticProcessor.ConvertToCalculatedStatistic(unionStatistic).OrderBy(u => u.NumberOfWorkShift).ToList();

		return unionStatistic;
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
	//TODO: write
	public void SaveReport(string[] headerData, int[] workShifts, DataTable dtReport, string filePath)
	{
		var reportBody = ReportBuilder.BuildReportBody(headerData);
		var reportTable = ReportBuilder.BuildTableReport(workShifts, dtReport);

		_wordOperator.SaveFile(reportBody, reportTable, filePath);
	}

	ExcelOperator _excelOperator;
	WordOperator _wordOperator;
}