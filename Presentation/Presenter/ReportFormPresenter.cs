public class ReportFormPresenter : IPresenter
{
	public ReportFormPresenter(IReportView view, ReportModel model)
	{
		_model = model;
		_view = view;
	}
	public void Run()
	{
		_view.GetStatisticDatesForInstrument += GetStatisticDatesForInstrument;
		_view.GetStatisticReport += GetStatisticReport;
		_view.Show();
	}

	private List<StatisticReport> GetStatisticReport(DateTime startPeriod, DateTime endPeriod, int[] workShifts, string instrumentNumber)
	{
		List<CalculatedStatistic> calculatedStatistic = null;
		List<DayLogStatistic> dayLogStatistic = null;

		if(workShifts.Count() == 0)
		{
			dayLogStatistic = _model.GetUnionStatisticForPeriod(startPeriod, endPeriod, instrumentNumber,	out calculatedStatistic);
		}
		if(workShifts.Count() != 0)
		{
			dayLogStatistic = _model.GetUnionWorkShiftStatisticForPeriod
				(startPeriod, endPeriod, workShifts, instrumentNumber, out calculatedStatistic);
		}

		return ConvertToStatisticReport(dayLogStatistic, calculatedStatistic);
	}

	private List<StatisticReport> ConvertToStatisticReport(List<DayLogStatistic> dayLogStatistic, List<CalculatedStatistic> calculatedStatistic)
	{
		List<StatisticReport> report = new List<StatisticReport>();

		for(int i = 0; i < dayLogStatistic.Count; i++)
		{
			report.Add(new StatisticReport
			{
				SampleCount = dayLogStatistic[i].SampleCount,
				NumberOfWorkShift = dayLogStatistic[i].NumberOfWorkShift,
				AnalysisOkCount = dayLogStatistic[i].AnalysisOkCount,
				PreparetionCount = dayLogStatistic[i].PreparetionCount,
				ErrorCount = dayLogStatistic[i].ErrorCount,
				SummTestModeTime = dayLogStatistic[i].SummTestModeTime,
				AverageSamplePreparation = calculatedStatistic[i].AverageSamplePreparation,
				AverageBadSurfaceRate = calculatedStatistic[i].AverageBadSurfaceRate,
				AverageOneSideRuns = calculatedStatistic[i].AverageOneSideRuns,
				PercentBadSample = calculatedStatistic[i].PercentBadSample,
				AverageAnalysisTime = calculatedStatistic[i].AverageAnalysisTime,
			});
		}

		return report;
	}

	private DateTime[] GetStatisticDatesForInstrument(string instrumentNumber)
	{
		return _model.GetStatisticsDates(instrumentNumber);
	}

	IReportView _view;
	ReportModel _model;
}