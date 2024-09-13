namespace DietPreparation.Models.DAO;

public record DrugDao
{
	public int DRUG_ID { get; init; }
	public string DRUG_NAME { get; init; } = string.Empty;
	public float ACTIVE_INGREDIENT_CONC { get; init; }
	public string ACTIVE_UOM { get; init; } = string.Empty;
	public DateTime CREATE_DATE { get; init; }
	public string CREATE_NAME { get; init; } = string.Empty;
	public bool LOCK { get; init; }
}