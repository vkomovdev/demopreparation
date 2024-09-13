using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests.Rows;

public class DietRequestSample
{
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? Amount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }
	public string? Disposition { get; set; }
	public AnalysisType? AnalysisType { get; set; }
	public string? Comment { get; set; }
}