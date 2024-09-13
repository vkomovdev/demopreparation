using DietPreparation.Data.UnitOfWork;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class FeedStuffSearchRepository : BaseSearchRepository, IFeedStuffSearchRepository
{
	private const string DpsFeedStuffReportProcedure = "DPS_FEED_STUFF_REPORT";

	private readonly IUnitOfWork _unitOfWork;

	public FeedStuffSearchRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async ValueTask<IEnumerable<FeedStuffReportDao>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao)
	{
		return await SearchAsync(new FeedStuffFilterDao(), orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<FeedStuffReportDao>> SearchAsync(IFeedStuffFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao)
	{
		var inputParams = new List<string>
		{
			orderByDao is not null ? $"@Order_By = '{orderByDao.ORDER_BY}'" : string.Empty,
			filterDao.IngredientId.HasValue ? $"@Ingredient_ID={filterDao.IngredientId}" : string.Empty,
			filterDao.DateStart.HasValue ? $"@Date_Start='{filterDao.DateStart:yyyyMMdd}'" : string.Empty,
			filterDao.DateEnd.HasValue ? $"@Date_End='{filterDao.DateEnd:yyyyMMdd}'" : string.Empty
		};

		var cmd = $"{DpsFeedStuffReportProcedure} {string.Join(',', inputParams.Where(x => !string.IsNullOrEmpty(x)))}";

		return await _unitOfWork.QueryAsync<FeedStuffReportDao>(cmd);
	}
}