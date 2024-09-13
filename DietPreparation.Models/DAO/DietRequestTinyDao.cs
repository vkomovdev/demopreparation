namespace DietPreparation.Models.DAO;

public record DietRequestTinyDao
{
	public int REQUEST_ID { get; init; }
	public string? DIET_NAME { get; init; }
	public int? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
}