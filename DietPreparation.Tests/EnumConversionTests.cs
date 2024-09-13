using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Tests;

[TestFixture]
public class EnumConversionTests
{
	private static IEnumerable<TestCaseData> UnitOfMeasureTestCases()
	{
		yield return new TestCaseData("mg", UnitOfMeasure.Milligram);
		yield return new TestCaseData("g", UnitOfMeasure.Gram);
		yield return new TestCaseData("kg", UnitOfMeasure.Kilogram);
		yield return new TestCaseData("lbs", UnitOfMeasure.Pound);
	}

	[TestCaseSource(nameof(UnitOfMeasureTestCases))]
	public void Convert_String_ReturnsUnitOfMeasure(string input, UnitOfMeasure expected)
	{
		var result = input.GetEnum<UnitOfMeasure>();
		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCaseSource(nameof(UnitOfMeasureTestCases))]
	public void Convert_UnitOfMeasure_ReturnsString(string expected, UnitOfMeasure input)
	{
		var result = input.GetDisplayName();
		Assert.That(result, Is.EqualTo(expected));
	}

	private static IEnumerable<TestCaseData> ConcentrationUnitOfMeasureTestCases()
	{
		yield return new TestCaseData("g/ton", ConcentrationUnitOfMeasure.GramOnTon);
		yield return new TestCaseData("mg/kg", ConcentrationUnitOfMeasure.MilligramOnKilogram);
		yield return new TestCaseData("mg/lb", ConcentrationUnitOfMeasure.MilligramOnPound);
	}

	[TestCaseSource(nameof(ConcentrationUnitOfMeasureTestCases))]
	public void Convert_String_ReturnsConcentrationUnitOfMeasure(string input, ConcentrationUnitOfMeasure expected)
	{
		var result = input.GetEnum<ConcentrationUnitOfMeasure>();
		Assert.That(result, Is.EqualTo(expected));
	}

	[TestCaseSource(nameof(ConcentrationUnitOfMeasureTestCases))]
	public void Convert_ConcentrationUnitOfMeasure_ReturnsString(string expected, ConcentrationUnitOfMeasure input)
	{
		var result = input.GetDisplayName();
		Assert.That(result, Is.EqualTo(expected));
	}
}