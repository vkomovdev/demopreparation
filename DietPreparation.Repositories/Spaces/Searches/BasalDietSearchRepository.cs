using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class BasalDietSearchRepository : BaseSearchRepository, IBasalDietSearchRepository
{
	private const string BasalIngredientSelect = "DPS_BASAL_INGREDIENT_SELECT";
	private readonly IUnitOfWork _unitOfWork;
	private readonly DietRequestQueryFactory _queryFactory;

	public BasalDietSearchRepository(IUnitOfWork unitOfWork, DietRequestQueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<BasalDietDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		var orderBy = BuildOrderByQuery(orderByDao);
		var parameters = new Dictionary<string, object>
		{
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildSearchForBasalDietsQuery(), parameters);
		return await _unitOfWork.QueryAsync<BasalDietDao>(sql);
	}

	public async Task<IEnumerable<BasalDietDao>> SearchAsync(BasalDietFilterDao filterDao)
	{
		var filter = string.Empty;
		if (filterDao.Code != null)
		{
			filter += $" AND {nameof(BasalDietDao.BASAL_DIET_CODE)} = {filterDao.Code.ToSqlValue()} ";
		}
		if (filterDao.Name != null)
		{
			filter += $" AND {nameof(BasalDietDao.BASAL_DIET_NAME)} = {filterDao.Name.ToSqlValue()} ";
		}
		var parameters = new Dictionary<string, object>
		{
			{ "@filter", filter },
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildFilterBasalDietsQuery(), parameters);
		return await _unitOfWork.QueryAsync<BasalDietDao>(sql);
	}

	public async ValueTask<IEnumerable<BasalDietIngredientDao>> SearchBasalDietIngredientsAsync(BasalDietIngredientFilterDao filterDao)
	{
		var sql = $"{BasalIngredientSelect} '{filterDao.BasalDietId}', '{nameof(BasalDietIngredientDao.PERCENT_OF_DIET)}'";

		return await _unitOfWork.QueryAsync<BasalDietIngredientDao>(sql);
	}
}