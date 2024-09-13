using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum Form
{
	[Display(Name = nameof(Resources.EnumResources.Form_Meal), ResourceType = typeof(Resources.EnumResources))]
	Meal = 0,

	[Display(Name = nameof(Resources.EnumResources.Form_Pellet), ResourceType = typeof(Resources.EnumResources))]
	Pellet = 1,

	[Display(Name = nameof(Resources.EnumResources.Form_Liquid), ResourceType = typeof(Resources.EnumResources))]
	Liquid = 2,

	[Display(Name = nameof(Resources.EnumResources.Form_Crumbles), ResourceType = typeof(Resources.EnumResources))]
	Crumbles = 3
}