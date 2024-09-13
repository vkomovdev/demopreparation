using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum PwoConfirmType
{
	[Display(Name = nameof(Resources.EnumResources.PwoConfirmType_Pwo), ResourceType = typeof(Resources.EnumResources))]
	Pwo = 0,

	[Display(Name = nameof(Resources.EnumResources.PwoConfirmType_Label), ResourceType = typeof(Resources.EnumResources))]
	Label = 1
}