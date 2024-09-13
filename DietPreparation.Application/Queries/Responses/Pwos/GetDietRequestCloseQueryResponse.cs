using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.PWOs;
public record GetDietRequestCloseQueryResponse : BasePaginationTableResponse, IExceptionResponse
{
	public IEnumerable<DietRequestDto>? DietRequests { get; set; }
}
