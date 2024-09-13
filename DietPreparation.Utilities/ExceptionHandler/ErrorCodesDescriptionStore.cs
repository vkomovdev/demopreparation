using DietPreparation.Common.Extensions;
using DietPreparation.Resources;
using System.Globalization;

namespace DietPreparation.Utilities.ExceptionHandler
{
	public static class ErrorCodesDescriptionStore
	{
		public static string? GetDescription(Enum value) => GetDescription(value.GetNumberAsString());

		public static string? GetDescription(string value) =>
			ErrorCodesDescription.ResourceManager.GetString(value, CultureInfo.InvariantCulture);
	}
}