using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Customers;

internal class CustomerReader : ICustomerReader
{
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;

	public CustomerReader(ICustomerRepository customerRepository, IMapper mapper)
	{
		_customerRepository = customerRepository;
		_mapper = mapper;
	}

	public async Task<CustomerDto> ReadAsync(int id)
	{
		var customerDao = await _customerRepository.ReadAsync(id.ToString());
		return _mapper.Map<CustomerDto>(customerDao);
	}

	public async Task<IEnumerable<CustomerDto>> ReadAllAsync()
	{
		var customerDaos = await _customerRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<CustomerDto>>(customerDaos);
	}
	public async Task<IEnumerable<CustomerDto>> ReadAllAsync(OrderByDto orderByDto, PaginationDto pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderByDto);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);

		var customerDaos = await _customerRepository.ReadAllAsync(orderByDao, paginationDao);

		return _mapper.Map<IEnumerable<CustomerDto>>(customerDaos);
	}

	public async Task<CustomerDto?> FindAsync(string email)
	{
		var customerDao = await _customerRepository.FindAsync(email);

		return _mapper.Map<CustomerDto>(customerDao);
	}
}
