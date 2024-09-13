using DietPreparation.Common.Enums;
using Newtonsoft.Json;

namespace DietPreparation.Web.Models.FeedLabels;

public class FeedLabelViewModel
{
	public int Id { get; set; }
	public int Sequence { get; set; }

	public DateTime? DateRequest { get; set; }
	public DateTime? ExpirationDate { get; set; }
	public DateTime? ManufacturedDate { get; set; }
	public string? Comment { get; set; }
	public string? AdditionalComment { get; set; }

	public string? BagNumbers { get; set; }
	public string? PrinterDirectory { get; set; }
	public bool NeedPrintBagNumbers { get; set; }
	public bool NoNeedPrintLabels { get; set; }
	public bool NeedOnlyDownload { get; set; }
	public string? ZplExtension { get; set; }

	[JsonIgnore]
	public FeedLabelsType Type { get; set; }
	[JsonIgnore]
	public string? LotNumber { get; set; }
	[JsonIgnore]
	public string? ProjectNumber { get; set; }
	[JsonIgnore]
	public string? BasalId { get; set; }
	[JsonIgnore]
	public string? StudyNumber { get; init; }
	[JsonIgnore]
	public IEnumerable<DrugRow>? Drugs { get; set; }
	[JsonIgnore]
	public IEnumerable<ConcentrationSummary>? SummaryOfDrugConcentration { get; set; }
	[JsonIgnore]
	public IEnumerable<PrinterInfo>? Printers { get; set; }
	[JsonIgnore]
	public string? PrinterKey { get; set; }

	public class DrugRow
	{
		public string? DrugName { get; init; }
		public string? ConcentrationWithUom { get; init; }
	}

	public class ConcentrationSummary
	{
		public string? ConcentrationWithUom { get; init; }
	}
}