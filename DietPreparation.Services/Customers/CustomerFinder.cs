using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Services.Customers;

public class CustomerFinder : ICustomerFinder
{
	private readonly ICustomerRepository _customerRepository;

	public CustomerFinder(ICustomerRepository customerRepository)
	{
		_customerRepository = customerRepository;
	}

	public async ValueTask<IEnumerable<CustomerDao>> FindAsync()
	{
		return await _customerRepository.Find("DELIVER T0");
	}
}
