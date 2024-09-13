namespace DietPreparation.Models.DAO;

public record FeedStuffReportDao
{
	public int Ingredient_ID { get; set; }
	public string Ingredient_Name { get; set; }
	public decimal Amount { get; set; }
	public string Amount_UoM { get; set; }
	public int TotalItems { get; set; }
}