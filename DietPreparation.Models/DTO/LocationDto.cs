
namespace DietPreparation.Models.DTO;

public record LocationDto
{
	public int Id { get; set; }

	public string Description { get; init; } = string.Empty;

	public string Building { get; init; } = string.Empty;

	public string? Floor { get; init; } = string.Empty;

	public string? Lab { get; init; } = string.Empty;

	public int? BusinessUnit { get; init; }

	public bool IsLocked { get; init; }

	public string GetFullName()
	{
		return $"{Description} - {Building} - {Floor} - {Lab}";
	}
}