using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.FeedStuffs;

public record GetFeedStuffQueryResponse : BaseResponse, IExceptionResponse
{
	public FeedStuffDto? FeedStuff { get; init; }
}