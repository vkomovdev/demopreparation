using DietPreparation.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DietPreparation.Web.Models.PWOs;

public class PwoBatchViewModel
{
	public string DietName { get; set; } = string.Empty;
	public int RequestId { get; set; }
	public string FeedType { get; set; }	 = string.Empty;
	public int RecordId { get; set; }
	public UnitOfMeasure RequestUom { get; set; }
	public string Mode { get; set; } = string.Empty; //PWO_Initiate
	public bool JobDone { get; set; }
	public bool? IsAllPreMixesProcessed { get; set; }//sAllPreMixesProcessed
	public int MaxCapacity { get; set; }
	public string Operator { get; set; } = string.Empty;//Session("UserID")
	[Display(Name = nameof(Resources.ContentResources.CustomerName), ResourceType = typeof(Resources.ContentResources))]
	public string? CustomerName { get; set; }// FirstName MiddleInitial LastName
	[Display(Name = nameof(Resources.ContentResources.Lot), ResourceType = typeof(Resources.ContentResources))]
	public string Lot { get; set; } = string.Empty; //LOT_YEAR LOT_ID
	public int BatchSizeKey { get; set; }
	public List<int> BatchSize { get; set; } = new List<int>();
	public List<int> BatchNumbers { get; set; } = new List<int>();
	public decimal RequestAmount { get; set; }
	public bool Lock { get; set; }
	public bool Premix { get; set; }
	public int OperatorId { get; set; }//Session("UserID")
}