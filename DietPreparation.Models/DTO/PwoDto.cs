namespace DietPreparation.Models.DTO;
public record PwoDto
{
	public int PwoId { get; init; }
	public string Mixed { get; init; } = string.Empty;
	public string Location { get; init; } = string.Empty;
	public string ComletedTime { get; init; } = string.Empty;
	public DateTime CompletedDate { get; init; }
	public string CompletedBy { get; init; } = string.Empty;
	public string Comment { get; init; } = string.Empty;
	public int BagCount { get; init; }
	public string Planner { get; init; } = string.Empty;
	public decimal BatchWeight { get; init; }
	public string BatchUom { get; init; } = string.Empty;
	public int Sequence { get; init; }
	public bool IsClosed { get; init; }
	public bool IsPrinted { get; init; }
}
