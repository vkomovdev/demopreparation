using DietPreparation.Common.Attributes;
using DietPreparation.Common.Consts;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace DietPreparation.Common.Extensions;

public static class StringExtensions
{
	public static float ToFloat(this string str)
	{
		if (string.IsNullOrWhiteSpace(str))
			return 0f;

		if (float.TryParse(str, CultureInfo.InvariantCulture, out float result))
			return result;

		return 0f;
	}

	public static string ToSqlValue(this string? value)
	{
		if (value is null)
		{
			return DefaultStrings.Null;
		}

		return $"'{value.EscapeSqlSpecialCharacters()}'";
	}

	public static string EscapeSqlSpecialCharacters(this string? value)
	{
		if (value is null)
		{
			return DefaultStrings.Null;
		}
		return value
			.Replace("'", "''");
	}

	public static string ToDefaultIfEmpty(this string? value, string defaultValue)
	{
		return string.IsNullOrEmpty(value) ? defaultValue : value;
	}

	/// <summary>Gets the value of the enum that has the specified display name.</summary>
	/// <typeparam name="T">The type of the enum.</typeparam>
	/// <param name="name">The display name of the enum value.</param>
	/// <returns>
	/// The value of the enum that has the specified display name,
	/// or <see langword="default"/> if no such value is found.
	/// </returns>
	public static T? GetEnum<T>(this string? name) where T : Enum
		=> GetEnum<T>(name, default);

	/// <summary>Gets the value of the enum that has the specified display name.</summary>
	/// <typeparam name="T">The type of the enum.</typeparam>
	/// <param name="name">The display name of the enum value.</param>
	/// <returns>
	/// The value of the enum that has the specified display name,
	/// or <see langword="defaultValue"/> if no such value is found.
	/// </returns>
	public static T? GetEnum<T>(this string? name, T? defaultValue = default) where T : Enum
	{
		if (name is null)
		{
			return defaultValue;
		}

		foreach (T value in Enum.GetValues(typeof(T)))
		{
			var member = typeof(T).GetMember(value.ToString()).FirstOrDefault();

			if (member is null)
			{
				return defaultValue;
			}

			if (member.GetCustomAttribute<DisplayAttribute>()?.GetName() == name)
			{
				return value;
			}
		}

		return defaultValue;
	}

	public static T? GetEnumFromDatabaseValue<T>(this string? name) where T : Enum
		=> GetEnumFromDatabaseValue<T>(name, default);

	public static T? GetEnumFromDatabaseValue<T>(this string? name, T? defaultValue = default) where T : Enum
	{
		if (name is null)
		{
			return defaultValue;
		}

		foreach (T value in Enum.GetValues(typeof(T)))
		{
			var member = typeof(T).GetMember(value.ToString()).FirstOrDefault();

			if (member is null)
			{
				return defaultValue;
			}

			if (member.GetCustomAttribute<DatabaseValueAttribute>()?.Value == name)
			{
				return value;
			}
		}

		return defaultValue;
	}

	public static string GetColumnName(this string value)
	{
		var parts = value.Split('.');
		return parts[1].ToUpper();
	}
}