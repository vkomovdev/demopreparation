namespace DietPreparation.Web.Models.PWOs;
public record PwoDetailViewModel
{
	public PwoHeaderViewModel? Header { get; set; }
	public PwoIngredientViewModel? Ingredients { get; set; }
	public PwoDrugViewModel? Drugs { get; set; }
	public PwoPremixViewModel? Premixes { get; set; }
}
