namespace DietPreparation.Web.Models.DietRequests;

public class UpdateDietRequestsViewModel
{
	public IEnumerable<UpdateDietRequestItem>? NotUsedMedicatedPremixes { get; set; }
	public IEnumerable<UpdateDietRequestItem>? UsedMedicatedPremixes { get; set; }
	public IEnumerable<UpdateDietRequestItem>? NotClonedDietRequests { get; set; }
	public IEnumerable<UpdateDietRequestItem>? ClonedDietRequests { get; set; }

	public UpdateDietRequestItem? NotUsedMedicatedPremix { get; set; }
	public UpdateDietRequestItem? UsedMedicatedPremix { get; set; }
	public UpdateDietRequestItem? NotClonedDietRequest { get; set; }
	public UpdateDietRequestItem? ClonedDietRequest { get; set; }
}
