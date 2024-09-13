using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses;

public record CreateUpdateFeedStuffResponse : BaseResponse, IExceptionResponse
{
	public string Id { get; set; } = string.Empty;
}