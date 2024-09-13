using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.FilterOptions;
public record FeedStuffPlanningFilterDto : IFilterBy
{
	public DateTime? DateStart { get; init; }
	public DateTime? DateEnd { get; init; }
	public int? IngredientId { get; init; }
}
