using System.Data;
using Xceed.Document;
using Xceed.Document.NET;

public static class ReportBuilder
{
	public static string[] BuildReportBody(string[] headerData)
	{
		string[] report = new string[3];
		//TODO: Павел. Вообще ненравится тело метода, непосвященному сложно понять что здесь происходит.
		//Это из-за массива в параметрах. Я это сделал (преобразовал в массив строк) по тому что ненравится мне большое количество параметров
		//в сигнатуре. Как поступать в таких случаях?
		report[0] = "Отчет";
		report[1] = $"По Контейнерной лаборатории №{headerData[0]} участка {headerData[1]}";

		if (headerData[2] == headerData[3])
		{
			report[2] = $"за {headerData[2]}";
		}
		if (headerData[2] != headerData[3])
		{
			report[2] = $"за период с {headerData[2]} по {headerData[3]}";
		}

		return report;
	}
	
	public static Table BuildTableReport(DataTable reportData, Table reportTable)
	{
		Table result = reportTable;

		for (int i = 0; i < result.Rows.Count; i++)
		{
			switch (reportData.Columns[i].ColumnName)
			{
				case "NumberOfWorkShift":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Смена номер");
					break;
				case "SampleCount":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Количество проб");
					break;
				case "AnalysisOkCount":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Успешный анализ");
					break;
				case "PreparetionCount":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Количество обработок");
					break;
				case "ErrorCount":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Ошибки");
					break;
				case "SummTestModeTime":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Время Test mode");
					break;
				case "AverageAnalysisTime":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Среднее время анализа");
					break;
				case "AverageOneSideRuns":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Ср. кол-во прожигов");
					break;
				case "AverageBadSurfaceRate":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Ср. процент плохой пов.");
					break;
				case "AverageSamplePreparation":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Ср. кол-во обработок");
					break;
				case "PercentBadSample":
					result.Rows[i].Cells[0].Paragraphs[0].Append("Процент брака");
					break;
			}
			result.AutoFit = AutoFit.Contents;
		}

		for (int i = 0; i < result.Rows.Count; i++)
		{
			for (int j = 1; j < result.Rows[i].Cells.Count; j++)
			{
				result.Rows[i].Cells[j].Paragraphs[0].Append(reportData.Rows[j - 1][i].ToString());
			}
		}

		return result;
	}
	
}