namespace DietPreparation.Models.DTO;
public record PwoIngredientDto
{
	public int PwoId { get; init; }
	public string IngredientName { get; init; } = string.Empty;
	public decimal Amount { get; init; }
	public string AmountUom { get; init; } = string.Empty;
}
