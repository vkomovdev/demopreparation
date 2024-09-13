using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;

internal class PwoRepository : IPwoRepository
{
	private const string PwoSelectAll = "DPS_PWO_SELECT_ALL";
	private const string PwoSelectLabelOpen = "DPS_PWO_SELECT_LABEL_OPEN";
	private const string PwoSelectLabelReprint = "DPS_PWO_SELECT_LABEL_REPRINT";
	private const string PwoPremix = "DPS_PWO_PREMIX";
	private const string PwoDrug = "DPS_PWO_DRUG";
	private const string PwoPremixDrug = "DPS_PWO_PREMIX_DRUG";
	private const string PwoIngredient = "DPS_PWO_INGREDIENT";
	private const string PwoHeader = "DPS_PWO_HEADER";
	private const string PwoInsert = "DPS_PWO_INSERT";
	private const string PwoConfirm = "DPS_PWO_CONFIRM";
	private const string PwoClose = "DPS_PWO_CLOSE";

	private readonly IUnitOfWork _unitOfWork;

	public PwoRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task ClosePWOAsync(PwoCloseDto model)
	{
		var cmd =
			$"""
			 {PwoClose} {model.PwoId},
			 '{model.Mixer}',
			 '{model.TimeCompleted}',
			 '{model.Location}',
			 '{model.DateCompleted}',
			 '{model.CompletedBy}',
			 {model.BagCount},
			 '{model.Comment}'
			 """;
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async ValueTask<IEnumerable<PwoHeaderDao>> PWOsAsync(string sColumn, string sSlope)
	{
		var orderBy = sColumn switch
		{
			"LOT" => $"DP_REQUEST.LOT_YEAR {sSlope},  DP_REQUEST.LOT_ID {sSlope}",
			"CUSTOMER_NAME" => $"DP_CUSTOMER.LAST_NAME {sSlope}",
			"DATE" => $"DP_REQUEST.DATE_NEEDED {sSlope}",
			"DIET_NAME" => $"DP_REQUEST.DIET_NAME {sSlope}",
			"AMOUNT" => $"DP_REQUEST.REQUEST_AMOUNT {sSlope}",
			"UOM" => $"DP_REQUEST.REQUEST_UOM {sSlope}",
			_ => ""
		};

		var cmd = $"DPS_PWO_SEARCH '{orderBy}'";

		// GET THE REQUEST LIST ORDERED AS PRESCRIBED
		return await _unitOfWork.QueryAsync<PwoHeaderDao>(cmd);
	}

	public async Task ConfirmPWO(string iPWO_ID, string iType)
	{
		//iType is "PWO" or "Label"
		var cmd = $"{PwoConfirm} {iPWO_ID}, '{iType}'";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task InsertBatchAsync(CreateBatchDto model)
	{
		for (int i = 0; i < model.BatchSize.Count; i++)
		{
			var cmd = $"{PwoInsert} {model.RequestId}, '{model.FeedType}', '{model.FeedId}', '{model.BatchSize[i]}', '{model.BatchUom.GetDatabaseValue()}', '{model.Operator}'";

			for (int j = 0; j < model.BatchNumbers[i]; j++)
			{
				await _unitOfWork.ExecuteAsync(cmd);
			}
		}
	}

	public async ValueTask<PwoHeaderDao> ReadPwoHeaderAsync(int requestId, int pwoId)
	{
		return await _unitOfWork.QueryFirstAsync<PwoHeaderDao>($"{PwoHeader} {requestId}, {pwoId}");
	}

	public async ValueTask<IEnumerable<PwoIngredientDao>> ReadPwoIngredientsAsync(int pwoId)
	{
		return await _unitOfWork.QueryAsync<PwoIngredientDao>($"{PwoIngredient} {pwoId}");
	}

	public async ValueTask<IEnumerable<PwoDrugDao>> ReadPwoDrugsAsync(int pwoId)
	{
			return await _unitOfWork.QueryAsync<PwoDrugDao>($"{PwoDrug} {pwoId}");
	}

	public async ValueTask<IEnumerable<PwoPremixDrugDao>> ReadPwoPremixDrugsAsync(int pwoId)
	{
		return await _unitOfWork.QueryAsync<PwoPremixDrugDao>($"{PwoPremixDrug} {pwoId}");
	}

	public async ValueTask<IEnumerable<PwoPremixDao>> ReadPwoPremixesAsync(int pwoId)
	{
		return await _unitOfWork.QueryAsync<PwoPremixDao>($"{PwoPremix} {pwoId}");
	}

	public async ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllAsync(int requestId)
	{
		return await _unitOfWork.QueryAsync<PwoSelectAllDao>($"{PwoSelectAll} {requestId}");
	}

	public async ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllForLabelOpenAsync(int requestId)
	{
		return await _unitOfWork.QueryAsync<PwoSelectAllDao>($"{PwoSelectLabelOpen} {requestId}");
	}

	public async ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllForLabelReprintAsync(int requestId)
	{
		return await _unitOfWork.QueryAsync<PwoSelectAllDao>($"{PwoSelectLabelReprint} {requestId}");
	}
}