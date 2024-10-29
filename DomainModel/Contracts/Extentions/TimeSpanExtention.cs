public static class TimeSpanExtention
{
	// TODO: Павел, этический вопрос. Я знаю (уверен) что здесь value.Days всегда будет = 0. И поэтому непреобразую дни в минуты.
	// Но если ктото в дальнейшем будет обращаться к этому методу, он получит некорректный результат.
	// Пока писал, понял что наврное стоит писать наверняка.
	public static double ToMinutes(this TimeSpan value)
	{
		double minutes = value.Minutes;
		minutes += value.Hours * 60;
		double seconds = (double)value.Seconds / 100;

		return minutes + seconds;
	}

	public static TimeSpan Sum(this IEnumerable<DayLogStatistic> values, Func<DayLogStatistic, TimeSpan> selector)
	{
		var result = new TimeSpan(0, 0, 0);

		foreach (var value in values)
		{
			result = result.Add(selector.Invoke(value));
		}

		return result;
	}
	// TODO: и что делать с методами которые не используются, но могут понадобятся в дальнейшем. Оставлять, удалять, коментировать?
	public static TimeSpan Divide(this TimeSpan value, int divider)
	{
		if (divider == 0) divider = 1;
		int seconds = value.Hours * 3600 + value.Minutes * 60 + value.Seconds;
		var divided = seconds / divider;

		return new TimeSpan(0, divided / 60, divided % 60);
	}
}