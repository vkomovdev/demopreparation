using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Ingredient;

internal class IngredientReader : IIngredientReader
{
	private readonly IIngredientRepository _ingredientRepository;
	private readonly IMapper _mapper;

	public IngredientReader(
		IIngredientRepository ingredientRepository,
		IMapper mapper)
	{
		_ingredientRepository = ingredientRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<IngredientDto>> ReadAllAsync()
	{
		var result = await _ingredientRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<IngredientDto>>(result);
	}
}
