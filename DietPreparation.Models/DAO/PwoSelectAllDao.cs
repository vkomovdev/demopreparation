namespace DietPreparation.Models.DAO;
public record PwoSelectAllDao
{
	public int PWO_ID { get; init; }
	public int REQUEST_ID { get; init; }
	public decimal AMOUNT { get; init; }
	public string AMOUNT_UOM { get; init; } = string.Empty;
	public int LOT_YEAR { get; init; }
	public int LOT_ID { get; init; }
	public string DIET_NAME { get; init; } = string.Empty;
	public string FIRST_NAME { get; init; } = string.Empty;
	public string LAST_NAME { get; init; } = string.Empty;
	public int SEQUENCE { get; init; }
	public decimal REQUEST_AMOUNT { get; init; }
	public string REQUEST_UOM { get; init; } = string.Empty;
	public string FEED_TYPE { get; init; } = string.Empty;
	public int FEED_ID { get; init; }
	public decimal BATCH_WEIGHT { get; init; }
	public string BATCH_UOM { get; init; } = string.Empty;
}
