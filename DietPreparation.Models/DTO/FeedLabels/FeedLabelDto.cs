using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.FeedLabels;

public record FeedLabelDto
{
	public int Id { get; init; }
	public string? LotNumber => $"{LotYear}-{LotId}-{Sequence}";
	public string? ProjectNumber { get; set; }
	public string? BasalId { get; set; }
	public string? StudyNumber { get; set; }
	public DateTime? DateRequest { get; set; }
	public IEnumerable<DrugRow>? Drugs { get; set; }
	public IEnumerable<ConcentrationSummary>? SummaryOfDrugConcentration { get; set; }

	public string? LotYear { get; set; }
	public string? LotId { get; set; }
	public int Sequence { get; set; }

	public class DrugRow
	{
		public string? DrugName { get; init; }
		public decimal Concentration { get; init; }
		public ConcentrationUnitOfMeasure ConcentrationUnitOfMeasure { get; init; }
	}

	public class ConcentrationSummary
	{
		public decimal Concentration { get; init; }
		public ConcentrationUnitOfMeasure ConcentrationUnitOfMeasure { get; init; }
	}
}