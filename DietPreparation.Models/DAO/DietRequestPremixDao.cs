namespace DietPreparation.Models.DAO;

public record DietRequestPremixDao
{
	public int RECORD_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public int? PREMIX_ID { get; init; }
	public decimal? AMOUNT { get; init; }
	public string? AMOUNT_UOM { get; init; }
	public bool? PREMIX_IN_WEIGHT { get; init; }
}
