using DietPreparation.Common.Consts;

namespace DietPreparation.Common.Extensions;

public static class BooleanExtensions
{
	public static string ToSqlValue(this bool? value)
	{
		if (value.HasValue)
		{
			return value.Value ? "1" : "0";
		}

		return DefaultStrings.Null;
	}
}