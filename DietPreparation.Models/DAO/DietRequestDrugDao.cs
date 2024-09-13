namespace DietPreparation.Models.DAO;
public record DietRequestDrugDao
{
	public int RECORD_ID { get; init; }
	public int? DRUG_ID { get; init; }
	public int? REQUEST_ID { get; init; }
	public decimal? AMOUNT { get; init; }
	public string? AMOUNT_UOM { get; init; }
	public bool? DRUG_IN_WEIGHT { get; init; }
	public string? MFG_LOT { get; init; }
}
