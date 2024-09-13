namespace DietPreparation.Models.DAO;
public record DrugConcentrationDao
{
	public float ACTIVE_INGREDIENT_CONC { get; init; }
	public string ACTIVE_UOM { get; init; } = string.Empty;
}
