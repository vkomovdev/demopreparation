using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.PWOs;
public class GetDietRequestCloseQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetDietRequestCloseQueryResponse>
{
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}
