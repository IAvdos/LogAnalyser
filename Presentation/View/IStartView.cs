public interface IStartView : IView
{
	event Action<string[]> ReadLogs;
	//event Func<DateTime[]> GetStatisticDates;
	void ShowReport(string[] status);
}