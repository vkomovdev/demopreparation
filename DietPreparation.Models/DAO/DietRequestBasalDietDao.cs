namespace DietPreparation.Models.DAO;

public record DietRequestBasalDietDao
{
	public int RECORD_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public int? BASAL_DIET_ID { get; init; }
}
