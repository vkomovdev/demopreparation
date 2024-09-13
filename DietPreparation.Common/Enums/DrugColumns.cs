using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum DrugColumns
{
	[Display(Name = "DRUG_ID")]
	DrugId,
	[Display(Name = "DRUG_NAME")]
	DrugName,
	[Display(Name = "ACTIVE_INGREDIENT_CONC")]
	ActiveIngredientConc,
	[Display(Name = "ACTIVE_UOM")]
	ActiveUom,
	[Display(Name = "CREATE_DATE")]
	CreateDate,
	[Display(Name = "CREATE_NAME")]
	CreateName,
	[Display(Name = "LOCK")]
	Lock
}