using System.Data;

public static class EnumerableExtention
{
	public static TimeOnly Sum(this IEnumerable<DayLogStatistic> values, Func<DayLogStatistic, TimeOnly> selector)
	{
		var result = new TimeOnly(0,0,0);

		foreach (var value in values)
		{
			result = result.Add(selector.Invoke(value));
		}

		return result;
	}

	public static DataTable ToDataTable(this IEnumerable<DayLogStatistic> list)
	{
		DataTable dt = new DataTable();

		DataColumn InstrumentNumberColumn = new DataColumn();
		InstrumentNumberColumn.ColumnName = "Instrument number";

		DataColumn LogDateColumn = new DataColumn();
		LogDateColumn.ColumnName = "Log date";

		DataColumn SampleCountColumn = new DataColumn();
		SampleCountColumn.ColumnName = "Sample count";

		DataColumn DayPartColumn = new DataColumn();
		DayPartColumn.ColumnName = "Day part";

		DataColumn NumberOfWorkShiftColumn = new DataColumn();
		NumberOfWorkShiftColumn.ColumnName = "Number of work shift";

		DataColumn AnalysysOkCountColumn = new DataColumn();
		AnalysysOkCountColumn.ColumnName = "Analisys ok count";

		DataColumn NotAllowedRunsCountColumn = new DataColumn();
		NotAllowedRunsCountColumn.ColumnName = "NotAllowedrunsCount";

		DataColumn RunsCountColumn = new DataColumn();
		RunsCountColumn.ColumnName = "Runs count";

		DataColumn SummAnalisysTimeColumn = new DataColumn();
		SummAnalisysTimeColumn.ColumnName = "Summ analisys time";

		DataColumn PreparetionCountColumn = new DataColumn();
		PreparetionCountColumn.ColumnName = "Preparetion count";

		DataColumn SummBadSurfaceRateColumn = new DataColumn();
		SummBadSurfaceRateColumn.ColumnName = "Summ bad surface rate";

		DataColumn OutOfQualityAnalisysCountColumn = new DataColumn();
		OutOfQualityAnalisysCountColumn.ColumnName = "Out of quality analisys";

		DataColumn NotReproducibleAnalisisCountColumn = new DataColumn();
		NotReproducibleAnalisisCountColumn.ColumnName = "Not reproducible analisys count";

		DataColumn BadSurfaceSampleCountColumn = new DataColumn();
		BadSurfaceSampleCountColumn.ColumnName = "Bad surface sample count";

		DataColumn ErrorCountColumn = new DataColumn();
		ErrorCountColumn.ColumnName = "Error count";

		DataColumn SummTestModeTimeColumn = new DataColumn();
		SummTestModeTimeColumn.ColumnName = "Summ test mode time";


		dt.Columns.Add(InstrumentNumberColumn);
		dt.Columns.Add(LogDateColumn);
		dt.Columns.Add(DayPartColumn);
		dt.Columns.Add(NumberOfWorkShiftColumn);
		dt.Columns.Add(SampleCountColumn);
		dt.Columns.Add(AnalysysOkCountColumn);
		dt.Columns.Add(NotAllowedRunsCountColumn);
		dt.Columns.Add(RunsCountColumn);
		dt.Columns.Add(SummAnalisysTimeColumn);
		dt.Columns.Add(PreparetionCountColumn);
		dt.Columns.Add(SummBadSurfaceRateColumn);
		dt.Columns.Add(OutOfQualityAnalisysCountColumn);
		dt.Columns.Add(NotReproducibleAnalisisCountColumn);
		dt.Columns.Add(BadSurfaceSampleCountColumn);
		dt.Columns.Add(ErrorCountColumn);
		dt.Columns.Add(SummTestModeTimeColumn);


		foreach (DayLogStatistic item in list)
		{
			var row = dt.NewRow();

			row[InstrumentNumberColumn.ColumnName] = item.InstrumentNumber;
			row[LogDateColumn.ColumnName] = item.LogDate.Date;
			row[DayPartColumn.ColumnName] = (int)item.DayPart;
			row[NumberOfWorkShiftColumn.ColumnName] = item.NumberOfWorkShift;
			row[SampleCountColumn.ColumnName] = (int)item.SampleCount;
			row[AnalysysOkCountColumn.ColumnName] = item.AnalysisOkCount;
			row[NotAllowedRunsCountColumn.ColumnName] = item.NotAllowedRunsCount;
			row[RunsCountColumn.ColumnName] = item.RunsCount;
			row[SummAnalisysTimeColumn.ColumnName] = item.SummAnalysisTime;
			row[PreparetionCountColumn.ColumnName] = item.PreparetionCount;
			row[SummBadSurfaceRateColumn.ColumnName] = item.SummBadSurfaceRate;
			row[OutOfQualityAnalisysCountColumn.ColumnName] = item.OutOfQualityAnalisisCount;
			row[NotReproducibleAnalisisCountColumn.ColumnName] = item.NotReproducibleAnalisisCount;
			row[BadSurfaceSampleCountColumn.ColumnName] = item.BadSurfaceSampleCount;
			row[ErrorCountColumn.ColumnName] = item.ErrorCount;
			row[SummTestModeTimeColumn.ColumnName] = item.SummTestModeTime;

			dt.Rows.Add(row);
		}

		return dt;
	}

	static DataTable GetNamedColumnsTable()
	{
		DataTable dt = new DataTable();

		DataColumn InstrumentNumberColumn = new DataColumn();
		InstrumentNumberColumn.ColumnName = "Instrument number";

		DataColumn LogDateColumn = new DataColumn();
		LogDateColumn.ColumnName = "Log date";

		DataColumn SampleCountColumn = new DataColumn();
		SampleCountColumn.ColumnName = "Sample count";

		DataColumn DayPartColumn = new DataColumn();
		DayPartColumn.ColumnName = "Day part";

		DataColumn NumberOfWorkShiftColumn = new DataColumn();
		NumberOfWorkShiftColumn.ColumnName = "Number of work shift";

		DataColumn AnalysysOkCountColumn = new DataColumn();
		AnalysysOkCountColumn.ColumnName = "Analisys ok count";

		DataColumn NotAllowedRunsCountColumn = new DataColumn();
		NotAllowedRunsCountColumn.ColumnName = "NotAllowedrunsCount";

		DataColumn RunsCountColumn = new DataColumn();
		RunsCountColumn.ColumnName = "Runs count";

		DataColumn SummAnalisysTimeColumn = new DataColumn();
		SummAnalisysTimeColumn.ColumnName = "Summ analisys time";

		DataColumn PreparetionCountColumn = new DataColumn();
		PreparetionCountColumn.ColumnName = "Preparetion count";

		DataColumn SummBadSurfaceRateColumn = new DataColumn();
		SummBadSurfaceRateColumn.ColumnName = "Summ bad surface rate";

		DataColumn OutOfQualityAnalisysCountColumn = new DataColumn();
		OutOfQualityAnalisysCountColumn.ColumnName = "Out of quality analisys";

		DataColumn NotReproducibleAnalisisCountColumn = new DataColumn();
		NotAllowedRunsCountColumn.ColumnName = "Not reproducible analisys count";

		DataColumn BadSurfaceSampleCountColumn = new DataColumn();
		BadSurfaceSampleCountColumn.ColumnName = "Bad surface sample count";

		DataColumn ErrorCountColumn = new DataColumn();
		ErrorCountColumn.ColumnName = "Error count";

		DataColumn SummTestModeTimeColumn = new DataColumn();
		SummTestModeTimeColumn.ColumnName = "Summ test mode time";


		dt.Columns.Add(InstrumentNumberColumn);
		dt.Columns.Add(LogDateColumn);
		dt.Columns.Add(DayPartColumn);
		dt.Columns.Add(NumberOfWorkShiftColumn);
		dt.Columns.Add(SampleCountColumn);
		dt.Columns.Add(AnalysysOkCountColumn);
		dt.Columns.Add(NotAllowedRunsCountColumn);
		dt.Columns.Add(RunsCountColumn);
		dt.Columns.Add(SummAnalisysTimeColumn);
		dt.Columns.Add(PreparetionCountColumn);
		dt.Columns.Add(SummBadSurfaceRateColumn);
		dt.Columns.Add(OutOfQualityAnalisysCountColumn);
		dt.Columns.Add(NotReproducibleAnalisisCountColumn);
		dt.Columns.Add(BadSurfaceSampleCountColumn);
		dt.Columns.Add(ErrorCountColumn);
		dt.Columns.Add(SummTestModeTimeColumn);

		return dt;
	}
}