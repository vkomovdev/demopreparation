using DietPreparation.Application.Validations.CommandValidations;
using DietPreparation.Common.Interfaces;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;

namespace DietPreparation.Application.Common.Handlers;

internal abstract class UpsertDietRequestHandler
{
	protected readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;
	private readonly DietRequestValidator _dietRequestValidator;

	public UpsertDietRequestHandler(IMapper mapper, IDietPreparationLogger logger, DietRequestValidator dietRequestValidator)
	{
		_mapper = mapper;
		_logger = logger;
		_dietRequestValidator = dietRequestValidator;
	}

	protected virtual async Task<IEnumerable<T>> FillInnerEntityAsync<T, U>(ICommonRead<int, U> reader, IEnumerable<T> requestEntity) where T : DietRequestInnerEntityDto where U : class
	{
		if (requestEntity is null)
		{
			return Enumerable.Empty<T>();
		}

		try
		{
			var filledEntityList = new List<T>();
			foreach (var entity in requestEntity.Where(x => x.InnerEntityId.HasValue))
			{
				var filledEntity = await reader.ReadAsync(entity.InnerEntityId!.Value);
				_mapper.Map(filledEntity, entity);
				filledEntityList.Add(entity);
			}
			return filledEntityList;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			throw new DietPreparationException(CommonErrorCode.EntityNotFound);
		}
	}

	protected virtual async Task<T> GetInnerEntityAsync<T>(ICommonRead<int, T> reader, int? basalDietId) where T : class
	{
		if (!basalDietId.HasValue)
		{
			throw new DietPreparationException(CommonErrorCode.EntityNotFound);
		}

		try
		{
			return await reader.ReadAsync(basalDietId.Value);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			throw new DietPreparationException(CommonErrorCode.EntityNotFound);
		}
	}

	protected virtual async Task Validate(DietRequestDto dietRequest, CancellationToken cancellationToken)
	{
		var validationResult = await _dietRequestValidator.ValidateAsync(dietRequest, cancellationToken);

		var failures = validationResult.Errors.Where(failure => failure is not null);

		if (failures.Any())
		{
			var dietErrors = failures
				.Select(src => new DietPreparationError(
					src.ErrorCode,
					ErrorCodesDescriptionStore.GetDescription(src.ErrorCode) ?? src.ErrorMessage,
					src.PropertyName));

			throw new DietPreparationException(dietErrors);
		}
	}
}
