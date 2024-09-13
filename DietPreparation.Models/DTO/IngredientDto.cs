namespace DietPreparation.Models.DTO;

public record IngredientDto
{
	public int Id { get; init; }
	public string Name { get; init; } = string.Empty;
	public bool IsLocked { get; init; }
}