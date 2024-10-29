public interface IReportView : IView
{
	event Func<string, DateTime[]> GetStatisticDatesForInstrument;
	event Func<DateTime, DateTime, int[], string, List<StatisticReport>> GetStatisticReport;
	public event Action<string, DateTime, DateTime, string, string> SaveReport;
}