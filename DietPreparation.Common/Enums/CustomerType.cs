using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum CustomerType
{
	[DatabaseValue("REQUESTER")]
	[Display(Name = nameof(Resources.EnumResources.CustomerType_Requester), ResourceType = typeof(Resources.EnumResources))]
	Requester = 0,

	[DatabaseValue("DELIVER_TO")]
	[Display(Name = nameof(Resources.EnumResources.CustomerType_Receiver), ResourceType = typeof(Resources.EnumResources))]
	Receiver = 1,

	[DatabaseValue("BOTH")]
	[Display(Name = nameof(Resources.EnumResources.CustomerType_Both), ResourceType = typeof(Resources.EnumResources))]
	Both = 2
}