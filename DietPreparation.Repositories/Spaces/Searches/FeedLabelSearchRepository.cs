using DietPreparation.Common.Enums;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class FeedLabelSearchRepository : BaseSearchRepository, IFeedLabelSearchRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly DietRequestQueryFactory _queryFactory;

	public FeedLabelSearchRepository(IUnitOfWork unitOfWork, DietRequestQueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		return await SearchAsync(new FeedLabelFilterDao(), orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IFeedLabelFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		var searchText = BuildDietRequestsQuery(filterDao);
		var orderBy = BuildOrderByQuery(orderByDao);
		var filter = filterDao.Type switch
		{
			FeedLabelsType.Open => " AND DP_REQUEST.REQUEST_ID IN (SELECT DISTINCT DP_PWO.REQUEST_ID FROM DP_PWO WHERE LABELS_PRINTED = 0)",
			FeedLabelsType.Reprint => " AND DP_REQUEST.REQUEST_ID IN (SELECT DISTINCT REQUEST_ID FROM DP_PWO WHERE LABELS_PRINTED = 1)",
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

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchForFeedLabelQuery(), parameters);
		return await _unitOfWork.QueryAsync<DietRequestDao>(sql);
	}
}