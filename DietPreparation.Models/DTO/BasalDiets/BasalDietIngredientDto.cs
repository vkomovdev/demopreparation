using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Models.DTO.BasalDiets;

public record BasalDietIngredientDto : IBasalDietIngredientFilter
{
	public int? BasalDietId { get; set; }
	public int? IngredientId { get; init; }
	public decimal PercentOfDiet { get; init; }
}
