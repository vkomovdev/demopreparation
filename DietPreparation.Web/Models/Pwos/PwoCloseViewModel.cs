using DietPreparation.Common.Consts;
using DietPreparation.Resources;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.PWOs;

public class PwoCloseViewModel
{
	public int Sequence { get; set; }

	public int RequestId { get; set; }

	[Display(Name = nameof(ContentResources.Mixer), ResourceType = typeof(ContentResources))]
	public string? Mixer { get; set; }

	[Display(Name = nameof(ContentResources.TimeCompleted), ResourceType = typeof(ContentResources))]
	public string? TimeCompleted { get; set; }

	[Display(Name = nameof(ContentResources.Location), ResourceType = typeof(ContentResources))]
	public List<string>? Location { get; set; } = Locations.PwoCloseLocations.ToList();

	[Display(Name = nameof(ContentResources.DateCompleted), ResourceType = typeof(ContentResources))]
	public DateTime? DateCompleted { get; set; }

	[Display(Name = nameof(ContentResources.CompletedBy), ResourceType = typeof(ContentResources))]
	public string? CompletedBy { get; set; }

	[Display(Name = nameof(ContentResources.BagCount), ResourceType = typeof(ContentResources))]
	public int? BagCount { get; set; }

	[Display(Name = nameof(ContentResources.Comment), ResourceType = typeof(ContentResources))]
	public string? Comment { get; set; }

	public int? PwoId { get; set; }

	public string? LocationManual { get; set; }
}