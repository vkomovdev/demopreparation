using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers;

internal class CreateBasalDietCommandHandler : IRequestHandler<CreateBasalDietRequest, CreateBasalDietResponse>
{
	private readonly IBasalDietUpserter _basalDietUpserter;
	private readonly IBasalDietFilter _basalDietFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateBasalDietCommandHandler(
		IBasalDietUpserter basalDietUpserter,
		IBasalDietFilter basalDietFilter,
		IMapper mapper,
		IDietPreparationLogger logger)
	{
		_basalDietUpserter = basalDietUpserter;
		_basalDietFilter = basalDietFilter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateBasalDietResponse> Handle(CreateBasalDietRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var sameNameBasalDiets = await _basalDietFilter.FilterAsync(new BasalDietFilterDto { Name = request.Name });
			if (sameNameBasalDiets.Any())
			{
				return _mapper.Map<CreateBasalDietResponse>(new DietPreparationException(BasalDietErrorCode.NameShouldBeUnique));
			}

			var sameCodeBasalDiets = await _basalDietFilter.FilterAsync(new BasalDietFilterDto { Code = request.Code });
			if (sameCodeBasalDiets.Any())
			{
				return _mapper.Map<CreateBasalDietResponse>(new DietPreparationException(BasalDietErrorCode.CodeShouldBeUnique));
			}

			var result = await _basalDietUpserter.UpsertAsync(_mapper.Map<BasalDietDto>(request));
			return _mapper.Map<CreateBasalDietResponse>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateBasalDietResponse>(new DietPreparationException(DietRequestErrorCode.CreateException));
		}
	}
}