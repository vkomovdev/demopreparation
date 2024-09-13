namespace DietPreparation.Models.DAO.DietRequests;

public record DietRequestUpsertResultDao
{
	public int REQUEST_ID { get; init; }
	public int? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
}