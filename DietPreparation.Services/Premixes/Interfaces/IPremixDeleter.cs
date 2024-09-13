namespace DietPreparation.Services.Premixes.Interfaces;

public interface IPremixDeleter
{
	Task<int> DeleteByRequestIdAsync(int requestId);
}
