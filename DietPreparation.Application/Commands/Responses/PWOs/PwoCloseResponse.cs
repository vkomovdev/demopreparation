using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.PWOs;

public record PwoCloseResponse : BaseResponse
{
	public int PwoId { get; set; }
}