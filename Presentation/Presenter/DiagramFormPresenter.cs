public class DiagramFormPresenter : IPresenter
{
	readonly DiagramModel _model;
	readonly IDiagramView _diagramView;

	DateTime _startPeriodDate;
	DateTime _endPeriodDate;
	bool _isDayStatistic = true;
	private List<CalculatedStatistic> _statistic = null;

	public DiagramFormPresenter(DiagramModel model, IDiagramView view)
	{
		_diagramView = view;
		_model = model;
	}

	public void Run()
	{
		_diagramView.Show();

		_diagramView.GetStatisticReport += GetStatisticDiagramPoints;
		_diagramView.GetStatisticDatesForInstrument += GetStatisticDatesForInstrument;
	}

	private DateTime[] GetStatisticDatesForInstrument(string instumentNumber)
	{
		return _model.GetStatisticsDates(instumentNumber);
	}

	private List<DiagramPoint> GetStatisticDiagramPoints(DateTime startPeriodDay, DateTime endPeriodDay, int workShiftNumber, 
		string statisticTarget, string instrumentNumber)
	{
		if(workShiftNumber == 0)
		{
			if (_startPeriodDate != startPeriodDay || _endPeriodDate != endPeriodDay || !_isDayStatistic)
			{
				_statistic = _model.GetDayStatisticForPeriod(startPeriodDay, endPeriodDay, instrumentNumber);
				_startPeriodDate = startPeriodDay;
				_endPeriodDate = endPeriodDay;
				_isDayStatistic = true;
			}
		}
		if(workShiftNumber != 0)
		{
			if (_startPeriodDate != startPeriodDay || _endPeriodDate != endPeriodDay || _isDayStatistic)
			{
				_statistic = _model.GetWorkShiftStatisticForPeriod(startPeriodDay, endPeriodDay, instrumentNumber);
				_startPeriodDate = startPeriodDay;
				_endPeriodDate = endPeriodDay;
				_isDayStatistic = false;
			}
		}

		var result = GetDiagramPoints(_statistic, workShiftNumber, statisticTarget);

		return result;
	}

	private List<DiagramPoint> GetDiagramPoints(List<CalculatedStatistic> statistic, int workShiftNumber, string statisticTarget)
	{
		if(statisticTarget == "Количество проб")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=>  new DiagramPoint(d.LogDate, d.SampleCount)).ToList();

		if(statisticTarget == "Количество \"заточек\"")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, d.PreparetionCount)).ToList();

		if (statisticTarget == "Количество ощибок")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, d.ErrorCount)).ToList();

		if (statisticTarget == "Время Test mode")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, Math.Round(d.SummTestModeTime.ToMinutes(), 2))).ToList();

		if (statisticTarget == "Среднее количество \"заточек\"")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, (double)d.AverageSamplePreparation)).ToList();

		if (statisticTarget == "Среднее время анализа")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate,  Math.Round(d.AverageAnalysisTime.ToMinutes(), 2))).ToList();

		if (statisticTarget == "Средний процент плохой пов. пробы")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, (double)d.AverageBadSurfaceRate)).ToList();

		if (statisticTarget == "Среднее количество прожигов на стороне")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, (double)d.AverageOneSideRuns)).ToList();

		if (statisticTarget == "Процент брака")
			return statistic.Where(s => s.NumberOfWorkShift == workShiftNumber).Select(d 
				=> new DiagramPoint(d.LogDate, (double)d.PercentBadSample)).ToList();

		return null;
	}
}

