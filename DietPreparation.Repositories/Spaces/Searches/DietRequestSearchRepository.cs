using DietPreparation.Common.Enums;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class DietRequestSearchRepository : BaseSearchRepository, IDietRequestSearchRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly DietRequestQueryFactory _queryFactory;

	public DietRequestSearchRepository(IUnitOfWork unitOfWork, DietRequestQueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		return await SearchAsync(new DietRequestFilterDao(), orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IDietRequestFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		var orderBy = BuildOrderByQuery(orderByDao);

		var filter = filterDao.Options switch
		{
			DietRequestFilterOptions.Open => " AND DP_REQUEST.ISDELETED = 'N' AND DP_REQUEST.LOCK = 0 ",
			DietRequestFilterOptions.Cloned => " AND DP_REQUEST.ISDELETED = 'N' AND DP_REQUEST.USEDASTEMPLATE = 'Y' ",
			DietRequestFilterOptions.All => " AND DP_REQUEST.ISDELETED = 'N' ",
			DietRequestFilterOptions.AllPast => string.Empty,
			_ => throw new ArgumentException("Invalid filter option")
		};

		var parameters = new Dictionary<string, object>
		{
			{ "@filter", filter},
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchForDietRequestQuery(), parameters);
		return await _unitOfWork.QueryAsync<DietRequestDao>(sql);
	}

	public async ValueTask<IEnumerable<DietRequestTinyDao>> SearchAsync(IDietRequestTinyFilter filterDao)
	{
		var filter = BuildDietRequestsFilterString(filterDao);

		var parameters = new Dictionary<string, object>
		{
			{ "@filter", filter }
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchForDietRequestsTinyQuery(), parameters);
		return await _unitOfWork.QueryAsync<DietRequestTinyDao>(sql);
	}

	private string BuildDietRequestsFilterString(IDietRequestTinyFilter filter)
	{
		var searchText = string.Empty;

		if (filter.PreMixUsed.HasValue)
		{
			var value = filter.PreMixUsed.Value ? 1 : 0;
			searchText += $" AND PreMixUsed = {value}";
		}

		if (!string.IsNullOrWhiteSpace(filter.UsedAsTemplate))
		{
			var value = filter.UsedAsTemplate;
			searchText += $" AND UsedAsTemplate LIKE N'%{value}%'";
		}

		if (!string.IsNullOrWhiteSpace(filter.REQUEST_TYPE))
		{
			var value = filter.REQUEST_TYPE;
			searchText += $" AND REQUEST_TYPE LIKE N'%{value}%'";
		}

		return searchText;
	}
}