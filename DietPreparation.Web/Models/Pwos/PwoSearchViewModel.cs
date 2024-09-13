namespace DietPreparation.Web.Models.PWOs;

public class PwoSearchViewModel
{
	public List<PwoSearchRowItem> DietRequests { get; set; }
	public string Filter { get; set; }
	public string LotYear { get; set; }
	public string LotNumber { get; set; }
	public string Requestor { get; set; }
	public string DietName { get; set; }
	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
	public string PreFilter { get; set; }
}
