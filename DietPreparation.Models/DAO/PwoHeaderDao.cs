namespace DietPreparation.Models.DAO;
public record PwoHeaderDao
{
	public int LOT_YEAR { get; init; }
	public int LOT_ID { get; init; }
	public int SEQUENCE { get; init; }
	public string FIRST_NAME { get; init; } = string.Empty;
	public string LAST_NAME { get; init; } = string.Empty;
	public DateTime DATE_REQUEST { get; init; }
	public DateTime DATE_NEEDED { get; init; }
	public string DIET_NAME { get; init; } = string.Empty;
	public string PROJECT_NUMBER { get; init; } = string.Empty;
	public string STUDY_NUMBER { get; init; } = string.Empty;
	public string PROTOCOL { get; init; } = string.Empty;
	public string STUDY_TYPE { get; init; } = string.Empty;
	public string REQUEST_TYPE { get; init; } = string.Empty;
	public string FEED_TYPE { get; init; } = string.Empty;
	public string INTENDED_USE { get; init; } = string.Empty;
	public string FORM { get; init; } = string.Empty;
	public string PACKING_INSTRUCTIONS { get; init; } = string.Empty;
	public string MIXING_INSTRUCTIONS { get; init; } = string.Empty;
	public int DELIVER_TO_ID { get; init; }
	public int LOCATION_ID { get; init; }
	public decimal REQUEST_AMOUNT { get; init; }
	public string REQUEST_UOM { get; init; } = string.Empty;
	public decimal BATCH_WEIGHT { get; init; }
	public string BATCH_UOM { get; init; } = string.Empty;
	public bool CONTROLLED_SUBSTANCE { get; init; }
	public string TOXIC_HAZARD { get; init; } = string.Empty;
	public string HAZARD_CODE { get; init; } = string.Empty;
	public bool SAMPLE { get; init; }
	public int PWO_ID { get; init; }
	public string MIXER { get; init; } = string.Empty;
	public string LOCATION { get; init; } = string.Empty;
	public string COMPLETED_TIME { get; init; } = string.Empty;
	public DateTime COMPLETED_DATE { get; init; }
	public string COMPLETED_BY { get; init; } = string.Empty;
	public string COMMENT { get; init; } = string.Empty;
	public int BAG_COUNT { get; init; }
	public string PLANNER { get; init; } = string.Empty;
}
