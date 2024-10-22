public static class TimeOnlyExtensions
{
	public static TimeOnly Add(this TimeOnly timeOnly, TimeOnly value)
	{
		int seconds = timeOnly.Second + value.Second;
		int minute = timeOnly.Minute + value.Minute;
		int hour = timeOnly.Hour + value.Hour;

		if(seconds > 59)
		{
			minute += 1;
			seconds -= 60;
		}
		if(minute > 59)
		{
			hour += 1;
			minute -= 60;
		}

		return new TimeOnly(hour, minute, seconds);
	}

	public static double ToDouble(this TimeOnly value)
	{
		double minutes = value.Minute;
		double seconds = (double)value.Second / 100;

		return minutes + seconds;
	}

	public static TimeOnly Subtract(this TimeOnly timeOnly, TimeOnly value)
	{
		int seconds = timeOnly.Second - value.Second;
		int minute = timeOnly.Minute - value.Minute;
		int hour = timeOnly.Hour - value.Hour;

		if(seconds < 0)
		{
			minute -= 1;
			seconds = 60 + seconds;
		}
		if (minute < 0)
		{
			hour -= 1;
			minute = 60 + minute;
		}

		return new TimeOnly(hour, minute, seconds);
	}

	public static TimeOnly Divide(this TimeOnly timeOnly, int divider)
	{
		if(divider == 0) divider = 1;
		int seconds = timeOnly.Hour * 3600 + timeOnly.Minute * 60 + timeOnly.Second;

		var divided = seconds / divider;

		return new TimeOnly(0, divided / 60, divided % 60);
	}
}

