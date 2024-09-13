using DietPreparation.Web.Models.Metadata;

namespace DietPreparation.Web.Models.BasalDiets;

public class EditBasalDietViewModel
{
	public int? Id { get; set; }
	public string? Code { get; set; } = string.Empty;
	public string? Name { get; set; } = string.Empty;
	public DateTime? DateCreate { get; set; } = DateTime.Now.Date;
	public string? CreatedBy { get; set; } = string.Empty;
	public bool IsLocked { get; set; }

	public IEnumerable<BasalDietIngredientViewModel>? BasalDietIngredients { get; set; } = new BasalDietIngredientViewModel[0];

	public IEnumerable<MetadataIngredient>? Ingredients { get; set; }

	public bool Print { get; set; }
}