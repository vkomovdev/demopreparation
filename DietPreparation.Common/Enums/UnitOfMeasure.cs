using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum UnitOfMeasure
{
	[ConversionRateToGram(0.001f)]
	[Display(Name = nameof(Resources.EnumResources.UnitOfMeasure_Milligram), ResourceType = typeof(Resources.EnumResources))]
	[DatabaseValue("mg")]
	Milligram = 0,

	[ConversionRateToGram(1)]
	[Display(Name = nameof(Resources.EnumResources.UnitOfMeasure_Gram), ResourceType = typeof(Resources.EnumResources))]
	[DatabaseValue("g")]
	Gram = 1,

	[ConversionRateToGram(1000f)]
	[Display(Name = nameof(Resources.EnumResources.UnitOfMeasure_Kilogram), ResourceType = typeof(Resources.EnumResources))]
	[DatabaseValue("kg")]
	Kilogram = 2,

	[ConversionRateToGram(453.5923706889f)]
	[Display(Name = nameof(Resources.EnumResources.UnitOfMeasure_Pound), ResourceType = typeof(Resources.EnumResources))]
	[DatabaseValue("lbs")]
	Pound = 3
}