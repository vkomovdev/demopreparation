using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum RequestType
{
	[DatabaseValue("Complete Diet")]
	[Display(Name = nameof(Resources.EnumResources.RequestType_CompleteDiet), ResourceType = typeof(Resources.EnumResources))]
	CompleteDiet = 0,

	[DatabaseValue("Supplemental Diet")]
	[Display(Name = nameof(Resources.EnumResources.RequestType_SupplementalDiet), ResourceType = typeof(Resources.EnumResources))]
	SupplementalDiet = 1,

	[DatabaseValue("Medicated Pre-Mix")]
	[Display(Name = nameof(Resources.EnumResources.RequestType_MedicatedPremix), ResourceType = typeof(Resources.EnumResources))]
	MedicatedPremix = 2
}