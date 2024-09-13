using DietPreparation.Common.Consts;

namespace DietPreparation.Common.Extensions;
public static class DateTimeExtensions
{
	/// <summary>
	/// Converts nullable DateTime to a string that can be used in SQL queries.
	/// </summary>
	/// <param name="value">The nullable DateTime value to convert.</param>
	/// <returns>A string in SQL datetime format if the value is not null; otherwise, returns the string 'NULL'.</returns>
	public static string ToSqlValue(this DateTime? value, string format = FormatStrings.SqlDatetimeFormat)
	{
		return value.HasValue
			? $"'{value.Value.ToString(format)}'"
			: DefaultStrings.Null;
	}

	/// <summary>
	/// Converts a nullable DateTime value to a string representation using the specified format.
	/// </summary>
	/// <param name="value">The nullable DateTime value to convert.</param>
	/// <param name="format">The format of the resulting string, e.g. "dd-MMM-yyyy".</param>
	/// <returns>A string representation of the DateTime value using the specified format, or an empty string if the value is null.</returns>
	public static string ToString(this DateTime? value, string format)
	{
		return value.HasValue ? value.Value.ToString(format, CurrentCulture.Culture) : string.Empty;
	}

	/// <summary>
	/// Returns the maximum of the two given DateTime instances.
	/// </summary>
	/// <param name="date1">First DateTime instance to compare.</param>
	/// <param name="date2">Second DateTime instance to compare.</param>
	/// <returns>The maximum DateTime of the two provided.</returns>
	public static DateTime? GetMax(this DateTime? date1, DateTime? date2)
	{
		return date1 > date2 ? date1 : date2;
	}
}