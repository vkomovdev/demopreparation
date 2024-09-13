using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.PWOs;

public class PwoSearchRowItem
{
	public int Id { get; set; }
	public string Lot { get; set; }
	public string Requestor { get; set; }
	public string? DateRequest { get; set; }
	public string DietName { get; set; }
	public decimal RequestAmount { get; set; }
	public string UnitOfMeasure { get; set; }
	public bool IsClosed { get; set; }
	public bool IsPrinted { get; set; }
	public int Sequence { get; set; }
	public int TotalCount { get; set; }
}
