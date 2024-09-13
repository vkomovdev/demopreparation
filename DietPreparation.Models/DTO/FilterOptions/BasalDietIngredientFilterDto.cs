using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;

public record BasalDietIngredientFilterDto : IFilterBy
{
	public int? BasalDietId { get; init; }
}
