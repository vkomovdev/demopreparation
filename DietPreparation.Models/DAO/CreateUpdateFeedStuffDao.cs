namespace DietPreparation.Models.DAO;

public record CreateUpdateFeedStuffDao
{
	public string INGREDIENT_ID { get; set; } = string.Empty;

	public string INGREDIENT_NAME { get; init; } = string.Empty;

	public bool LOCK { get; init; } = false;
}