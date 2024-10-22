using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;

public class ExcelOperator
{
	string _dataFilePath;
// TODO: Get file paht in construstor
	public ExcelOperator()
	{
		ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
		_dataFilePath = GetFilePath();
	}

	public bool SaveStatistic(List<DayLogStatistic> statistics)
	{
		if(!IsFileExistAndFree())
			return false;
		
		if (IsWorkbookEmpty(_dataFilePath))
		{
			WriteData(statistics);

			return true;
		}

		var savedData = ReadData();
		WriteData(savedData.Union(statistics, new StatisticsComparer()).ToList());

		return true;
	}

	public List<DayLogStatistic> ReadData()
	{
		List<DayLogStatistic> data = null;

		if (IsWorkbookEmpty(_dataFilePath))
			return data;

		using (var package = new ExcelPackage(_dataFilePath))
		{
			var tableAddres = package.Workbook.Worksheets["First"].Dimension.ToString();
			data = package.Workbook.Worksheets["First"].Cells[tableAddres].
					ToCollectionWithMappings<DayLogStatistic>(RowToDayDayLogSatatistic,
						options => options.HeaderRow = 0);
		}

		return data;
	}

	void WriteData(List<DayLogStatistic> data)
	{
		using (var package = new ExcelPackage(_dataFilePath))
		{
			package.Workbook.Worksheets[0].Name = "First";
			var worksheet = package.Workbook.Worksheets["First"];
			worksheet.Cells["A1"].LoadFromCollection(data, true);

			package.Save();
		}
	}

	DayLogStatistic RowToDayDayLogSatatistic(OfficeOpenXml.Export.ToCollection.ToCollectionRow row)
	{
		DayLogStatistic dayLogStatistic = new DayLogStatistic();

		dayLogStatistic.InstrumentNumber = row.GetValue<string>(0);
		dayLogStatistic.LogDate = DateTime.FromOADate(row.GetValue<double>(1));
		dayLogStatistic.DayPart = row.GetValue<int>(2);
		dayLogStatistic.NumberOfWorkShift = row.GetValue<int>(3);
		dayLogStatistic.SampleCount = row.GetValue<int>(4);
		dayLogStatistic.AnalysisOkCount = row.GetValue<int>(5);
		dayLogStatistic.NotAllowedRunsCount = row.GetValue<int>(6);
		dayLogStatistic.RunsCount = row.GetValue<int>(7);
		dayLogStatistic.SummAnalysisTime = TimeOnly.FromDateTime(DateTime.FromOADate(row.GetValue<double>(8)));
		dayLogStatistic.PreparetionCount = row.GetValue<int>(9);
		dayLogStatistic.SummBadSurfaceRate = row.GetValue<int>(10);
		dayLogStatistic.OutOfQualityAnalisisCount = row.GetValue<int>(11);
		dayLogStatistic.NotReproducibleAnalisisCount = row.GetValue<int>(12);
		dayLogStatistic.BadSurfaceSampleCount = row.GetValue<int>(13);
		dayLogStatistic.ErrorCount = row.GetValue<int>(14);
		dayLogStatistic.SummTestModeTime = TimeOnly.FromDateTime(DateTime.FromOADate(row.GetValue<double>(15)));

		return dayLogStatistic;
	}

	bool IsWorkbookEmpty(string filePath)
	{
		using (var package = new ExcelPackage(filePath))
		{
			var worksheets = package.Workbook.Worksheets;
			if(worksheets.Count == 0)
			{
				package.Workbook.Worksheets.Add("First");
				package.Save();

				return true;
			}
			if (worksheets[0].Cells.IsNullOrEmpty())
			{
				return true;
			}
		}

		return false;
	}

	string GetFilePath()
	{
		var path = ConfigurationManager.AppSettings["Excel_file_path"].ToString();
		var realPath = new FileInfo(path).FullName;

		return realPath;
	}

	bool IsFileExistAndFree()
	{
		if (!File.Exists(_dataFilePath))
		{
			File.Create(_dataFilePath).Close();

			return true;
		}

		try
		{
			using(FileStream stream = File.OpenRead(_dataFilePath))
			{
				stream.Close();
			}
		}
		catch (Exception ex) 
		{
			return false;
		}

		return true;
	}
}