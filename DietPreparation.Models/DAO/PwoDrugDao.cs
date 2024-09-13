namespace DietPreparation.Models.DAO;

public record PwoDrugDao
{
	public int PWO_ID { get; init; }
	public string MFG_LOT { get; init; } = string.Empty;
	public decimal AMOUNT { get; init; }
	public string AMOUNT_UOM { get; init; } = string.Empty;
	public decimal CONC { get; init; }
	public decimal CONC_IN_BATCH { get; init; }
	public string CONC_UOM { get; init; } = string.Empty;
	public string DRUG_NAME { get; init; } = string.Empty;
}