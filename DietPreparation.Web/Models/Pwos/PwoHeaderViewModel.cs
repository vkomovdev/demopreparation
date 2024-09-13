using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.PWOs;

public class PwoHeaderViewModel
{
	public int RequestId { get; set; }
	public int PwoId { get; set; }

	[Display(Name = nameof(Resources.ContentResources.Lot), ResourceType = typeof(Resources.ContentResources))]
	public string? Lot { get; set; } = string.Empty;

	[Display(Name = nameof(Resources.ContentResources.RequestedBy), ResourceType = typeof(Resources.ContentResources))]
	public string? CustomerName { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DateCreated), ResourceType = typeof(Resources.ContentResources))]
	public string? DateRequestFormatted { get; set; }

	[Display(Name = nameof(Resources.ContentResources.Sequence), ResourceType = typeof(Resources.ContentResources))]
	public int? Sequence { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DateNeeded), ResourceType = typeof(Resources.ContentResources))]
	public string? DateNeededFormatted { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DietName), ResourceType = typeof(Resources.ContentResources))]
	public string? DietName { get; set; }

	[Display(Name = nameof(Resources.ContentResources.ParckingInstructions), ResourceType = typeof(Resources.ContentResources))]
	public string? ParckingInstructions { get; set; }

	[Display(Name = nameof(Resources.ContentResources.MixingInstructions), ResourceType = typeof(Resources.ContentResources))]
	public string? MixingInstructions { get; set; }

	[Display(Name = nameof(Resources.ContentResources.BatchAmount), ResourceType = typeof(Resources.ContentResources))]
	public string? BatchAmount { get; set; }

	public string CompletedBy { get; set; }
}
