using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Ingredient;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQueryRequest, GetIngredientsQueryResponse>
{
	private readonly IIngredientReader _ingredientReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetIngredientsQueryHandler(IIngredientReader ingredientReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_ingredientReader = ingredientReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetIngredientsQueryResponse> Handle(GetIngredientsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var ingredients = await _ingredientReader.ReadAllAsync();

			return _mapper.Map<GetIngredientsQueryResponse>(ingredients);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetIngredientsQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}