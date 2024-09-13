using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum StudyType
{
	[Display(Name = nameof(Resources.EnumResources.StudyType_Gcp), ResourceType = typeof(Resources.EnumResources))]
	Gcp = 0,

	[Display(Name = nameof(Resources.EnumResources.StudyType_Glp), ResourceType = typeof(Resources.EnumResources))]
	Glp = 1,

	[Display(Name = nameof(Resources.EnumResources.StudyType_NonGxp), ResourceType = typeof(Resources.EnumResources))]
	NonGxp = 2
}