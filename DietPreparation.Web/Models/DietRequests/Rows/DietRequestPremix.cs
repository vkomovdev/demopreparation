using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.Metadata;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.DietRequests.Rows;

public class DietRequestPremix
{
	public int? PremixId { get; set; }
	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal? Amount { get; set; }
	public UnitOfMeasure? UnitOfMeasure { get; set; }
	public bool IncludedInWeight { get; set; }

	[JsonIgnore]
	public MetadataSection? Metadata { get; set; }
}
