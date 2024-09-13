using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace DietPreparation.Common.Extensions;

public static class EnumExtensions
{
	public static int GetNumber(this Enum value)
	{
		return GetValue<int>(value);
	}

	public static string GetNumberAsString(this Enum value)
	{
		return GetNumber(value).ToString(CultureInfo.InvariantCulture);
	}

	public static T GetValue<T>(this Enum value)
	{
		return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
	}

	public static T GetEnum<T>(this int value) where T : Enum
	{
		return (T)Enum.ToObject(typeof(T), value);
	}

	/// <summary>
	/// Gets the display name of the specified enum value.
	/// </summary>
	/// <param name="value">The enum value.</param>
	/// <returns>
	/// The display name of the enum value,
	/// or <see langword="ToString()"/> of the value if a display name is not defined or cannot be found.
	/// </returns>
	public static string GetDisplayName(this Enum value)
	{
		return value.GetType().GetMember(value.ToString())
			.FirstOrDefault()?
			.GetCustomAttribute<DisplayAttribute>()?
			.GetName() ?? value.ToString();
	}

	public static string GetDatabaseValue(this Enum value)
	{
		return value.GetType().GetMember(value.ToString())
			.FirstOrDefault()?
			.GetCustomAttribute<DatabaseValueAttribute>()?
			.Value ?? value.ToString();
	}

	public static float GetConversionRateToGram(this Enum value)
	{
		return value.GetType().GetMember(value.ToString())
			.FirstOrDefault()?
			.GetCustomAttribute<ConversionRateToGramAttribute>()?
			.ConversionRate ?? 1;
	}
}
