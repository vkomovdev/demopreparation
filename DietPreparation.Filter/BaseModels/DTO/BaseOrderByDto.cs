using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.BaseModels.DTO;

public record BaseOrderByDto : IOrderBy
{
	public string? Column { get; set; }
	public string? Slope { get; set; }
}