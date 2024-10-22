using System.Diagnostics.CodeAnalysis;

public class StatisticsComparer : IEqualityComparer<DayLogStatistic>
{
	public bool Equals(DayLogStatistic? x, DayLogStatistic? y)
	{
		if(x.InstrumentNumber == y.InstrumentNumber &&
			x.LogDate == y.LogDate && x.DayPart == y.DayPart)
			return true;

		return false;
	}

	public int GetHashCode([DisallowNull] DayLogStatistic obj)
	{
		int hCode = Convert.ToInt32(obj.LogDate.ToOADate()) + obj.DayPart;

		return hCode;
	}
}