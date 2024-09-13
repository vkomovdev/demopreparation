using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;
internal class CustomerRepository : BaseSearchRepository, ICustomerRepository
{
	private const string ReadStoredProcedure = "DPS_CUSTOMER_SELECT";

	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public CustomerRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}
	public async Task<IEnumerable<CustomerDao>> Find(string customerType)
	{
		//customerType - 'DELIVER T0' , ''REQUESTOR''
		string sql = await _queryFactory.BuildReadCustomersQuery();

		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "customerType", customerType }
		};

		return await _unitOfWork.QueryAsync<CustomerDao>(sql, parameters);
	}

	public async ValueTask<IEnumerable<CustomerDao>> GetCustomers(string sColumn, string sSlope, string sCustomer_ID)
	{
		var orderBy = string.Empty;
		if (sColumn != string.Empty)
		{
			orderBy = sColumn;
		}

		if (sSlope != string.Empty)
		{
			orderBy += $" {sSlope}";
		}

		var cmd = $"DPS_CUSTOMER_SELECT {sCustomer_ID}, ";

		if (orderBy != string.Empty)
		{
			cmd += $"'{orderBy}'";
		}
		else
		{
			cmd += "NULL";
		}

		return await _unitOfWork.QueryAsync<CustomerDao>(cmd);
	}
	public async ValueTask<IEnumerable<LocationDao>> GetChildrenLocation(string criteria)
	{
		var cmd = $"DPS_CUSTOMER_LOCATION  '{criteria}'";
		return await _unitOfWork.QueryAsync<LocationDao>(cmd);
	}
	public async ValueTask<IEnumerable<DrugConcentrationDao>> GetChildrenDrugConcentration(string criteria)
	{
		var cmd = $"DPS_DRUG_CONCENTRATION '{criteria}'";
		return await _unitOfWork.QueryAsync<DrugConcentrationDao>(cmd);
	}

	public async ValueTask<IEnumerable<CustomerDao>> ReadAllAsync()
	{
		var cmd = "DPS_CUSTOMER_SELECT";

		return await _unitOfWork.QueryAsync<CustomerDao>(cmd);
	}

	public async Task<CustomerDao> ReadAsync(int id)
	{
		var cmd = $"{ReadStoredProcedure} {id}";
		return await _unitOfWork.QuerySingleAsync<CustomerDao>(cmd);
	}

	public async Task<CustomerDao?> ReadAsync(string customerId)
	{
		return (await GetCustomerSelect(customerId, null)).FirstOrDefault();
	}

	private async ValueTask<IEnumerable<CustomerDao>> GetCustomerSelect(string? customerId, string? orderBy)
	{
		var cmd = $"{ReadStoredProcedure} {customerId.ToSqlValue()}";
		return await _unitOfWork.QueryAsync<CustomerDao>(cmd);
	}

	private async ValueTask<IEnumerable<CustomerDao>> GetCustomerSelectWithPaging(string? customerId, IOrderByDao orderByDao, IPagination paginationDao)
	{

		var orderBy = BuildOrderByQuery(orderByDao);

		var customerIdFilter = !string.IsNullOrEmpty(customerId) ? $" WHERE DP_CUSTOMER.CUSTOMER_ID = {customerId} " : " ";

		var parameters = new Dictionary<string, object>
		{
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page},
			{ "@customerIdFilter", customerIdFilter}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildCustomerSelectQuery(), parameters);

		return await _unitOfWork.QueryAsync<CustomerDao>(sql);

	}

	public async Task<CreateUpdateCustomerDao> UpdateAsync(CreateUpdateCustomerDao model)
	{
		await GetCustomerIU(model);
		return model;
	}

	private async Task GetCustomerIU(CreateUpdateCustomerDao model)
	{
		var businessUnit = model.UNIT.HasValue ? model.UNIT.Value.ToString() : DefaultStrings.Null;
		var cmd =
			$"""
			 DPS_CUSTOMER_IU {model.CUSTOMER_ID}, 
			 '{model.FIRST_NAME}', 
			 '{model.MIDDLE_INITIAL}', 
			 '{model.LAST_NAME}', 
			 '{model.EMAIL}',  
			 '{model.CUSTOMER_TYPE}', 
			 {businessUnit}, 
			 {model.BUILDING} 
			 """;

		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async ValueTask<IEnumerable<CustomerDao>> ReadAllAsync(OrderByDao orderBy, IPagination paginationDao)
	{
		return await GetCustomerSelectWithPaging(null, orderBy, paginationDao);
	}

	public async Task<CustomerDao?> FindAsync(string email)
	{
		string sql = $"SELECT CUSTOMER_ID, EMAIL FROM DP_CUSTOMER WHERE EMAIL = '{email}'";

		var result = await _unitOfWork.QueryAsync<CustomerDao>(sql);

		return result.Any() ? result.First() : null;
	}
}
