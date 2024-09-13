using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Drugs;

public record GetFilteredDrugsQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetFilteredDrugsQueryResponse>
{
	public PaginationDto? Pagination { get; set; }
	public OrderByDto? OrderBy { get; set; }
}