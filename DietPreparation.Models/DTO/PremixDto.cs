namespace DietPreparation.Models.DTO;
public record PremixDto
{
	public int? Id { get; init; }
	public string? Name { get; init; }
	public bool IsActive { get; init; }
}
