using System.Globalization;

namespace DietPreparation.Common.Consts;
public static class CurrentCulture
{
	public const string CultureName = "en-US";

	private static readonly CultureInfo _culture = CultureInfo.GetCultureInfo(CultureName);

	public static CultureInfo Culture => _culture;
}
