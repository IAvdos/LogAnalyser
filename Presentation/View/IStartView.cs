public interface IStartView : IView
{
	event Action<string[]> ReadLogs;
	void ShowReport(string[] status);
}