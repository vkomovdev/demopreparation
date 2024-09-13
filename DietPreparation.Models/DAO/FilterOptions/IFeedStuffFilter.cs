using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DAO.FilterOptions;

public interface IFeedStuffFilter : IFilterBy
{
	public DateTime? DateStart { get; set; }
	public DateTime? DateEnd { get; set; }
	public int? IngredientId { get; set; }
}
