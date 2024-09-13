using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum HazardType
{
	[Display(Name = nameof(Resources.EnumResources.HazardType_Known), ResourceType = typeof(Resources.EnumResources))]
	Known = 0,

	[Display(Name = nameof(Resources.EnumResources.HazardType_Unknown), ResourceType = typeof(Resources.EnumResources))]
	Unknown = 1,

	[Display(Name = nameof(Resources.EnumResources.HazardType_Nonhazardous), ResourceType = typeof(Resources.EnumResources))]
	Nonhazardous = 2
}