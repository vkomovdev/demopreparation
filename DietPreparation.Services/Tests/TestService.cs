using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Tests.Interfaces;

namespace DietPreparation.Services.Tests;

internal class TestService : ITestService
{
	private const string IngredientTableName = "INGREDIENT";
	private readonly ITestRepository _testRepository;

	public TestService(ITestRepository testRepository)
	{
		_testRepository = testRepository;
	}

	public async Task<bool> IngredientCheckExists(string searchParam, string searchId = "0")
	{
		return await _testRepository.CheckExists(IngredientTableName, searchParam, searchId);
	}
}