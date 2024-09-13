using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.PWOs;

public record ConfirmPwoResponse : BaseResponse
{
	public int PwoId { get; set; }
}