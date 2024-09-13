using DietPreparation.Common.Consts;

namespace DietPreparation.Common.Extensions;

public static class DecimalExtensions
{
	public static decimal? Round(this decimal? value, int decimals)
	{
		if (!value.HasValue)
		{
			return value;
		}

		return Math.Round(value.Value, decimals);
	}

	public static string ToSqlValue(this decimal? value)
	{
		if (value is null)
		{
			return DefaultStrings.Null;
		}

		return value.Value.ToString();
	}
}