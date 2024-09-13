using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.DietRequests;

public record GetDietRequestsQueryRequest :
	IRequest<GetDietRequestsQueryResponse>,
	IFilterable<DietRequestFilterDto>,
	IOrderable<OrderByDto>,
	IPaginable<PaginationDto>
{
	public DietRequestFilterDto? FilterBy { get; set; }
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}