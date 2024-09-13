using DietPreparation.Common.Enums;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class PwoDietRequestRepository : BaseSearchRepository, IPwoSearchRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly DietRequestQueryFactory _queryFactory;

	public PwoDietRequestRepository(IUnitOfWork unitOfWork, DietRequestQueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		return await SearchAsync(new PwoFilterDao(), orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IPwoFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		var searchText = BuildDietRequestsQuery(filterDao);
		var orderBy = BuildOrderByQuery(orderByDao);
		var filter = filterDao.Filter switch
		{
			PwoFilterOptions.Open => " AND (DP_PWO.PWOS_PRINTED = 0)",
			PwoFilterOptions.Printed => " AND (DP_PWO.PWOS_PRINTED = 1 AND DP_PWO.PWO_CLOSED = 0)",
			PwoFilterOptions.Closed => " AND (DP_PWO.PWO_CLOSED = 1)",
			_ => throw new ArgumentException("Invalid filter option")
		};

		var parameters = new Dictionary<string, object>
					{
						{ "@searchText", searchText },
						{ "@filter", filter},
						{ "@orderBy", orderBy },
						{ "@pageSize", paginationDao.PageSize},
						{ "@page", paginationDao.Page}
					};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchDietRequestsQuery(), parameters);
		return await _unitOfWork.QueryAsync<DietRequestDao>(sql);
	}
}