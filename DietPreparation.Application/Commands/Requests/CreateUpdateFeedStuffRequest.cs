using DietPreparation.Application.Commands.Responses;
using DietPreparation.Models.DTO;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record CreateUpdateFeedStuffRequest : IRequest<CreateUpdateFeedStuffResponse> 
{
	public FeedStuffDto? FeedStuff { get; set; }
}