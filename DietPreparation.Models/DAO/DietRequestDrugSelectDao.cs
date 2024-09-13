namespace DietPreparation.Models.DAO;

public record DietRequestDrugSelectDao : DietRequestDrugDao
{
	public string? DRUG_NAME { get; init; }
	public decimal? ACTIVE_INGREDIENT_CONC { get; init; }
	public string? ACTIVE_UOM { get; init; }
}