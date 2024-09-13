using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Common.Consts;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers;

internal class CreateBatchCommandHandler : IRequestHandler<CreateBatchRequest, CreateBatchResponse>
{
	private readonly IDietRequestReader _dietRequestReader;
	private readonly IPwoCreator _pwoCreater;
	private readonly IDietRequestLocker _dietRequesLocker;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateBatchCommandHandler(
		IDietRequestReader dietRequestReader,
		IPwoCreator pwoCreater,
		IDietRequestLocker dietRequesLocker,
		IMapper mapper,
		IDietPreparationLogger logger)
	{
		_dietRequestReader = dietRequestReader;
		_pwoCreater = pwoCreater;
		_dietRequesLocker = dietRequesLocker;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateBatchResponse> Handle(CreateBatchRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var preTestResult = await _dietRequestReader.PreTestRequestAsync(request.RequestId);

			if (preTestResult != DefaultStrings.OK)
			{
				throw new DietPreparationException(CommonErrorCode.UnprocessableEntity, preTestResult);
			}

			var totals = CalculateBatches(request);

			if (totals.largestBatch > request.MaxCapacity)
			{
				throw new DietPreparationException(CommonErrorCode.UnprocessableEntity, $"The largest batch size is greater than the limit of {request.MaxCapacity}");
			}

			if (totals.globalTotal != request.RequestAmount)
			{
				throw new DietPreparationException(CommonErrorCode.UnprocessableEntity, "Unscheduled amount must be zero to continue.");
			}

			var model = _mapper.Map<CreateBatchRequest, CreateBatchDto>(request);

			await _pwoCreater.CreateWorkOrderAsync(model);
			await _dietRequesLocker.LockRequestTableAsync(model.RequestId);

			return _mapper.Map<CreateBatchResponse>(model);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateBatchResponse>(new DietPreparationException(DietRequestErrorCode.CreateException));
		}
	}

	private (int globalTotal, int largestBatch) CalculateBatches(CreateBatchRequest request)
	{
		var gTotal = 0;
		var largestBatch = 0;
		//var Operator = frmPost.hdnOperator.value Session("UserID")

		if (request.BatchSize is null || request.BatchNumbers is null)
		{
			return (gTotal, largestBatch);
		}

		for (int i = 0; i < request.BatchSize.Count(); i++)
		{
			gTotal = gTotal + request.BatchSize.ElementAt(i) * request.BatchNumbers.ElementAt(i);

			if (request.BatchSize.ElementAt(i) > largestBatch)
			{
				largestBatch = request.BatchSize.ElementAt(i);
			}
		}

		return (gTotal, largestBatch);
	}
}