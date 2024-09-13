using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.Enums;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetBatchesQueryHandler : IRequestHandler<GetBatchesQueryRequest, GetBatchesQueryResponse>
{
	private readonly IPwoReader _pwoReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetBatchesQueryHandler(IPwoReader pwoReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_pwoReader = pwoReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetBatchesQueryResponse> Handle(GetBatchesQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var batches = request.Type switch
			{
				BatchType.ForLabelOpen => await _pwoReader.ReadPwoSelectAllForLabelOpenAsync(request.RequestId),
				BatchType.ForLabelReprint => await _pwoReader.ReadPwoSelectAllForLabelReprintAsync(request.RequestId),
				_ => await _pwoReader.ReadPwoSelectAllAsync(request.RequestId)
			};

			var response = new GetBatchesQueryResponse { RequestId = request.RequestId };
			_mapper.Map(batches, response);

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetBatchesQueryResponse>(new DietPreparationException(BatchErrorCode.ReadException));
		}
	}
}
