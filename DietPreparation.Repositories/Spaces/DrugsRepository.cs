using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;
using System.Text;

namespace DietPreparation.Repositories.Spaces;

internal class DrugsRepository : IDrugsRepository
{
	private const string ReadStoredProcedure = "DPS_DRUG_SELECT";
	private const string CreateUpdateDrugStoredProcedure = "DPS_DRUG_IU";

	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public DrugsRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}
	public async ValueTask<IEnumerable<DrugDao>> ReadAllAsync()
	{
		string sql = await _queryFactory.BuildReadDrugsQuery();
		return await _unitOfWork.QueryAsync<DrugDao>(sql);
	}

	public async Task AuditDrugUpdate(string iAuditLogNumber,
					string sDrug_Name,
					 string sDrugNeeded,
					 string sDrugNeededUOM,
					 string sDrugWeightYN,
					 string sMfgLot)
	{

		// CREATE ARRAYS CONTAINING THE REQUEST DRUG INFORMATION
		var aDrugName = sDrug_Name.Split(",");
		var aDrugNeeded = sDrugNeeded.Split(",");
		var aDrugNeededUOM = sDrugNeededUOM.Split(",");
		var aDrugWeightYN = sDrugWeightYN.Split(",");
		var aMfgLot = sMfgLot.Split(",");
		var lenDrug = aDrugName.Length;

		for (var i = 0; i < lenDrug; i++)
		{
			var cmd = $"""
			           DPS_LOG_TO_AUDIT_DRUG {iAuditLogNumber}, '
			           {aDrugName[i]}',
			           {aDrugNeeded[i]},
			           '{aDrugNeededUOM[i]}',
			           {aDrugWeightYN[i]},
			           '{aMfgLot[i]}'
			           """;
			await _unitOfWork.ExecuteAsync(cmd);
		}
	}

	public async ValueTask<IEnumerable<DrugDao>> GetDrugsAsync(string sColumn, string sSlope, string sDrug_ID)
	{
		var orderBy = string.Empty;
		if (sColumn != string.Empty)
		{
			orderBy = sColumn;
		}
		if (sSlope != string.Empty)
		{
			orderBy += $" {sSlope}";
		}

		var cmd = $"DPS_DRUG_SELECT {sDrug_ID}, ";

		if (orderBy != string.Empty)
		{
			cmd += $"'{orderBy}'";
		}
		else
		{
			cmd += "NULL";
		}

		return await _unitOfWork.QueryAsync<DrugDao>(cmd);
	}   // GetDrugs

	public async ValueTask<string?> DrugUpdate(DrugUpdateDto model)
	{
		var cmd = $"{CreateUpdateDrugStoredProcedure} {model.Id}, '{model.Name}', {model.ActiveIngredientConcentration}, '{model.UnitOfMeasure.GetDisplayName()}', '{model.UserId}'";
		return await _unitOfWork.QueryFirstOrDefaultAsync<string?>(cmd);
	}

	public async ValueTask<IEnumerable<IngredientDao>> GetIngredientsAsync()
	{
		var cmd = "DPS_INGREDIENT_SELECT";
		return await _unitOfWork.QueryAsync<IngredientDao>(cmd);
	}

	public async Task<DrugDao> ReadAsync(int id)
	{
		return await _unitOfWork.QuerySingleAsync<DrugDao>($"{ReadStoredProcedure} {id}");
	}

	public async ValueTask<IEnumerable<DrugsItemDao>> GetPaginatedDrugAsync(OrderByDao orderByDao, PaginationDao paginationDao)
	{
		var orderBy = orderByDao is null ? " ORDER BY (SELECT NULL) " : $" ORDER BY {orderByDao.ORDER_BY} ";
		var parameters = new Dictionary<string, object>
		{
			{ "@orderBy", orderBy },
			{ "@pageSize", paginationDao.PageSize},
			{ "@page", paginationDao.Page}
		};

		var sql = BuildQueryWithParameters(await _queryFactory.BuildGetPaginatedDrugListQuery(), parameters);
		var result = await _unitOfWork.QueryAsync<DrugsItemDao>(sql);

		return result;
	}

	private string BuildQueryWithParameters(string sql, Dictionary<string, object> parameters)
	{
		var sqlWithParameters = new StringBuilder(sql);
		foreach (var param in parameters)
		{
			sqlWithParameters.Replace(param.Key, param.Value.ToString());
		}
		return sqlWithParameters.ToString();
	}
}
