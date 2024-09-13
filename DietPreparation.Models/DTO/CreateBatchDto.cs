using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;
public record CreateBatchDto
{
	public int RequestId { get; init; }
	public List<int> BatchSize { get; init; } = new List<int>();
	public List<int> BatchNumbers { get; init; } = new List<int>();
	public FeedType FeedType { get; init; }
	public int FeedId { get; init; }
	public string Operator { get; init; } = string.Empty;//planner in db
	public UnitOfMeasure BatchUom { get; init; }
	public decimal BatchWeight { get; init; }
}
