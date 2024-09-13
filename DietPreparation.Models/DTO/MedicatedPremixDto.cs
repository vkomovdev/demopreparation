namespace DietPreparation.Models.DTO;

public record MedicatedPremixDto
{
	public int Id { get; init; }
	public int? LotYear { get; init; }
	public int? LotId { get; init; }
	public string? Name { get; init; }
	public bool IsDeleted { get; init; } = false;
	public bool? PremixUsed { get; init; }
}