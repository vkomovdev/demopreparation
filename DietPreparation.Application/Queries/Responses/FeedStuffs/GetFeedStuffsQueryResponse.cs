using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.FeedStuffs;

public record GetFeedStuffsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<FeedStuffDto>? FeedStuffs { get; init; }
}