using OfficeOpenXml.Attributes;
public class DayLogStatistic
{
	public DayLogStatistic(DateTime logDay, string instrumentNumber)
	{
		LogDate = logDay;
		InstrumentNumber = instrumentNumber;
	}

	public DayLogStatistic(){}
	
	public string InstrumentNumber { get; set; }

	[EpplusTableColumn(NumberFormat = "dd.mm.yyyy")]
	public DateTime LogDate { get; set; }

	//Day divided to tree part
	//First part between 00:00 and 7:30
	//Second part between 7:30 and 19:30
	//Third part between 19:30 and 23:59
	public int DayPart { get; set; }
	public int NumberOfWorkShift { get; set; }

	public int SampleCount { get; set; } = 0;
	public int AnalysisOkCount { get; set; } = 0;
	public int NotAllowedRunsCount { get; set; } = 0;
	public int RunsCount { get; set; } = 0;

	[EpplusTableColumn(NumberFormat = "hh:mm:ss")]
	public TimeOnly SummAnalysisTime { get; set; } = new TimeOnly(0, 0, 0);
	public int PreparetionCount { get; set; } = 0;
	public decimal SummBadSurfaceRate { get; set; } = 0;
	public int OutOfQualityAnalisisCount { get; set; } = 0;
	public int NotReproducibleAnalisisCount { get; set; } = 0;
	public int BadSurfaceSampleCount { get; set; }
	public int ErrorCount { get; set; }

	[EpplusTableColumn(NumberFormat = "hh:mm:ss")]
	public TimeOnly SummTestModeTime { get; set; }

// TODO: finger hole not detected? And fields to db.

	public WorkShiftStatistic ToWorkShiftStatistic()
	{
		return new WorkShiftStatistic()
		{
			InstrumentNumber = this.InstrumentNumber,
			StatisticDate = this.LogDate,
			WorkShiftNumber = this.NumberOfWorkShift,
			DayPart = this.DayPart,
			SampleCount = this.SampleCount,
			AnalysisOkCount = this.AnalysisOkCount,
			NotAllowedRunsCount = this.NotAllowedRunsCount,
			RunsCount = this.RunsCount,
			//SummAnalysisTime = this.SummAnalysisTime,
			PreparetionCount = this.PreparetionCount,
			SummBadSurfaceRate = this.SummBadSurfaceRate,
			OutOfQualityAnalisisCount = this.OutOfQualityAnalisisCount,
			NotReproducibleAnalisisCount = this.NotReproducibleAnalisisCount,
			BadSurfaceSampleCount = this.BadSurfaceSampleCount,
			ErrorCount = this.ErrorCount,
			//SummTestModeTime = this.SummTestModeTime
		};
	}
}

