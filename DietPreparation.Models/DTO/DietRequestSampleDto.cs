using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Models.DTO;
public record DietRequestSampleDto
{
	public int Id { get; set; }
	public int? DietRequestId { get; set; }
	public decimal Amount { get; init; }
	public UnitOfMeasure UnitOfMeasure { get; init; }
	public string Disposition { get; init; } = string.Empty;
	public AnalysisType AnalysisType { get; init; }
	public string Comment { get; init; } = string.Empty;

	public decimal AmountInGrams => Amount * (decimal)UnitOfMeasure.GetConversionRateToGram();
}
