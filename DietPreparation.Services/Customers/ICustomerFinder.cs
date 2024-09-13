using DietPreparation.Models.DAO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Customers;

public interface ICustomerFinder : IFind<CustomerDao>
{
}