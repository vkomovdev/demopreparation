using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.PWOs;

public class BatchItem
{
	public UnitOfMeasure BatchUom { get; set; }
	public decimal BatchWeight { get; set; }
	public int Sequence { get; set; }
}