using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Locations;

public record GetLocationQueryResponse : BaseResponse, IExceptionResponse
{
	public LocationDto? Location { get; set; }
}