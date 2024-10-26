public interface IDiagramView : IView
{
	event Func<string, DateTime[]> GetStatisticDatesForInstrument;
	event Func<DateTime, DateTime, int, string, string, List<DiagramPoint>> GetStatisticReport;
}