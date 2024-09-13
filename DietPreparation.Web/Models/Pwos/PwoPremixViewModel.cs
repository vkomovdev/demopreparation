using DietPreparation.Models.DTO;

namespace DietPreparation.Web.Models.PWOs;

public class PwoPremixViewModel
{
	public IEnumerable<PwoPremixDto>? Premixes { get; set; }
	
	public decimal TotalPremixes => Premixes is null ? 0 : Premixes.Sum(x => Math.Round(x.Amount));
}