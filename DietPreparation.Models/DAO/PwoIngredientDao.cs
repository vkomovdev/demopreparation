namespace DietPreparation.Models.DAO;

public record PwoIngredientDao
{
	public int PWO_ID { get; init; }
	public string INGREDIENT_NAME { get; init; } = string.Empty;
	public decimal AMOUNT { get; init; }
	public string AMOUNT_UOM { get; init; } = string.Empty;
}