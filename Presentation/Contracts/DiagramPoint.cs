public class DiagramPoint
{
	public DiagramPoint(DateTime date, double value)
	{
		xAxis = date;
		yAxis = value;
	}

	public DateTime xAxis {  get; set; }
	public double yAxis { get; set; }
}