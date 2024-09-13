using DietPreparation.Models.DTO.BasalDiets;

namespace DietPreparation.Models.DTO;

public record BasalDietDto
{
	public int Id { get; set; }
	public string Code { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public DateTime DateCreate { get; init; }
	public string CreatedBy { get; init; } = string.Empty;
	public bool IsLocked { get; init; }

	public int TotalItems { get; init; }
	public IEnumerable<BasalDietIngredientDto>? BasalDietIngredients { get; init; }
}
