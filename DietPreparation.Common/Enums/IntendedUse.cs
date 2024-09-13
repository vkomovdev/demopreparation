using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum IntendedUse
{
	[Display(Name = nameof(Resources.EnumResources.IntendedUse_Internal), ResourceType = typeof(Resources.EnumResources))]
	Internal = 0,

	[Display(Name = nameof(Resources.EnumResources.IntendedUse_External), ResourceType = typeof(Resources.EnumResources))]
	External = 1
}