namespace DietPreparation.Models.DAO;

public record FeedStuffDao
{
	public int INGREDIENT_ID { get; init; }

	public string? INGREDIENT_NAME { get; init; }

	public bool LOCK { get; init; }
}