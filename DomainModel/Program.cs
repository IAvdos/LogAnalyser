using System.Data;
using System.Diagnostics;
using System.Net.WebSockets;

public class Program
{
	
	public static void Main()
	{
		// TODO: remove this
		/*
		Stopwatch stopwatch = Stopwatch.StartNew();
		var manager = new LogAnalisisManager();
		var exccel = new ExcelOperator();


		string directory = @".\..\..\..\LOG\2";
		var paths = GetFilesPath(directory);
		List<ReadLogFileStatus> readLogFileStatuses;

		var statistics = manager.GetDayLogStatistics(paths,out readLogFileStatuses);

		ReadStatusFiles(readLogFileStatuses);
		//exccel.SaveStatistic(statistics);
	*/
		/*
		var result = exccel.ReadData();
		//if (result == null) { Console.WriteLine("null!!!!!!!!!"); }
		Console.WriteLine(result.Count);
		var dayStat = StatisticConverter.GetPeriodWorkShiftStatistics(new DateTime(2024, 09, 5), new DateTime(2024, 09, 12), result);
		//var dayStat = StatisticConverter.GetDayStatisticByWorkShift(result);
		foreach(var stat in dayStat)
		{
			WriteStatistic(stat);
		}
		*/

        //DbCRUD db = new DbCRUD();
        //foreach (var stat in statistics)
        {
		//	db.Add(stat);
		}

		//var excel = new ExcelOperator();
		//excel.AddStatistic(statistics);
		//var dt = excel.ReadData();
		//WriteDataTable(dt);
		//Console.WriteLine(dt.Columns[0].ColumnName);
		//var value = db.GetFirts();
		//Console.WriteLine(value.InstrumentNumber);
       

		//foreach(var statistic in statistics)
		{
			//WriteStatistic(statistic);
		}
		/*
		stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        //WriteConsoleDayLog(result.ToList());
		*/
    }
		
	public static string[] GetFilesPath(string directoryPath)
	{
		DirectoryInfo dir = new DirectoryInfo(directoryPath);

		var paths = dir.GetFiles("Event*").Select(file => file.FullName).ToArray();

		return paths;
	}

	public static void WriteStatistic(DayLogStatistic dayLogStatistics)
	{
			Console.WriteLine($"{dayLogStatistics.InstrumentNumber} -- {dayLogStatistics.LogDate} --- {dayLogStatistics.DayPart}");
			Console.WriteLine("Number of day shift - " + dayLogStatistics.NumberOfWorkShift);
			Console.WriteLine(new string('.', 50));
			Console.WriteLine($"Sample count = {dayLogStatistics.SampleCount}");
			Console.WriteLine("Runs count = "+dayLogStatistics.RunsCount.ToString());
            Console.WriteLine("Preparetion count = " + dayLogStatistics.PreparetionCount);
            Console.WriteLine("Bad surface rate = " + dayLogStatistics.SummBadSurfaceRate);
            Console.WriteLine("Not allowed runs count = " + dayLogStatistics.NotAllowedRunsCount);
            Console.WriteLine($"Finished count = {dayLogStatistics.SummAnalysisTime.Hour}:{dayLogStatistics.SummAnalysisTime.Minute}:{dayLogStatistics.SummAnalysisTime.Second}");
			Console.WriteLine("Not reproducible analysis count = " + dayLogStatistics.NotReproducibleAnalisisCount);
            Console.WriteLine("Out of quality analysis count = " + dayLogStatistics.OutOfQualityAnalisisCount);
            Console.WriteLine("Bad sample count = " + dayLogStatistics.BadSurfaceSampleCount);
            Console.WriteLine("Analysis ok count = " + dayLogStatistics.AnalysisOkCount);
            Console.WriteLine("Error count = " + dayLogStatistics.ErrorCount);
            Console.WriteLine($"Summary test time = {dayLogStatistics.SummTestModeTime.Hour}:{dayLogStatistics.SummTestModeTime.Minute}:{dayLogStatistics.SummTestModeTime.Second}");
			/*Console.WriteLine(new String('-', 50));
			Console.WriteLine("Avarage analisys time = " + dayLogStatistics.AverageAnalysisTime.ToLongTimeString());
			Console.WriteLine("Percent bad sample = " + dayLogStatistics.PercentBadSample +'%');
			Console.WriteLine("Avarage bad surface rate = " + dayLogStatistics.AverageBadSurfaceRate);
            Console.WriteLine("Average preparing sample = " + dayLogStatistics.AverageSamplePreparation);
            Console.WriteLine("Average one side runs = " + dayLogStatistics.AverageOneSideRuns);
            Console.WriteLine("Percent bad one side analisys = " + dayLogStatistics.PercentBadOneSideAnalisys);*/
            Console.WriteLine(new String('=', 50));
            Console.WriteLine("\n");
	}

	private static void WriteConsoleDayLog(List<DayLog> dayLogs)
	{
		foreach (DayLog dayLog in dayLogs)
		{
			Console.WriteLine(dayLog.InstrumentNumber);
			Console.WriteLine(dayLog.LogType);
			Console.WriteLine(dayLog.LogDate.ToString());
			Console.WriteLine(new String('-', 35));

			foreach(var line in dayLog.log)
			{
				Console.WriteLine(line);
			}
		}
	}

	private static void WriteDataTable(DataTable dataTable)
	{
		foreach (DataRow row in dataTable.Rows) 
		{
			string rowLine = null;
			for(int i = 0; i < 16; i++)
			{
				rowLine += row[i] + "   ";
			}
            Console.WriteLine(rowLine);
			
		}
	}

	private static void ReadStatusFiles(List<ReadLogFileStatus> status)
	{
		foreach(var stat in status)
		{
			Console.WriteLine(stat.FileName +"---" +stat.Status);
		}
	}

}