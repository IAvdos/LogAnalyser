public class WorkShiftStatistic
{
	public int Id { get; set; }
	public string InstrumentNumber { get; set; }
	public DateTime StatisticDate { get; set; }
	public int WorkShiftNumber { get; set; }
	public int DayPart { get; set; }
	public int SampleCount { get; set; }
	public int AnalysisOkCount { get; set; }
	public int NotAllowedRunsCount { get; set; }
	public int RunsCount { get; set; }
	
	public TimeOnly SummAnalysisTime { get; set; }
	public int PreparetionCount { get; set; }
	public decimal SummBadSurfaceRate { get; set; }
	public int OutOfQualityAnalisisCount { get; set; }
	public int NotReproducibleAnalisisCount { get; set; }
	public int BadSurfaceSampleCount { get; set; }
	public int ErrorCount { get; set; }
	//public TimeOnly SummTestModeTime { get; set; }
}

