namespace DietPreparation.Models.DAO;

public record DietRequestInternalFeedDao
{
	public int RECORD_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public int? LOT_NUMBER_ID { get; init; }
	public int? SEQUENCE_NUMBER { get; init; }
}