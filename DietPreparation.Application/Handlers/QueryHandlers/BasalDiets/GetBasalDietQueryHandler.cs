using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.Ingredient;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.BasalDiets;

internal class GetBasalDietQueryHandler : IRequestHandler<GetBasalDietQueryRequest, GetBasalDietQueryResponse>
{
	private readonly IBasalDietReader _basalDietReader;
	private readonly IBasalDietFilter _basalDietFilter;
	private readonly IIngredientReader _ingredientReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetBasalDietQueryHandler(
		IBasalDietReader basalDietReader,
		IBasalDietFilter basalDietFilter,
		IIngredientReader ingredientReader,
		IMapper mapper,
		IDietPreparationLogger logger)
	{
		_basalDietReader = basalDietReader;
		_basalDietFilter = basalDietFilter;
		_ingredientReader = ingredientReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetBasalDietQueryResponse> Handle(GetBasalDietQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var basalDiet = await _basalDietReader.ReadAsync(request.BasalDietId);
			var basalDietIngredients = await _basalDietFilter.FilterIngredientsAsync(_mapper.Map<BasalDietIngredientFilterDto>(request));
			_mapper.Map(basalDietIngredients, basalDiet);

			var ingredients = await _ingredientReader.ReadAllAsync();

			var response = new GetBasalDietQueryResponse();
			_mapper.Map(basalDiet, response);
			_mapper.Map(ingredients, response);

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetBasalDietQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}