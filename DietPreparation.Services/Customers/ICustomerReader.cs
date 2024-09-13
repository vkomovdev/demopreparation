using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Customers;

public interface ICustomerReader : IReadAll<CustomerDto>, IRead<int, CustomerDto>
{
	Task<IEnumerable<CustomerDto>> ReadAllAsync(OrderByDto orderBy, PaginationDto pagination);
	Task<CustomerDto?> FindAsync(string email);
}
