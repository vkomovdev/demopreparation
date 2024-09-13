namespace DietPreparation.Services.DietRequests.Interfaces;

public interface IDietRequestActivator
{
	Task<bool> ActivateAsync(int requestId);
}