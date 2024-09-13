namespace DietPreparation.Web.Models.PWOs;

public class PwoIngredientModel
{
	public int? PwoId { get; set; }
	public string? IngredientName { get; set; }
	public decimal? Amount { get; set; }
	public string? AmountUom { get; set; }
}