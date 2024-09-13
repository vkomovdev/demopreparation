using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum AnalysisType
{
	[Display(Name = nameof(Resources.EnumResources.AnalysisType_NutrientAnalysis), ResourceType = typeof(Resources.EnumResources))]
	NutrientAnalysis = 0,

	[Display(Name = nameof(Resources.EnumResources.AnalysisType_AntibioticScreen), ResourceType = typeof(Resources.EnumResources))]
	AntibioticScreen = 1,

	[Display(Name = nameof(Resources.EnumResources.AnalysisType_RetainerSample), ResourceType = typeof(Resources.EnumResources))]
	RetainerSample = 2,

	[Display(Name = nameof(Resources.EnumResources.AnalysisType_Other), ResourceType = typeof(Resources.EnumResources))]
	Other = 3
}