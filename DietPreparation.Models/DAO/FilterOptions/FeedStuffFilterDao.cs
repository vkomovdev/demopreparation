namespace DietPreparation.Models.DAO.FilterOptions;
public record FeedStuffFilterDao : IFeedStuffFilter
{
	public DateTime? DateStart { get; set; }
	public DateTime? DateEnd { get; set; }
	public int? IngredientId { get; set; }
}
