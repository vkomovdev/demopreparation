using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.FeedLabels;

public record PrintFeedLabelDto
{
	public int Id { get; init; }
	public string? LotNumber { get; init; }
	public string? ProjectNumber { get; init; }
	public string? BasalId { get; init; }
	public string? StudyNumber { get; init; }
	public DateTime? ExpirationDate { get; init; }
	public DateTime? ManufacturedDate { get; init; }
	public string? Comment { get; init; }
	public string? AdditionalComment { get; init; }
	public int Quantity { get; set; }
	public bool NeedPrintBagNumbers { get; init; }
	public IEnumerable<DrugRow>? Drugs { get; init; }
	public IEnumerable<ConcentrationSummary>? SummaryOfDrugConcentration { get; init; }

	public record DrugRow
	{
		public string? DrugName { get; init; }
		public decimal Concentration { get; init; }
		public ConcentrationUnitOfMeasure ConcentrationUnitOfMeasure { get; init; }
	}

	public record ConcentrationSummary
	{
		public decimal Concentration { get; init; }
		public ConcentrationUnitOfMeasure ConcentrationUnitOfMeasure { get; init; }
	}
}