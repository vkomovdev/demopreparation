namespace DietPreparation.Common.Extensions;
public static class GenericExtensions
{
	/// <returns><see langword="true"/> if array contains the value</returns>
	public static bool In<T>(this T value, params T[] array)
	{
		if (array == null || !array.Any())
			return false;

		return array.Contains(value);
	}
}
