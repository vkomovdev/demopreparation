using DietPreparation.Common.Enums;
using DietPreparation.Web.Models.PWOs;

namespace DietPreparation.Web.Models.FeedLabels;

public class FeedLabelBatchListViewModel : PwoBatchListViewModel
{
	public FeedLabelsType Type { get; set; }
}