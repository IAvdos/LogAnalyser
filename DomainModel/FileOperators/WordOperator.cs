using Xceed.Document.NET;
using Xceed.Words.NET;

public class WordOperator
{
	//TODO: write methods
	public void WriteWordDoc(string fullFileName)
	{
		DocX document = DocX.Create(fullFileName);

		// Add a title to the document
		document.InsertParagraph("Отчет").FontSize(16).Bold().Alignment = Alignment.center;
		/*
		// Add a paragraph with some text
		document.InsertParagraph("This is a sample paragraph.").FontSize(12).Alignment = Alignment.left;
		
		// Add a table with some data
		Table table = document.AddTable(3, 2);
		table.Design = TableDesign.ColorfulList;
		table.Alignment = Alignment.center;
		table.AutoFit = AutoFit.Contents;

		// Add headers to the table
		table.Rows[0].Cells[0].Paragraphs[0].Append("Name").Bold();
		table.Rows[0].Cells[1].Paragraphs[0].Append("Age").Bold();

		// Add data to the table
		table.Rows[1].Cells[0].Paragraphs[0].Append("John Doe");
		table.Rows[1].Cells[1].Paragraphs[0].Append("30");
		table.Rows[2].Cells[0].Paragraphs[0].Append("Jane Smith");
		table.Rows[2].Cells[1].Paragraphs[0].Append("25");

		document.InsertTable(table);
		*/
		// Save the document
		document.Save();
	}

	internal void SaveFile(string[] reportBody, Table reportTable, string filePath)
	{
		throw new NotImplementedException();
	}
}
