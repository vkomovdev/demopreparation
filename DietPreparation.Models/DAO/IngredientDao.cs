namespace DietPreparation.Models.DAO;

public record IngredientDao
{
	public int INGREDIENT_ID { get; init; }
	public string INGREDIENT_NAME { get; init; } = string.Empty;
	public bool LOCK { get; init; }
}