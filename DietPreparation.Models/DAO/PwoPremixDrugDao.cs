namespace DietPreparation.Models.DAO;

public record PwoPremixDrugDao
{
	public int PWO_ID { get; init; }
	public decimal CONC_IN_BATCH { get; init; }
	public string CONC_UOM { get; init; } = string.Empty;
	public string MFG_LOT { get; init; } = string.Empty;
	public string DRUG_NAME { get; init; } = string.Empty;
}