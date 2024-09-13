using DietPreparation.Models.DTO;

namespace DietPreparation.Web.Models.PWOs;

public class PwoDrugViewModel
{
	public IEnumerable<PwoDrugDto>? Drugs { get; set; }
	
	public decimal TotalDrugs => Drugs is null ? 0 : Drugs.Sum(x => Math.Round(x.Amount));
	public string TotalDrugsAmount => Drugs is null || !Drugs.Any() ? "" : Drugs.First().AmountUom;
}