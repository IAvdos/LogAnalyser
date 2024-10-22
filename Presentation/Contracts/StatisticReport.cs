public class StatisticReport
{
	public int NumberOfWorkShift { get; set; }
	public int SampleCount { get; set; }
	public int AnalysisOkCount { get; set; }
	public int PreparetionCount { get; set; }
	/*
	public int NotAllowedRunsCount { get; set; }
	public int OutOfQualityAnalisisCount { get; set; }
	public int NotReproducibleAnalisisCount { get; set; }
	public int BadSurfaceSampleCount { get; set; }
	*/
	public int ErrorCount { get; set; }
	public TimeOnly SummTestModeTime { get; set; }
	public TimeOnly AverageAnalysisTime { get; set; }
	public decimal AverageOneSideRuns { get; set; }
	public decimal AverageBadSurfaceRate { get; set; }
	public decimal AverageSamplePreparation { get; set; }
	public decimal PercentBadSample { get; set; }
}