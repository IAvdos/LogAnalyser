public class DbCRUD
{
	public void Add(DayLogStatistic statistic)
	{
		using(StatisticDBContext context = new StatisticDBContext())
		{
			//context.Add(statistic.ToWorkShiftStatistic());

			context.SaveChanges();
		}
	}

	public WorkShiftStatistic GetFirts()
	{
		WorkShiftStatistic result = null;
		using(StatisticDBContext ctx = new StatisticDBContext())
		{
			//result = ctx.WorkShiftStatistics.First();
			result = ctx.WorkShiftStatistics.First();
		}

		return result;
	}

	
}

