using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Common.Handlers;
using DietPreparation.Application.Validations.CommandValidations;
using DietPreparation.Common.Enums;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
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

namespace DietPreparation.Application.Handlers.CommandHandlers.AuditLogs;

internal class CreateDietRequestWithAuditCommandHandler : UpsertDietRequestHandler, IRequestHandler<CreateDietRequestWithAuditRequest, CreateDietRequestResponse>
{
	private readonly IDietRequestCreator _dietRequestCreator;
	private readonly ICustomerReader _customerReader;
	private readonly ILocationReader _locationReader;
	private readonly IDrugReader _drugReader;
	private readonly IPremixReader _premixReader;
	private readonly IBasalDietReader _basalDietReader;
	private readonly IDietPreparationLogger _logger;

	public CreateDietRequestWithAuditCommandHandler(
		IDietRequestCreator dietRequestCreator,
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
		_dietRequestCreator = dietRequestCreator;
		_customerReader = customerReader;
		_locationReader = locationReader;
		_drugReader = drugReader;
		_premixReader = premixReader;
		_basalDietReader = basalDietReader;
		_logger = logger;
	}

	public async Task<CreateDietRequestResponse> Handle(CreateDietRequestWithAuditRequest request, CancellationToken cancellationToken)
	{
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

			if (dietRequest.FeedType is FeedType.Basal)
			{
				dietRequest.BasalDiet = await GetInnerEntityAsync(_basalDietReader, request.BasalDietId);
			}

			dietRequest.Requestor = await GetInnerEntityAsync(_customerReader, request.RequestorId);
			dietRequest.Receiver = await GetInnerEntityAsync(_customerReader, request.ReceiverId);
			dietRequest.Location = await GetInnerEntityAsync(_locationReader, request.LocationId);

			await Validate(dietRequest, cancellationToken);

			var audit = _mapper.Map<AuditCreateDto>(request);
			return _mapper.Map<CreateDietRequestResponse>(await _dietRequestCreator.CreateAsync(dietRequest, audit));
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateDietRequestResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.CreateException));
		}
	}
}