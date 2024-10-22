public class CalculatedStatistic
{
	public CalculatedStatistic() { }

	public string InstrumentNumber { get; set; }
	public DateTime LogDate { get; set; }
	public int NumberOfWorkShift { get; set; }
	public int SampleCount { get; set; } = 0;
	public int PreparetionCount { get; set; } = 0;
	public int ErrorCount { get; set; }
	public TimeOnly SummTestModeTime { get; set; }	
	public TimeOnly AverageAnalysisTime { get; set; }
	public decimal AverageOneSideRuns { get; set; }
	public decimal AverageBadSurfaceRate { get; set; }
	public decimal AverageSamplePreparation { get; set; }
	public decimal PercentBadSample { get; set; }
}