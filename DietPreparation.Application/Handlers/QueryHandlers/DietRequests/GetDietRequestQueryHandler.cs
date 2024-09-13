using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.DietRequests;

internal class GetDietRequestQueryHandler : IRequestHandler<GetDietRequestQueryRequest, GetDietRequestQueryResponse>
{
	private readonly IDietRequestReader _dietRequestReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetDietRequestQueryHandler(IDietRequestReader dietRequestReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestReader = dietRequestReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetDietRequestQueryResponse> Handle(GetDietRequestQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dietRequest = await _dietRequestReader.ReadFullAsync(request.Id!.Value);
			return _mapper.Map<GetDietRequestQueryResponse>(dietRequest);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetDietRequestQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}
