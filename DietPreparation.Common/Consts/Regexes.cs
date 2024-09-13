namespace DietPreparation.Common.Consts;
public static class Regexes
{
	public const string CharsAndNumbers = "^[A-Z0-9]*$";
	public const string StudyNumber = "[A-Z0-9]{5}-[A-Z0-9]{2}-[A-Z0-9]{2}-[A-Z0-9]{3}";
	public const string ProjectNumber = "[A-Z0-9]{10}";
	public const string NumbersOrRangesPattern = @"^([1-9]\d*((-\d+)?(,|$)))+$";
}
