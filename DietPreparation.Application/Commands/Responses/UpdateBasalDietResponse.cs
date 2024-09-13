using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses;

public record UpdateBasalDietResponse : BaseResponse, IExceptionResponse
{
	public int? Id { get; set; }
}
