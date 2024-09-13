namespace DietPreparation.Services.DietRequests.Interfaces;
public interface IDietRequestLocker
{
	Task LockRequestTableAsync(int requestId);
}
