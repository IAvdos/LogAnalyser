public static class StatisticProcessor
{
	// TODO: Павел. Вспомогательные методы (private), здесь работают последовательно с одним обьектом.
	// Лучше его выносить в отдельное поле, или как здесь предавать его каk аргумент?
	public static List<CalculatedStatistic> GetDayStatisticForPreriod(List<DayLogStatistic> statistics, DateTime startDate, DateTime endDate)
	{
		List<DayLogStatistic> temporary = new List<DayLogStatistic>(statistics);
		var temp = temporary.Where(d => d.LogDate >= startDate && d.LogDate <= endDate).OrderBy(s => s.LogDate).ToList();
		temp = GetFullDayStatistic(temp);

		return ConvertToCalculatedStatistic(temp);
	}

	public static List<CalculatedStatistic> GetWorkShiftStatisticForPreriod(List<DayLogStatistic> statistics, DateTime startDate, DateTime endDate)
	{
		List<DayLogStatistic> temporary = new List<DayLogStatistic>(statistics);
		var temp = temporary.Where(d => d.LogDate >= startDate && d.LogDate <= endDate).OrderBy(s => s.LogDate).ToList();
		temp = GetWorkShiftStatistics(temp);

		return ConvertToCalculatedStatistic(temp);
	}

	static List<DayLogStatistic> GetFullDayStatistic(List<DayLogStatistic> statisticList)
	{
		var result = statisticList.GroupBy(d => d.LogDate).Select(g => new DayLogStatistic
		{
			LogDate = g.Key,
			InstrumentNumber = g.First().InstrumentNumber,
			SampleCount = g.Sum(i => i.SampleCount),
			DayPart = 0,
			NumberOfWorkShift = 0,
			PreparetionCount = g.Sum(i => i.PreparetionCount),
			RunsCount = g.Sum(i => i.RunsCount),
			AnalysisOkCount = g.Sum( i  => i.AnalysisOkCount),
			NotAllowedRunsCount = g.Sum(i => i.NotAllowedRunsCount),
			OutOfQualityAnalisisCount = g.Sum(i => i.OutOfQualityAnalisisCount),
			BadSurfaceSampleCount = g.Sum(i => i.BadSurfaceSampleCount),
			SummAnalysisTime = g.Sum( i => i.SummAnalysisTime),
			SummBadSurfaceRate = g.Sum( i => i.SummBadSurfaceRate),
			SummTestModeTime = g.Sum( i => i.SummTestModeTime),
			ErrorCount = g.Sum(i => i.ErrorCount),
			NotReproducibleAnalisisCount = g.Sum( i => i.NotReproducibleAnalisisCount)
		}).ToList();

		return result;
	}

	static List<DayLogStatistic> GetWorkShiftStatistics(List<DayLogStatistic> statisticList)
	{
		var dayStatisticWithoutAfternoonWorkShift = statisticList.Where(d => d.DayPart != 2).ToList();
		var otherDayStatisticDays = statisticList.Except(dayStatisticWithoutAfternoonWorkShift).ToList();
		
		for(int i = 1; i < dayStatisticWithoutAfternoonWorkShift.Count; i++)
		{
			if (dayStatisticWithoutAfternoonWorkShift[i].DayPart == 1)
				dayStatisticWithoutAfternoonWorkShift[i].LogDate = dayStatisticWithoutAfternoonWorkShift[i].LogDate.AddDays(-1);
		}

		var dayStatisticNightWorkShift = dayStatisticWithoutAfternoonWorkShift.GroupBy(d => new {d.LogDate, d.NumberOfWorkShift}).
			Select(g => new DayLogStatistic
			{
				LogDate = g.Key.LogDate,
				InstrumentNumber = g.First().InstrumentNumber,
				SampleCount = g.Sum(i => i.SampleCount),
				DayPart = 7,
				NumberOfWorkShift = g.Key.NumberOfWorkShift,
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

		return dayStatisticNightWorkShift.Union(otherDayStatisticDays).OrderBy(d => d.LogDate).ToList();
	}

	public static List<CalculatedStatistic> ConvertToCalculatedStatistic(List<DayLogStatistic> logStatistics)
	{
		var result = new List<CalculatedStatistic>();

		foreach (var logStatistic in logStatistics)
		{
			var analysisCount = logStatistic.PreparetionCount - logStatistic.BadSurfaceSampleCount;
			var averageAnalysisTime = new TimeSpan(logStatistic.SummAnalysisTime.Ticks 
				/ (logStatistic.SampleCount == 0 ? 1 : logStatistic.SampleCount));
			var averageSamplePreparetion = logStatistic.SampleCount == 0 ? 0 : Math.Round((decimal)logStatistic.PreparetionCount 
				/ logStatistic.SampleCount, 1);
			var averageOneSideRuns = analysisCount == 0 ? 0 : Math.Round((decimal)logStatistic.RunsCount / analysisCount, 1);
			var averageBadSurfaceRate = analysisCount == 0 ? 0 : Math.Round(logStatistic.SummBadSurfaceRate / analysisCount, 1);
			var badSamplePercent = analysisCount == 0 ? 0 : Math.Round((decimal)(logStatistic.SampleCount - logStatistic.AnalysisOkCount) /
					analysisCount * 100, 1);

			result.Add(new CalculatedStatistic
			{
				LogDate = logStatistic.LogDate,
				InstrumentNumber = logStatistic.InstrumentNumber,
				NumberOfWorkShift = logStatistic.NumberOfWorkShift,
				SampleCount = logStatistic.SampleCount,
				PreparetionCount = logStatistic.PreparetionCount,
				AverageBadSurfaceRate = averageBadSurfaceRate,
				ErrorCount = logStatistic.ErrorCount,
				SummTestModeTime = logStatistic.SummTestModeTime,
				AverageAnalysisTime = averageAnalysisTime,
				AverageOneSideRuns = averageOneSideRuns,
				AverageSamplePreparation = averageSamplePreparetion,
				PercentBadSample = badSamplePercent
			});
		}

		return result;
	}
}

