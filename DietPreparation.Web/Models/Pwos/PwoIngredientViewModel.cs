using DietPreparation.Common.Consts;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.PWOs;

public class PwoIngredientViewModel
{
	[Display(Name = nameof(Resources.ContentResources.Ingredients), ResourceType = typeof(Resources.ContentResources))]
	public IEnumerable<PwoIngredientModel>? Ingredients { get; set; }

	[Display(Name = nameof(Resources.ContentResources.BatchOum), ResourceType = typeof(Resources.ContentResources))]
	public string? BatchOum => Ingredients is null || !Ingredients.Any() ? "" : Ingredients.First().AmountUom;

	[Display(Name = nameof(Resources.ContentResources.TotalIngredients), ResourceType = typeof(Resources.ContentResources))]
	public decimal TotalIngredients => Ingredients is null ? 0 : Ingredients.Sum(x => Math.Round(x.Amount.HasValue ? x.Amount.Value : 0, DefaultNumbers.DecimalDigitsCount));
}
