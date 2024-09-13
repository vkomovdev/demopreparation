using DietPreparation.Common.Consts;

namespace DietPreparation.Models.DAO;
public record DietRequestDao
{
	public int REQUEST_ID { get; init; }
	public int? LOT_YEAR { get; init; }
	public int? LOT_ID { get; init; }
	public string? LOT { get; init; }
	public int? REQUESTOR_ID { get; init; }
	public int? DELIVER_TO_ID { get; init; }
	public int? LOCATION_ID { get; init; }
	public bool? DELIVERY_NOTE { get; init; }
	public string? PROTOCOL { get; init; }
	public string? STUDY_NUMBER { get; init; }
	public string? PROJECT_NUMBER { get; init; }
	public DateTime? DATE_REQUEST { get; init; }
	public DateTime? DATE_NEEDED { get; init; }
	public string? STUDY_TYPE { get; init; }
	public string? REQUEST_TYPE { get; init; }
	public string? DIET_NAME { get; init; }
	public string? FEED_TYPE { get; init; }
	public string? INTENDED_USE { get; init; }
	/// <summary>Any premixes included or not</summary>
	public bool? PREMIX { get; init; }
	/// <summary>Any drugs included or not</summary>
	public bool? DRUG { get; init; }
	/// <summary>Any samples included or not </summary>
	public bool? SAMPLE { get; init; }
	public decimal? REQUEST_AMOUNT { get; init; }
	/// <summary>Unit of Measure</summary>
	public string? REQUEST_UOM { get; init; }
	public string? FORM { get; init; }
	public bool? CONTROLLED_SUBSTANCE { get; init; }
	public string? TOXIC_HAZARD { get; init; }
	public string? HAZARD_CODE { get; init; }
	public string? PACKING_INSTRUCTIONS { get; init; }
	public string? MIXING_INSTRUCTIONS { get; init; }
	public bool LOCK { get; init; } = false;
	public string USEDASTEMPLATE { get; init; } = DefaultStrings.No;
	public string ISDELETED { get; init; } = DefaultStrings.No;
	public bool? PreMixUsed { get; init; } = false;
	public string? GENERAL_COMMENTS { get; init; }

	#region Location

	public string DELIVER_DESCRIPTION { get; init; } = string.Empty;
	public string DELIVER_BUILDING { get; init; } = string.Empty;
	public string DELIVER_FLOOR { get; init; } = string.Empty;
	public string DELIVER_LAB { get; init; } = string.Empty;
	public int BUSINESS_UNIT_NUMBER { get; init; }

	#endregion

	#region Requestor

	/// <summary> Requestor First Name </summary>
	public string Fname { get; init; } = string.Empty;

	/// <summary> Requestor Last Name </summary>
	public string Lname { get; init; } = string.Empty;
	public string FIRST_NAME { get; init; } = string.Empty;
	public string LAST_NAME { get; init; } = string.Empty;

	#endregion

	#region Reciever

	/// <summary> Reciever First Name </summary>
	public string dFname { get; init; } = string.Empty;

	/// <summary> Reciever Last Name </summary>
	public string dLname { get; init; } = string.Empty;

	#endregion

	#region PWOs
	public bool PWO_CLOSED { get; init; }
	public bool PWOS_PRINTED { get; init; }
	public int SEQUENCE { get; init; }
	public int TotalItems { get; init; }
	public string? COMPLETED_BY { get; init; }
	public DateTime COMPLETED_DATE { get; init; }
	public string REQUESTOR { get; init; }
	public string? RECEIVER { get; init; }
	#endregion
}
