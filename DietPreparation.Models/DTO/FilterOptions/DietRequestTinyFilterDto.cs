using DietPreparation.Common.Enums;
using DietPreparation.Filter.Options;

namespace DietPreparation.Models.DTO.TableOptions;

public record DietRequestTinyFilterDto : IFilterBy
{
	public bool? PremixUsed { get; init; }
	public bool? UsedAsTemplate { get; init; }
	public RequestType? RequestType { get; init; }
}