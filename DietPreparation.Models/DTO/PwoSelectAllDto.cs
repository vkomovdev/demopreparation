namespace DietPreparation.Models.DTO;
public record PwoSelectAllDto
{
	public int PwoId { get; init; }
	public int RequestId { get; init; }
	public decimal Amoun { get; init; }
	public string AmountUom { get; init; } = string.Empty;
	public int LotYear { get; init; }
	public int LotId { get; init; }
	public string DietName { get; init; } = string.Empty;
	public string FirstName { get; init; } = string.Empty;
	public string LastName { get; init; } = string.Empty;
	public int Sequence { get; init; }
	public decimal RequestAmoun { get; init; }
	public string RequestUom { get; init; } = string.Empty;
	public string FeedType { get; init; } = string.Empty;
	public int FeedId { get; init; }
	public decimal BatchWeight { get; init; }
	public string BatchUom { get; init; } = string.Empty;
}
