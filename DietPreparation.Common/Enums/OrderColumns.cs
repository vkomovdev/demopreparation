using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Common.Enums;
public enum OrderColumns
{
	[Display(Name = "DATE_REQUEST")]
	DATEREQUEST,

	[Display(Name = "DIET_NAME")]
	DIETNAME,

	[Display(Name = "REQUEST_AMOUNT")]
	REQUESTAMOUNT,

	[Display(Name = "REQUEST_UOM")]
	UNITOFMEASURE,

	[Display(Name = "LOT")]
	LOT
}
