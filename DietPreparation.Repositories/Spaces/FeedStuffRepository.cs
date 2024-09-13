using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DietPreparation.Repositories.Spaces;
internal class FeedStuffRepository : IFeedStuffRepository
{
	private const string DpsFeedLabelLockProcedure = "DPS_FEED_LABEL_LOCK";
	private const string DpsIngredientSelectProcedure = "DPS_INGREDIENT_SELECT";
	private const string DpsFeedStuffIuProcedure = "DPS_FEEDSTUFF_IU";
	private const string DefaultId = "0";

	private readonly IUnitOfWork _unitOfWork;

	public FeedStuffRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task LabelPrintConfirmAsync(string iPWO_ID, string bit)
	{
		var cmd = $"{DpsFeedLabelLockProcedure} {iPWO_ID}, {bit}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async ValueTask<IEnumerable<FeedStuffDao>> ReadAllAsync()
	{
		return await SelectFeedStuffAsync(null, "Ingredient_Name ASC");
	}

	public async ValueTask<IEnumerable<FeedStuffDao>> ReadAllAsync(OrderByDao orderBy)
	{
		return await SelectFeedStuffAsync(null, orderBy.ORDER_BY);
	}

	public async Task<FeedStuffDao?> ReadAsync(string feedStuffId)
	{
		return (await SelectFeedStuffAsync(feedStuffId, null)).FirstOrDefault();
	}

	public async Task<CreateUpdateFeedStuffDao> UpsertAsync(CreateUpdateFeedStuffDao createCreateUpdateFeedStuffEntity)
	{
		if (createCreateUpdateFeedStuffEntity.INGREDIENT_ID.IsNullOrEmpty())
		{
			createCreateUpdateFeedStuffEntity.INGREDIENT_ID = DefaultId;
		}

		await CreateUpdateFeedStuffAsync(createCreateUpdateFeedStuffEntity);

		return createCreateUpdateFeedStuffEntity;
	}

	public async ValueTask<IEnumerable<FeedStuffDao>> SelectFeedStuffAsync(string? sFeedStuffId, string? orderByDao)
	{
		var cmd = $"{DpsIngredientSelectProcedure} {sFeedStuffId.ToSqlValue()}, {orderByDao.ToSqlValue()}";
		return await _unitOfWork.QueryAsync<FeedStuffDao>(cmd);
	}

	private async Task CreateUpdateFeedStuffAsync(CreateUpdateFeedStuffDao createCreateUpdateFeedStuffDao)
	{
		var cmd = $"{DpsFeedStuffIuProcedure} '{createCreateUpdateFeedStuffDao.INGREDIENT_ID}', {createCreateUpdateFeedStuffDao.INGREDIENT_NAME.ToSqlValue()}";
		await _unitOfWork.ExecuteAsync(cmd);
	}
}