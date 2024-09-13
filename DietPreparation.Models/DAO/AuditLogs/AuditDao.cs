namespace DietPreparation.Models.DAO.AuditLogs;
public record AuditDao
{
	public int AuditLogNumber { get; init; }
	public string? Change_Type { get; init; }
	public string? Change_Reason { get; init; }
	public string? Change_Operator { get; init; }
	public DateTime? Change_Timestamp { get; init; }
	public string? Lot_Year { get; init; }
	public int? Lot_ID { get; init; }
	public int? Requestor_ID { get; init; }
	public int? Deliver_ID { get; init; }
	public string? Location_String { get; init; }
	public bool? Delivery_Notice_Yes { get; init; }
	public string? Protocol { get; init; }
	public string? Study_Number { get; init; }
	public string? Project_Number { get; init; }
	public string? Date_Requested { get; init; }
	public string? Date_Needed { get; init; }
	public string? Study_Type { get; init; }
	public string? Request_Type { get; init; }
	public string? Diet_Name { get; init; }
	public string? Base_Feed_Type { get; init; }
	public string? Base_Feed_Name { get; init; }
	public string? Comm_Feed_Lot_Num { get; init; }
	public bool? Intended_Use_Internal { get; init; }
	public decimal? Request_Amount { get; init; }
	public string? Request_UOM { get; init; }
	public string? Form { get; init; }
	public bool? Controlled_Substance { get; init; }
	public string? Toxic_Hazard { get; init; }
	public string? Hazard_Code { get; init; }
	public string? Packing_Instructions { get; init; }
	public string? Mixing_Instructions { get; init; }
	public bool? Premix_Included { get; init; }
	public bool? Drug_Included { get; init; }
	public bool? Sample_Included { get; init; }
}
