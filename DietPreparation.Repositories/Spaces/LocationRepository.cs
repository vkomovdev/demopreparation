using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;
using System.Text;

namespace DietPreparation.Repositories.Spaces;
internal class LocationRepository : ILocationRepository
{
	private const string LocationSelectStoredProcedure = "DPS_LOCATION_SELECT";
	private const string LocationStoredProcedure = "DPS_LOCATION_IU";

	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public LocationRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async Task<LocationDao> ReadAsync(int id)
	{
		var cmd = $"{LocationSelectStoredProcedure} {id}";
		return await _unitOfWork.QuerySingleAsync<LocationDao>(cmd);
	}

	public async ValueTask<IEnumerable<LocationDao>> ReadAllAsync()
	{
		var sql = await _queryFactory.BuildReadLocationsQuery();
		return await _unitOfWork.QueryAsync<LocationDao>(sql);
	}

	public async ValueTask<IEnumerable<LocationDao>> GetLocationsAsync(string sColumn, string sSlope, string sLocation_ID)
	{
		var cmd = $"{LocationSelectStoredProcedure} {sLocation_ID}";
		return await _unitOfWork.QueryAsync<LocationDao>(cmd);
	}

	public async ValueTask<int> UpdateAsync(LocationUpdateDao model)
	{
		var cmd = $"{LocationStoredProcedure} " +
			$"{model.Id}, " +
			$"{model.Description.ToSqlValue()}, " +
			$"{model.Building.ToSqlValue()}, " +
			$"{model.Floor.ToSqlValue()}, " +
			$"{model.Lab.ToSqlValue()},  " +
			$"{model.BusinessUnit.ToSqlValue()}";
		return await _unitOfWork.QueryFirstOrDefaultAsync<int>(cmd);
	}

	public async ValueTask<int> InsertAsync(LocationDao model)
	{
		return 0;

		//var cmd = $"{LocationStoredProcedure} ({model.Id}, '{model.Description}', '{model.Building}', '{model.Floor}', '{model.Lab}',  '{model.Unit}')";
		//return await _unitOfWork.QueryFirstAsync<string>(cmd);
	}

	public async Task<IEnumerable<LocationDao>> FilterAsync(LocationFilterDao filterDao)
	{
		var filter = string.Empty;

		if (filterDao.BUSINESS_UNIT_NUMBER != null)
		{
			filter += $" AND {nameof(LocationFilterDao.BUSINESS_UNIT_NUMBER)} = {filterDao.BUSINESS_UNIT_NUMBER.ToSqlValue()}";
		}

		if (filterDao.DELIVER_BUILDING != null)
		{
			filter += $" AND {nameof(LocationFilterDao.DELIVER_BUILDING)} = {filterDao.DELIVER_BUILDING.ToSqlValue()}";
		}

		if (filterDao.DELIVER_DESCRIPTION != null)
		{
			filter += $" AND {nameof(LocationFilterDao.DELIVER_DESCRIPTION)} = {filterDao.DELIVER_DESCRIPTION.ToSqlValue()}";
		}

		if (filterDao.DELIVER_FLOOR != null)
		{
			filter += $" AND {nameof(LocationFilterDao.DELIVER_FLOOR)} = {filterDao.DELIVER_FLOOR.ToSqlValue()}";
		}

		if (filterDao.DELIVER_LAB != null)
		{
			filter += $" AND {nameof(LocationFilterDao.DELIVER_LAB)} = {filterDao.DELIVER_LAB.ToSqlValue()}";
		}

		var parameters = new Dictionary<string, object>
		{
			{ "@filter", filter }
		};
		var sql = BuildQueryWithParameters(await _queryFactory.BuildGetFilteredLocationListQuery(), parameters);

		var result = await _unitOfWork.QueryAsync<LocationDao>(sql);
		return result;
	}

	public async ValueTask<IEnumerable<LocationsItemDao>> GetPaginatedLocationsAsync(OrderByDao orderByDao, PaginationDao paginationDao)
	{
		var orderBy = orderByDao is null ? " ORDER BY (SELECT NULL) " : $" ORDER BY {orderByDao.ORDER_BY} ";
		var parameters = new Dictionary<string, object>
		{
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildGetPaginatedLocationListQuery(), parameters);
		var result = await _unitOfWork.QueryAsync<LocationsItemDao>(sql);

		return result;
	}

	private string BuildQueryWithParameters(string sql, Dictionary<string, object> parameters)
	{
		var sqlWithParameters = new StringBuilder(sql);
		foreach (var param in parameters)
		{
			sqlWithParameters.Replace(param.Key, param.Value.ToString());
		}
		return sqlWithParameters.ToString();
	}
}
