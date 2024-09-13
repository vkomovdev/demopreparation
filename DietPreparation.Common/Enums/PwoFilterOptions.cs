using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;

public enum PwoFilterOptions
{
	[Display(Name = "OPEN")]
	Open,

	[Display(Name = "CLOSED")]
	Closed,

	[Display(Name = "PRINTED")]
	Printed
}