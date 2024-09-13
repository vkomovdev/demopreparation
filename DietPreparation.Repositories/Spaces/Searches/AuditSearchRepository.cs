using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class AuditSearchRepository : BaseSearchRepository, IAuditSearchRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public AuditSearchRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<AuditItemDao>> SearchAsync(IAuditFilterOptions filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		var orderBy = BuildOrderByQuery(orderByDao);

		var filter = string.Empty;
		if (filterDao.DateStart.HasValue)
		{
			filter += $" AND Change_TimeStamp >= '{filterDao.DateStart.ToString(FormatStrings.SqlDateFormat)} 00:00:00.000'";
		}
		if (filterDao.DateEnd.HasValue)
		{
			filter += $" AND Change_TimeStamp <= '{filterDao.DateEnd.ToString(FormatStrings.SqlDateFormat)} 23:59:59.999'";
		}
		if (!string.IsNullOrWhiteSpace(filterDao.LotYear))
		{
			filter += $" AND Lot_Year = {filterDao.LotYear.ToSqlValue()}";
		}
		if (filterDao.LotId.HasValue)
		{
			filter += $" AND Lot_ID = {filterDao.LotId.Value}";
		}

		var parameters = new Dictionary<string, object>
		{
			{ "@filter", filter},
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildAuditSelectQuery(), parameters);
		return await _unitOfWork.QueryAsync<AuditItemDao>(sql);
	}
}