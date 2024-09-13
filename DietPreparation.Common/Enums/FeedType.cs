using DietPreparation.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum FeedType
{
	[DatabaseValue("Basal")]
	[Display(Name = nameof(Resources.EnumResources.BaseFeedType_Basal), ResourceType = typeof(Resources.EnumResources))]
	Basal = 0,

	[DatabaseValue("External")]
	[Display(Name = nameof(Resources.EnumResources.BaseFeedType_ExternalInternalFeed), ResourceType = typeof(Resources.EnumResources))]
	External = 1,

	[DatabaseValue("Internal")]
	[Display(Name = nameof(Resources.EnumResources.FeedType_Internal), ResourceType = typeof(Resources.EnumResources))]
	Internal = 2
}