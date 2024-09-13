using DietPreparation.Common.Consts;

namespace DietPreparation.Common.Extensions;

public static class IntegerExtensions
{
	public static string ToSqlValue(this int? value)
	{
		if (value is null)
		{
			return DefaultStrings.Null;
		}

		return value.Value.ToString();
	}

	public static int ToMs(this int value)
	{
		TimeSpan timeSpan = TimeSpan.FromMinutes(value);
		return (int)timeSpan.TotalMilliseconds;
	}
}