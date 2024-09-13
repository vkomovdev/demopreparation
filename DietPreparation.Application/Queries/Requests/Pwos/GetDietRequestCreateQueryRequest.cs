using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.PWOs;
public class GetDietRequestCreateQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetDietRequestCreateQueryResponse>
{
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}
