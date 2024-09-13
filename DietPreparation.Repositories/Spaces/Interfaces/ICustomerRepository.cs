using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface ICustomerRepository : IReadRecord<string, CustomerDao?>, IReadAllRecord<CustomerDao>, IUpdateRecord<CreateUpdateCustomerDao>
{
	Task<IEnumerable<CustomerDao>> Find(string customerType);
	ValueTask<IEnumerable<CustomerDao>> GetCustomers(string sColumn, string sSlope, string sCustomer_ID);
	ValueTask<IEnumerable<LocationDao>> GetChildrenLocation(string criteria);
	ValueTask<IEnumerable<DrugConcentrationDao>> GetChildrenDrugConcentration(string criteria);
	ValueTask<IEnumerable<CustomerDao>> ReadAllAsync(OrderByDao orderBy, IPagination paginationDao);
	Task<CustomerDao?> FindAsync(string email);
}
