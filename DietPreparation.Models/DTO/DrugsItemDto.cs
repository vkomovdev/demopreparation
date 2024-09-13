namespace DietPreparation.Models.DTO;

public record DrugsItemDto : DrugDto
{
	public int TotalItems { get; init; }
}