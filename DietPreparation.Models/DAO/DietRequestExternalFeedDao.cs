namespace DietPreparation.Models.DAO;

public record DietRequestExternalFeedDao
{
	public int RECORD_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public string? SUPPLIER_NAME { get; init; }
	public string? LOT_NUMBER { get; init; }
}