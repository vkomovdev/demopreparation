namespace DietPreparation.Models.DTO;
public record PwoHeaderDto
{
	public CustomerDto? Customer { get; init; }
	public DietRequestDto? DietRequest { get; init; }
	public PwoDto? PwoDto { get; init; }
}
