using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;

public class PwoInitiatedSearchRepository : BaseSearchRepository, IPwoSearchInitiateRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly DietRequestQueryFactory _queryFactory;

	public PwoInitiatedSearchRepository(IUnitOfWork unitOfWork, DietRequestQueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		var orderBy = BuildOrderByQuery(orderByDao);

		var parameters = new Dictionary<string, object>
		{
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchForPwoInitiateQuery(), parameters);

		return await _unitOfWork.QueryAsync<DietRequestDao>(sql);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IPwoFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		return await SearchAsync(orderByDao, paginationDao);
	}
}