namespace DietPreparation.Services.Samples.Interfaces;

public interface ISampleDeleter
{
	Task<int> DeleteByRequestIdAsync(int requestId);
}
