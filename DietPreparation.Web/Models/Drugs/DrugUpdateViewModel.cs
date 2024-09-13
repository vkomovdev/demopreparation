using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.Drugs;

public class DrugUpdateViewModel
{
	public int? Id { get; set; }
	public string? UserId { get; set; }
	public string? Name { get; set; }
	public string? ActiveIngredientConcentration { get; set; }

	public string? CreatedAt { get; set; } = DateTime.Now.ToString(FormatStrings.NetDateFormat);
	public bool IsLocked { get; init; }
	public ConcentrationUnitOfMeasure UnitOfMeasure { get; set; } = ConcentrationUnitOfMeasure.GramOnTon;
}