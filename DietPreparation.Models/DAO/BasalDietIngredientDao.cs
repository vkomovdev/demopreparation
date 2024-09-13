namespace DietPreparation.Models.DAO;

public record BasalDietIngredientDao
{
	public int? BASAL_DIET_ID { get; init; }
	public int INGREDIENT_ID { get; init; }
	public decimal PERCENT_OF_DIET { get; init; }
}