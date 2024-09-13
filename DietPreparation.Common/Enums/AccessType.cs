using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum AccessType
{
	[Display(Name = nameof(Resources.EnumResources.AccessType_Disabled), ResourceType = typeof(Resources.EnumResources))]
	Disabled = 0,

	[Display(Name = nameof(Resources.EnumResources.AccessType_User), ResourceType = typeof(Resources.EnumResources))]
	User = 1,

	[Display(Name = nameof(Resources.EnumResources.AccessType_OrderOnly), ResourceType = typeof(Resources.EnumResources))]
	OrderOnly = 10,

	[Display(Name = nameof(Resources.EnumResources.AccessType_Admin), ResourceType = typeof(Resources.EnumResources))]
	Admin = 15
}