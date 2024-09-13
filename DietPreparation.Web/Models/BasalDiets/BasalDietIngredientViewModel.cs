using DietPreparation.Web.Models.Metadata;

namespace DietPreparation.Web.Models.BasalDiets;

public record BasalDietIngredientViewModel
{
	public int? IngredientId { get; init; }
	public decimal? PercentOfDiet { get; init; }
	public IEnumerable<MetadataIngredient>? Ingredients { get; set; }
}
