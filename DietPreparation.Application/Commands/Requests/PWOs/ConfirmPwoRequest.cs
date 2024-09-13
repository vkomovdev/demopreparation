using DietPreparation.Application.Commands.Responses.PWOs;
using DietPreparation.Common.Enums;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.PWOs;

public record ConfirmPwoRequest : IRequest<ConfirmPwoResponse>
{
	public int PwoId { get; init; }
	public PwoConfirmType Type { get; init; }
}