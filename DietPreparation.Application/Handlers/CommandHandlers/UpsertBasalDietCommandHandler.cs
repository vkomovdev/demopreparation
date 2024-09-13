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

internal class UpsertBasalDietCommandHandler : IRequestHandler<UpdateBasalDietRequest, UpdateBasalDietResponse>
{
	private readonly IBasalDietFilter _basalDietFilter;
	private readonly IBasalDietUpserter _basalDietUpserter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public UpsertBasalDietCommandHandler(
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

	public async Task<UpdateBasalDietResponse> Handle(UpdateBasalDietRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var sameNameBasalDiets = await _basalDietFilter.FilterAsync(new BasalDietFilterDto { Name = request.Name });
			if (sameNameBasalDiets.Any() && sameNameBasalDiets.All(x => x.Id != request.Id))
			{
				return _mapper.Map<UpdateBasalDietResponse>(new DietPreparationException(BasalDietErrorCode.NameShouldBeUnique));
			}

			var sameCodeBasalDiets = await _basalDietFilter.FilterAsync(new BasalDietFilterDto { Code = request.Code });
			if (sameCodeBasalDiets.Any() && sameCodeBasalDiets.All(x => x.Id != request.Id))
			{
				return _mapper.Map<UpdateBasalDietResponse>(new DietPreparationException(BasalDietErrorCode.CodeShouldBeUnique));
			}

			var result = await _basalDietUpserter.UpsertAsync(_mapper.Map<BasalDietDto>(request));
			return _mapper.Map<UpdateBasalDietResponse>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<UpdateBasalDietResponse>(new DietPreparationException(DietRequestErrorCode.UpdateException));
		}
	}
}
