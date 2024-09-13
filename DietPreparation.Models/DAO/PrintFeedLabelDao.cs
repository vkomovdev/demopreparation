namespace DietPreparation.Models.DAO;

public record PrintFeedLabelDao
{
	public int PWO_ID { get; init; }
	public DateTime? EXPIRES { get; init; }
	public string COMMENT1 { get; init; } = string.Empty;
	public string COMMENT2 { get; init; } = string.Empty;
	public int QUANTITY { get; init; }
}