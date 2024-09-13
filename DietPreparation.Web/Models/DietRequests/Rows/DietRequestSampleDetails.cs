using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests.Rows;

public class DietRequestSampleDetails
{
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? Amount { get; init; }

	public UnitOfMeasure? UnitOfMeasure { get; init; }

	public string? Disposition { get; init; }

	public AnalysisType? AnalysisType { get; init; }

	public string? Comment { get; init; }
}