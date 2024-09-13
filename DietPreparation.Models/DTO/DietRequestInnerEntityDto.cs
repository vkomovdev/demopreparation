using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;

namespace DietPreparation.Models.DTO;

public abstract record DietRequestInnerEntityDto
{
	public int Id { get; set; }

	public decimal Amount { get; init; }

	public UnitOfMeasure UnitOfMeasure { get; init; }

	public bool IncludedInWeight { get; init; }

	public virtual int? InnerEntityId { get; set; }

	public virtual decimal AmountInGrams => Amount * (decimal)UnitOfMeasure.GetConversionRateToGram();
}