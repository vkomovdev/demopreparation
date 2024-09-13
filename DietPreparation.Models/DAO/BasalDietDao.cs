namespace DietPreparation.Models.DAO;
public record BasalDietDao
{
	public int BASAL_DIET_ID { get; init; }
	public string? BASAL_DIET_CODE { get; init; } = string.Empty;
	public string? BASAL_DIET_NAME { get; init; } = string.Empty;
	public DateTime CREATE_DATE { get; init; }
	public string CREATE_NAME { get; init; } = string.Empty;
	public bool LOCK { get; init; }

	public int TotalItems { get; init; }
	public IEnumerable<BasalDietIngredientDao>? BasalDietIngredients { get; init; }
}
