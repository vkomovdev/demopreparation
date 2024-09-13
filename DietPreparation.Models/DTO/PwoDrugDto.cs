namespace DietPreparation.Models.DTO;

public record PwoDrugDto
{
	public int PwoId { get; init; }
	public string MFGLot { get; init; } = string.Empty;
	public decimal Amount { get; init; }
	public string AmountUom { get; init; } = string.Empty;
	public decimal Conc { get; init; }
	public decimal ConcInBatch { get; init; }
	public string ConcUom { get; init; } = string.Empty;
	public string DrugName { get; init; } = string.Empty;
}