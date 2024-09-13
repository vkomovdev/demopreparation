using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Customers;

public record GetCustomersQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetCustomersQueryResponse>
{ 
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}