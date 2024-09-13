using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Tests;

public class Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void StringToEnumTest()
	{
		var milligram = UnitOfMeasure.Milligram;
		var gram = UnitOfMeasure.Gram;
		var kilogram = UnitOfMeasure.Kilogram;
		var pound = UnitOfMeasure.Pound;
		var gramOnTon = ConcentrationUnitOfMeasure.GramOnTon;
		var milligramOnKilogram = ConcentrationUnitOfMeasure.MilligramOnKilogram;
		var milligramOnPound = ConcentrationUnitOfMeasure.MilligramOnPound;

		var milligramString = "mg";
		var gramString = "g";
		var kilogramString = "kg";
		var poundString = "lbs";
		var gramOnTonString = "g/ton";
		var milligramOnKilogramString = "mg/kg";
		var milligramOnPoundString = "mg/lb";

		var mg = milligram.GetDisplayName();

		Assert.AreEqual(milligram, milligramString.GetEnum<UnitOfMeasure>());
		Assert.AreEqual(gram, gramString.GetEnum<UnitOfMeasure>());
		Assert.AreEqual(kilogram, kilogramString.GetEnum<UnitOfMeasure>());
		Assert.AreEqual(pound, poundString.GetEnum<UnitOfMeasure>());
		Assert.AreEqual(gramOnTon, gramOnTonString.GetEnum<ConcentrationUnitOfMeasure>());
		Assert.AreEqual(milligramOnKilogram, milligramOnKilogramString.GetEnum<ConcentrationUnitOfMeasure>());
		Assert.AreEqual(milligramOnPound, milligramOnPoundString.GetEnum<ConcentrationUnitOfMeasure>());
	}
}