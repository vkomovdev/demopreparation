using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Models.DTO;

public record PwoPremixDrugDto
{
	public int PwoId { get; init; }

	[DisplayFormat(DataFormatString = FormatStrings.DecimalFormat)]
	public decimal ConcentrateInBatch { get; init; }

	public ConcentrationUnitOfMeasure ConcentrationUnitOfMeasure { get; init; }

	public string MfgLot { get; init; } = string.Empty;

	public string DrugName { get; init; } = string.Empty;
}