namespace DietPreparation.Services.Tests.Interfaces;

public interface ITestService
{
	Task<bool> IngredientCheckExists(string searchParam, string searchId = "0");
}