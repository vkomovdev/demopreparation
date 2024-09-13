using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetDietRequestQueryResponse : BaseDietRequestResponse, IExceptionResponse
{
	public int? Id { get; set; }
}