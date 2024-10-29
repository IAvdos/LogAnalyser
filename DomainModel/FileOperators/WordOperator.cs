using System.Data;
using Xceed.Document.NET;
using Xceed.Words.NET;

public class WordOperator
{
	public void SaveFile(string[] reportBody, DataTable dtReport, string filePath)
	{
		using(DocX document = DocX.Create(filePath))
		{
			document.InsertParagraph(reportBody[0]).FontSize(16).Bold().Alignment = Alignment.center;
			document.InsertParagraph(reportBody[1]).FontSize(12).Alignment = Alignment.center;
			document.InsertParagraph(reportBody[2]).FontSize(12).Alignment = Alignment.center;

			Table reportTable = document.AddTable(dtReport.Columns.Count, dtReport.Rows.Count + 1);
			reportTable = ReportBuilder.BuildTableReport(dtReport, reportTable);
			reportTable.Alignment = Alignment.center;

			document.InsertTable(reportTable);

			document.Save();
		}
	}
}