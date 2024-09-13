using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;
internal class AuditRepository : IAuditRepository
{
	private const string AuditLookup = "DPS_AUDIT_LOOKUP";
	private const string AuditDrugList = "DPS_AUDIT_DRUG_LIST";
	private const string AuditPremixList = "DPS_AUDIT_PREMIX_LIST";
	private const string AuditSampleList = "DPS_AUDIT_SAMPLES_LIST";

	private const string LogToAuditMain = "DPS_LOG_TO_AUDIT_MAIN";
	private const string LogToAuditDrug = "DPS_LOG_TO_AUDIT_DRUG";
	private const string LogToAuditPremix = "DPS_LOG_TO_AUDIT_PREMIX";
	private const string LogToAuditSample = "DPS_LOG_TO_AUDIT_SAMPLE";

	private readonly IUnitOfWork _unitOfWork;

	public AuditRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<AuditDao> ReadAsync(int id)
	{
		var sql = $"{AuditLookup} {id}";
		var result = await _unitOfWork.QuerySingleAsync<AuditDao>(sql);
		return result;
	}

	public async Task<IEnumerable<AuditDrugDao>> ReadDrugsAsync(int auditLogNumber)
	{
		var sql = $"{AuditDrugList} {auditLogNumber}";
		var result = await _unitOfWork.QueryAsync<AuditDrugDao>(sql);
		return result;
	}

	public async Task<IEnumerable<AuditPremixDao>> ReadPremixesAsync(int auditLogNumber)
	{
		var sql = $"{AuditPremixList} {auditLogNumber}";
		var result = await _unitOfWork.QueryAsync<AuditPremixDao>(sql);
		return result;
	}

	public async Task<IEnumerable<AuditSampleDao>> ReadSamplesAsync(int auditLogNumber)
	{
		var sql = $"{AuditSampleList} {auditLogNumber}";
		var result = await _unitOfWork.QueryAsync<AuditSampleDao>(sql);
		return result;
	}

	public async Task<int> CreateDietRequestAuditAsync(AuditDao auditDao)
	{
		var sql = $"{LogToAuditMain} " +
			$"{auditDao.Change_Type.ToSqlValue()}, " +
			$"{auditDao.Change_Reason.ToSqlValue()}, " +
			$"{auditDao.Change_Operator.ToSqlValue()}, " +
			$"{auditDao.Lot_Year.ToSqlValue()}, " +
			$"{auditDao.Lot_ID.ToSqlValue()}, " +
			$"{auditDao.Requestor_ID.ToSqlValue()}, " +
			$"{auditDao.Deliver_ID.ToSqlValue()}, " +
			$"{auditDao.Location_String.ToSqlValue()}, " +
			$"{auditDao.Delivery_Notice_Yes.ToSqlValue()}, " +
			$"{auditDao.Study_Number.ToSqlValue()}, " +
			$"{auditDao.Project_Number.ToSqlValue()}, " +
			$"{auditDao.Date_Requested.ToSqlValue()}, " +
			$"{auditDao.Date_Needed.ToSqlValue()}, " +
			$"{auditDao.Study_Type.ToSqlValue()}, " +
			$"{auditDao.Request_Type.ToSqlValue()}, " +
			$"{auditDao.Diet_Name.ToSqlValue()}, " +
			$"{auditDao.Base_Feed_Type.ToSqlValue()}, " +
			$"{auditDao.Base_Feed_Name.ToSqlValue()}, " +
			$"{auditDao.Comm_Feed_Lot_Num.ToSqlValue()}, " +
			$"{auditDao.Intended_Use_Internal.ToSqlValue()}, " +
			$"{auditDao.Request_Amount.ToSqlValue()}, " +
			$"{auditDao.Request_UOM.ToSqlValue()}, " +
			$"{auditDao.Form.ToSqlValue()}, " +
			$"{auditDao.Controlled_Substance.ToSqlValue()}, " +
			$"{auditDao.Toxic_Hazard.ToSqlValue()}, " +
			$"{auditDao.Hazard_Code.ToSqlValue()}, " +
			$"{auditDao.Packing_Instructions.ToSqlValue()}, " +
			$"{auditDao.Mixing_Instructions.ToSqlValue()}, " +
			$"{auditDao.Premix_Included.ToSqlValue()}, " +
			$"{auditDao.Drug_Included.ToSqlValue()}, " +
			$"{auditDao.Sample_Included.ToSqlValue()}" +
			$"";
		return await _unitOfWork.QuerySingleAsync<int>(sql);
	}

	public async Task<int> CreateDrugAsync(AuditDrugDao auditDrugDao)
	{
		var sql = $"{LogToAuditDrug} " +
			$"{auditDrugDao.AuditLogNumber}, " +
			$"{auditDrugDao.Drug_Name.ToSqlValue()}, " +
			$"{auditDrugDao.Amount.ToSqlValue()}, " +
			$"{auditDrugDao.Amount_UoM.ToSqlValue()}, " +
			$"{auditDrugDao.Drug_In_Weight.ToSqlValue()}, " +
			$"{auditDrugDao.Mfg_Lot.ToSqlValue()}" +
			$"";
		return await _unitOfWork.QuerySingleAsync<int>(sql);
	}

	public async Task<int> CreatePremixAsync(AuditPremixDao auditPremixDao)
	{
		var sql = $"{LogToAuditPremix} " +
			$"{auditPremixDao.AuditLogNumber}, " +
			$"{auditPremixDao.PreMix_Name.ToSqlValue()}, " +
			$"{auditPremixDao.Amount.ToSqlValue()}, " +
			$"{auditPremixDao.Amount_UoM.ToSqlValue()}, " +
			$"{auditPremixDao.Premix_In_Weight.ToSqlValue()}" +
			$"";
		return await _unitOfWork.QuerySingleAsync<int>(sql);
	}

	public async Task<int> CreateSampleAsync(AuditSampleDao auditSampleDao)
	{
		var sql = $"{LogToAuditSample} " +
			$"{auditSampleDao.AuditLogNumber}, " +
			$"{auditSampleDao.Amount.ToSqlValue()}, " +
			$"{auditSampleDao.Amount_UoM.ToSqlValue()}, " +
			$"{auditSampleDao.Disposition.ToSqlValue()}, " +
			$"{auditSampleDao.Analysis_Type.ToSqlValue()}, " +
			$"{auditSampleDao.Comment.ToSqlValue()}" +
			$"";
		return await _unitOfWork.QuerySingleAsync<int>(sql);
	}
}
