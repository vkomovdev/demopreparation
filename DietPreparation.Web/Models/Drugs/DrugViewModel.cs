using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.Drugs;

public class DrugViewModel
{
	public int? Id { get; init; }

	[Display(Name = nameof(Resources.ContentResources.DrugName), ResourceType = typeof(Resources.ContentResources))]
	public string? Name { get; init; }

	[Display(Name = nameof(Resources.ContentResources.DrugConcentration), ResourceType = typeof(Resources.ContentResources))]
	public string? ActiveIngredientConcentration { get; init; }
	
	public string? UnitOfMeasure { get; init; }
	
	public string? CreateDate { get; init; }
	public string? CreateName { get; init; }

	public bool? IsActive { get; init; }

	public bool? IsLocked { get; init; }
}