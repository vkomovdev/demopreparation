using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests;

public class SectionDrug
{
	public int? Id { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DrugName), ResourceType = typeof(Resources.ContentResources))]
	public string? Name { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DrugConcentration), ResourceType = typeof(Resources.ContentResources))]
	public float? ActiveIngredientConcentration { get; set; }

	[Display(Name = nameof(Resources.ContentResources.DrugConcentration), ResourceType = typeof(Resources.ContentResources))]
	public ConcentrationUnitOfMeasure? UnitOfMeasure { get; set; }

	public bool? IsActive { get; set; }

	public bool? IsLocked { get; set; }

	public string ActiveIngredientConcentrationWithUnitOfMeasure => $"{ActiveIngredientConcentration}{(UnitOfMeasure.HasValue ? $" {UnitOfMeasure.Value.GetDisplayName()}" : string.Empty)}";
}
