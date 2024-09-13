using DietPreparation.Common.Consts;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests;

public class DietRequestSearchItem
{
	public int? Id { get; init; }

	public string? Lot { get; init; }
	public string? Requestor { get; init; }
	public string? Receiver { get; init; }
	public string? DateRequest { get; init; }
	public string? DateNeeded { get; init; }
	public string? Name { get; init; }

	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? RequestAmount { get; init; }
	public string? UnitOfMeasure { get; init; }

	public bool? IsLocked { get; init; } = false;
	public bool? IsDeleted { get; init; } = false;
	public bool? UsedAsTemplate { get; init; } = false;
}