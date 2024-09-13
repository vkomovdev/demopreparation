using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;
using System.Xml.Linq;

namespace DietPreparation.Repositories.Spaces;
internal class BasalDietRepository : IBasalDietRepository
{
	private const string BasalIngredientSelect = "DPS_BASAL_INGREDIENT_SELECT";
	private const string BasalIngredientUpdate = "DPS_BASAL_INGREDIENT_UPDATE";
	private const string BasalDietSelect = "DPS_BASAL_DIET_SELECT";

	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public BasalDietRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<BasalDietDao>> ReadAllAsync()
	{
		var sql = await _queryFactory.BuildReadBasalDietQuery();
		return await _unitOfWork.QueryAsync<BasalDietDao>(sql);
	}

	public async ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(string sColumn, string sSlope)
	{
		var orderBy = sColumn switch
		{
			"BASAL_DIET_CODE" => $"DP_BASAL_DIET.BASAL_DIET_CODE {sSlope}",
			"BASAL_DIET_NAME" => $"DP_BASAL_DIET.BASAL_DIET_NAME {sSlope}",
			_ => ""
		};

		var cmd = $"{BasalDietSelect} Null, '{orderBy}'";
		return await _unitOfWork.QueryAsync<BasalDietDao>(cmd);
	}

	public async Task<BasalDietDao> ReadAsync(string id)
	{
		return await _unitOfWork.QuerySingleAsync<BasalDietDao>($"{BasalDietSelect} {id}");
	}

	public async Task<BasalDietDao> UpsertAsync(BasalDietDao entity)
	{
		var ingredients = string.Empty;
		if (entity.BasalDietIngredients != null && entity.BasalDietIngredients.Any())
		{
			var basalDietId = entity.BASAL_DIET_ID > 0 ? entity.BASAL_DIET_ID.ToString() : string.Empty;
			ingredients = new XElement("root", entity.BasalDietIngredients.Select(x =>
				new XElement("Ingredient",
					new XAttribute(nameof(BasalDietIngredientDao.BASAL_DIET_ID), basalDietId),
					new XAttribute(nameof(BasalDietIngredientDao.INGREDIENT_ID), x.INGREDIENT_ID),
					new XAttribute(nameof(BasalDietIngredientDao.PERCENT_OF_DIET), x.PERCENT_OF_DIET)
				))).ToString();
		}

		var sql = $"{BasalIngredientUpdate} " +
			$"{entity.BASAL_DIET_ID}, " +
			$"{entity.BASAL_DIET_CODE.ToSqlValue()}, " +
			$"{entity.BASAL_DIET_NAME.ToSqlValue()}," +
			$"{ingredients.ToSqlValue()}," +
			$"{entity.CREATE_NAME.ToSqlValue()}" +
			"";

		await _unitOfWork.ExecuteAsync(sql);
		return entity;
	}
}
