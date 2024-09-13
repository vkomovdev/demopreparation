using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum DietRequestFilterOptions
{
	[Display(Name = "OPEN")]
	Open,

	[Display(Name = "CLONED")]
	Cloned,

	[Display(Name = "ALL")]
	All,

	[Display(Name = "ALL PAST")]
	AllPast,
}