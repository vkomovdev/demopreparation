namespace DietPreparation.Services.Drugs.Interfaces;

public interface IDrugDeleter
{
	Task<int> DeleteByRequestIdAsync(int requestId);
}