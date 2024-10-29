using System.Data;

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
		_view.SaveReport += SaveReport;
		_view.Show();
	}

	private void SaveReport(string instrumentNumber, DateTime start, DateTime end, string filePath, string areaName)
	{
		var dtReport = ConnvertToDataTable();
		var headerData = new string[] {instrumentNumber.ToString(), areaName, start.ToString("dd.MM.yyyy"), end.ToString("dd.MM.yyyy") };

		_model.SaveReport(headerData, dtReport, filePath);
	}
	//TODO: Павел. Методу ниже по идее не место в этом классе. Стоит ли в таких случаях делать отдельный класс, под один метод?
	private DataTable ConnvertToDataTable()
	{
		var result = new DataTable();

		var properties = _report[0].GetType().GetProperties();

		foreach(var property in properties)
		{
			result.Columns.Add(property.Name, typeof(string));
		}

		foreach(var line in _report)
		{
			var row = result.NewRow();

			row[0] = line.NumberOfWorkShift;
			row[1] = line.SampleCount;
			row[2] = line.AnalysisOkCount;
			row[3] = line.PreparetionCount;
			row[4] = line.ErrorCount;
			row[5] = line.SummTestModeTime.ToString("hh\\:mm\\:ss");
			row[6] = line.AverageAnalysisTime.ToString("mm\\:ss"); 
			row[7] = line.AverageOneSideRuns;
			row[8] = line.AverageBadSurfaceRate;
			row[9] = line.AverageSamplePreparation;
			row[10] = line.PercentBadSample;

			result.Rows.Add(row);
		}

		return result;
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

		_report = ConvertToStatisticReport(dayLogStatistic, calculatedStatistic);

		return _report;
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
	List<StatisticReport> _report;
}