namespace DietPreparation.Models.DTO;

public record LocationUpdateDto
{
	public int Id { get; set; } = 0;
	public string Description { get; init; } = string.Empty;
	public string Building { get; init; } = string.Empty;
	public string? Floor { get; init; } = string.Empty;
	public string? Lab { get; init; } = string.Empty;
	public int? BusinessUnit { get; init; }
	public bool IsLocked { get; init; }
}