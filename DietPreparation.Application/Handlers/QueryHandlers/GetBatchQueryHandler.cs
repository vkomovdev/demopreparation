using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.Enums;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.ExternalFeeds;
using DietPreparation.Services.InternalFeeds;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetBatchQueryHandler : IRequestHandler<GetBatchQueryRequest, GetBatchQueryResponse>
{
	private readonly IDietRequestReader _dietRequestReader;
	private readonly IBasalDietReader _basalDietReader;
	private readonly IInternalFeedReader _internalFeedReader;
	private readonly IExternalFeedReader _externalFeedReader;
	private readonly IPremixReader _premixReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetBatchQueryHandler(
		IDietRequestReader dietRequestReader,
		IBasalDietReader basalDietReader,
		IInternalFeedReader internalFeedReader,
		IExternalFeedReader externalFeedReader,
		IPremixReader premixReader,
		IMapper mapper,
		IDietPreparationLogger logger)
	{
		_dietRequestReader = dietRequestReader;
		_basalDietReader = basalDietReader;
		_internalFeedReader = internalFeedReader;
		_externalFeedReader = externalFeedReader;
		_premixReader = premixReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetBatchQueryResponse> Handle(GetBatchQueryRequest request, CancellationToken cancellationToken)
	{
		if (!request.RequestId.HasValue)
		{
			throw new ArgumentNullException(nameof(request.RequestId));
		}

		try
		{
			var dietRequest = await _dietRequestReader.ReadAsync(request.RequestId.Value);

			if (dietRequest is null)
			{
				throw new DietPreparationException(CommonErrorCode.UnprocessableEntity);
			}

			var response = _mapper.Map<GetBatchQueryResponse>(dietRequest);

			switch (dietRequest.FeedType)
			{
				case FeedType.Basal:
					response.RecordId = await _basalDietReader.ReadRecordIdByRequestIdAsync(request.RequestId.Value);
					break;
				case FeedType.Internal:
					response.RecordId = await _internalFeedReader.ReadRecordIdByRequestIdAsync(request.RequestId.Value);
					break;
				case FeedType.External:
					response.RecordId = await _externalFeedReader.ReadRecordIdByRequestIdAsync(request.RequestId.Value);
					break;
			}

			response.IsAllPreMixesProcessed = await _premixReader.IsAllProcessedAsync(request.RequestId.Value);

			if (dietRequest.UnitOfMeasure.HasValue)
			{
				response.MaxCapacity = await _dietRequestReader.ReadMaxCapacityAsync(dietRequest.UnitOfMeasure.Value);
			}

			//OperatorId = OperatorId

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetBatchQueryResponse>(new DietPreparationException(BatchErrorCode.ReadException));
		}
	}
}
