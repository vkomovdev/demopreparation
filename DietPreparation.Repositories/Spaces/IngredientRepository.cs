using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;

internal class IngredientRepository : IIngredientRepository
{
	private const string IngredientSelect = "DPS_INGREDIENT_SELECT";
	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public IngredientRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async ValueTask<IEnumerable<IngredientDao>> ReadAllAsync()
		=> await _unitOfWork.QueryAsync<IngredientDao>(IngredientSelect);
}