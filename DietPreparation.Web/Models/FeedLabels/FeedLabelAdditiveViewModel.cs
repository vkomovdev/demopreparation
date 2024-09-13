using Newtonsoft.Json;

namespace DietPreparation.Web.Models.FeedLabels;

public class FeedLabelAdditiveViewModel
{
	public string? LotNumber { get; init; }
	public string? Id { get; init; }
	public string? Concentration { get; set; }
	public DateTime? ExpirationDate { get; set; }
	public string? Comment { get; set; }
	public string? AdditionalComment { get; set; }
	public int? NumberOfCopies { get; set; }
	public string? PrinterDirectory { get; set; }
	public string? ZplExtension { get; set; }
	public bool NeedOnlyDownload { get; set; }

	[JsonIgnore] 
	public string? PrinterKey { get; init; }
	[JsonIgnore] 
	public IEnumerable<PrinterInfo>? Printers { get; set; }
}