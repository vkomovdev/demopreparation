using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum ConcentrationUnitOfMeasure
{
	[Display(Name = nameof(Resources.EnumResources.ConcentrationUnitOfMeasure_GramOnTon), ResourceType = typeof(Resources.EnumResources))]
	GramOnTon = 0,

	[Display(Name = nameof(Resources.EnumResources.ConcentrationUnitOfMeasure_MilligramOnKilogram), ResourceType = typeof(Resources.EnumResources))]
	MilligramOnKilogram = 1,

	[Display(Name = nameof(Resources.EnumResources.ConcentrationUnitOfMeasure_MilligramOnPounds), ResourceType = typeof(Resources.EnumResources))]
	MilligramOnPound = 2
}