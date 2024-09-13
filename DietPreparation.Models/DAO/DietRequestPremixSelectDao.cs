namespace DietPreparation.Models.DAO;

public record DietRequestPremixSelectDao : DietRequestPremixDao
{
	public string? DIET_NAME { get; init; }
	public int? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
}