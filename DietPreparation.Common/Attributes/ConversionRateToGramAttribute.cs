namespace DietPreparation.Common.Attributes;

public class ConversionRateToGramAttribute : Attribute
{
	public ConversionRateToGramAttribute(float conversionRate) : base()
	{
		ConversionRate = conversionRate;
	}

	public float ConversionRate { get; }
}