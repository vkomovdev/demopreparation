using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.FeedLabels;

public record GetFeedLabelsQueryResponse : BasePaginationTableResponse, IExceptionResponse
{
	public IEnumerable<DietRequestDto>? FeedLabels { get; set; }
}