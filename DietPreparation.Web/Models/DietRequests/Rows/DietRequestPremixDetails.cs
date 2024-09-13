using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests.Rows;

public class DietRequestPremixDetails
{
	public string? PremixName { get; init; }
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? Amount { get; init; }
	public UnitOfMeasure? UnitOfMeasure { get; init; }
	public bool IncludedInWeight { get; init; }
}