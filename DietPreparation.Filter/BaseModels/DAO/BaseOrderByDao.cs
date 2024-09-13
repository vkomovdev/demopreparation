using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.BaseModels.DAO;

public record BaseOrderByDao : IOrderByDao
{
	public string ORDER_BY { get; set; } = string.Empty;
}