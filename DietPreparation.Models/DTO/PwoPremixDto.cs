namespace DietPreparation.Models.DTO;
public record PwoPremixDto
{
	public int PwoId { get; init; }
	public int RequestId { get; init; }
	public decimal Amount { get; init; }
	public string AmountUom { get; init; } = string.Empty;
	public int LotYear { get; init; }
	public int LotId { get; init; }
	public string DietName { get; init; } = string.Empty;
}
