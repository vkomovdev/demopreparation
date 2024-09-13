using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Customers;

internal class CustomerUpdater : ICustomerUpdater
{
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;

	public CustomerUpdater(ICustomerRepository customerRepository, IMapper mapper)
	{
		_customerRepository = customerRepository;
		_mapper = mapper;
	}

	public async Task<CustomerDto> UpdateAsync(CustomerDto customerDto)
	{
		var createUpdateCustomerDao = _mapper.Map<CreateUpdateCustomerDao>(customerDto);

		await _customerRepository.UpdateAsync(createUpdateCustomerDao);

		return customerDto;
	}
}
