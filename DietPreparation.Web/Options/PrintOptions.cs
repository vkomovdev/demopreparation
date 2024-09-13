using DietPreparation.Web.Models;

namespace DietPreparation.Web.Options;

public record PrintOptions
{
	public string DefaultZplExtension { get; set; } = string.Empty;

	public string DefaultPrinterKey { get; set; } = string.Empty;

	public IEnumerable<PrinterInfo> Printers { get; set; } = Enumerable.Empty<PrinterInfo>();
}