using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.PWOs;

public class PwoBatchListViewModel
{
	public int RequestId { get; set; }
	[Display(Name = nameof(Resources.ContentResources.Lot), ResourceType = typeof(Resources.ContentResources))]
	public string Lot { get; set; } = string.Empty;
	[Display(Name = nameof(Resources.ContentResources.RequestedBy), ResourceType = typeof(Resources.ContentResources))]
	public string CustomerName { get; set; } = string.Empty;
	[Display(Name = nameof(Resources.ContentResources.DietName), ResourceType = typeof(Resources.ContentResources))]
	public string DietName { get; set; } = string.Empty;
	public List<BatchItem>? Batches { get; set; }
}