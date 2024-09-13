using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.Metadata;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests.Rows;

public class DietRequestDrug
{
	public int? DrugId { get; set; }
	public string? ConcentrationWithUom { get; set; }
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? Amount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }
	public string? MfgLot { get; set; }
	public bool IncludedInWeight { get; set; }

	[JsonIgnore]
	public MetadataSection? Metadata { get; set; }
}