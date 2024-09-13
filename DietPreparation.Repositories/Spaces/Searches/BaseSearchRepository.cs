using System.Text;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces;

public abstract class BaseSearchRepository
{
	protected virtual string BuildDietRequestsQuery(IBaseDietRequestFilter filterDao)
	{
		var searchText = string.Empty;

		if (!string.IsNullOrEmpty(filterDao.LotYear))
		{
			searchText += $" AND (DP_REQUEST.LOT_YEAR = {filterDao.LotYear}) ";
			if (!string.IsNullOrEmpty(filterDao.LotNumber))
			{
				searchText += $" AND (DP_PWO.[SEQUENCE] = {filterDao.LotNumber}) ";
			}
			if (!string.IsNullOrEmpty(filterDao.LotId))
			{
				searchText += $" AND (DP_REQUEST.LOT_ID = {filterDao.LotId}) ";
			}
		}

		if (!string.IsNullOrEmpty(filterDao.DietName))
		{
			searchText += $" AND (DIET_NAME LIKE '%{filterDao.DietName}%') ";
		}

		if (!string.IsNullOrEmpty(filterDao.Requestor))
		{
			searchText += $" AND (DP_CUSTOMER.FIRST_NAME LIKE '%{filterDao.Requestor}%' OR DP_CUSTOMER.LAST_NAME LIKE '%{filterDao.Requestor}%') ";
		}

		return searchText;
	}

	protected virtual string BuildOrderByQuery(IOrderByDao? orderByDao)
	{
		return (orderByDao is null || string.IsNullOrWhiteSpace(orderByDao.ORDER_BY))
			? " ORDER BY (SELECT NULL) "
			: $" ORDER BY {orderByDao.ORDER_BY} ";
	}

	protected virtual string BuildQueryWithParameters(string sql, Dictionary<string, object> parameters)
	{
		var sqlWithParameters = new StringBuilder(sql);
		foreach (var param in parameters)
		{
			sqlWithParameters.Replace(param.Key, param.Value.ToString());
		}
		return sqlWithParameters.ToString();
	}
}