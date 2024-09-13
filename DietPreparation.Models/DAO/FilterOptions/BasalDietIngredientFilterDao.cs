namespace DietPreparation.Models.DAO.FilterOptions;

public record BasalDietIngredientFilterDao : IBasalDietIngredientFilter
{
	public int? BasalDietId { get; set; }
}