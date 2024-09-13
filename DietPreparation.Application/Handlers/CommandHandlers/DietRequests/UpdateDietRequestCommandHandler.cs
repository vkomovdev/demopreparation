using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Common.Handlers;
using DietPreparation.Application.Validations.CommandValidations;
using DietPreparation.Common.Enums;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.Customers;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class UpdateDietRequestCommandHandler : UpsertDietRequestHandler, IRequestHandler<UpdateDietRequestRequest, UpdateDietRequestResponse>
{
	private readonly IDietRequestUpdater _dietRequestUpdater;
	protected readonly IDietRequestReader _dietRequestReader;
	protected readonly ICustomerReader _customerReader;
	protected readonly ILocationReader _locationReader;
	protected readonly IDrugReader _drugReader;
	protected readonly IPremixReader _premixReader;
	protected readonly IBasalDietReader _basalDietReader;
	private readonly IDietPreparationLogger _logger;

	public UpdateDietRequestCommandHandler(
		IDietRequestUpdater dietRequestUpdater,
		IDietRequestReader dietRequestReader,
		ICustomerReader customerReader,
		ILocationReader locationReader,
		IDrugReader drugReader,
		IPremixReader premixReader,
		IBasalDietReader basalDietReader,
		IMapper mapper,
		IDietPreparationLogger logger,
		DietRequestValidator dietRequestValidator)
			: base(mapper, logger, dietRequestValidator)
	{
		_dietRequestUpdater = dietRequestUpdater;
		_dietRequestReader = dietRequestReader;
		_customerReader = customerReader;
		_locationReader = locationReader;
		_drugReader = drugReader;
		_premixReader = premixReader;
		_basalDietReader = basalDietReader;
		_logger = logger;
	}

	public async Task<UpdateDietRequestResponse> Handle(UpdateDietRequestRequest request, CancellationToken cancellationToken)
	{
		if (request.IsDeleted)
		{
			return _mapper.Map<UpdateDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.UpdateDeletedDietRequest));
		}
		if (request.IsLocked)
		{
			return _mapper.Map<UpdateDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.UpdateLockedDietRequest));
		}

		try
		{
			var dietRequest = _mapper.Map<DietRequestDto>(request);

			if (dietRequest.HasDrugs)
			{
				dietRequest.Drugs = await FillInnerEntityAsync(_drugReader, request.Drugs!);
			}

			if (dietRequest.HasPremixes)
			{
				dietRequest.Premixes = await FillInnerEntityAsync(_premixReader, request.Premixes!);
			}

			if (dietRequest.FeedType == FeedType.Basal)
			{
				dietRequest.BasalDiet = await GetInnerEntityAsync(_basalDietReader, request.BasalDietId);
			}

			dietRequest.Requestor = await GetInnerEntityAsync(_customerReader, request.RequestorId);
			dietRequest.Receiver = await GetInnerEntityAsync(_customerReader, request.ReceiverId);
			dietRequest.Location = await GetInnerEntityAsync(_locationReader, request.LocationId);

			await Validate(dietRequest, cancellationToken);

			return _mapper.Map<UpdateDietRequestResponse>(await _dietRequestUpdater.UpdateAsync(dietRequest));
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<UpdateDietRequestResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<UpdateDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.UpdateException));
		}
	}
}