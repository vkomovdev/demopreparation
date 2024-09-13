namespace DietPreparation.Models.DTO;

public record AuditMainUpdateDto
{
	public string auChange_Type { get; init; } = string.Empty;
	public string auChange_Reason { get; init; } = string.Empty;
	public string auChange_Operator { get; init; } = string.Empty;
	public string auLotYear { get; init; } = string.Empty;
	public string auLot_ID { get; init; } = string.Empty;
	public string auRequestor_ID { get; init; } = string.Empty;
	public string auDeliver_ID { get; init; } = string.Empty;
	public string auDelivery_Location { get; init; } = string.Empty;
	public string auDelivery_Notice_Yes { get; init; } = string.Empty;
	public string auStudy_Number { get; init; } = string.Empty;
	public string auProject_Number { get; init; } = string.Empty;
	public string auDate_Requested { get; init; } = string.Empty;
	public string auDate_Needed { get; init; } = string.Empty;
	public string auStudy_Type { get; init; } = string.Empty;
	public string auRequest_Type { get; init; } = string.Empty;
	public string auDiet_Name { get; init; } = string.Empty;
	public string auBase_Feed_Type { get; init; } = string.Empty;
	public string auBase_Feed_Name { get; init; } = string.Empty;
	public string auComm_Feed_Lot_Num { get; init; } = string.Empty;
	public string auIntended_Use_Internal_Yes { get; init; } = string.Empty;
	public string auRequest_Amount { get; init; } = string.Empty;
	public string auRequest_UoM { get; init; } = string.Empty;
	public string auForm { get; init; } = string.Empty;
	public string auControlled_Substance { get; init; }= string.Empty;
	public string auToxic_Hazard { get; init; }= string.Empty;
	public string auHazard_Code { get; init; }= string.Empty;
	public string auPackaging_Instructions { get; init; }= string.Empty;
	public string auMixing_Instructions { get; init; }= string.Empty;
	public string auPreMix_Included { get; init; }= string.Empty;
	public string auDrug_Included { get; init; }= string.Empty;
	public string auSample_Included { get; init; } = string.Empty;
}