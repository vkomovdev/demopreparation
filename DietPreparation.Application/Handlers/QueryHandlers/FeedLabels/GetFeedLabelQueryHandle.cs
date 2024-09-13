using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Application.Queries.Responses.FeedLabels;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FeedLabels.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.FeedLabels;

internal class GetFeedLabelQueryHandler : IRequestHandler<GetFeedLabelQueryRequest, GetFeedLabelQueryResponse>
{
	private readonly IFeedLabelReader _feedLabelReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFeedLabelQueryHandler(IFeedLabelReader feedLabelReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_feedLabelReader = feedLabelReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFeedLabelQueryResponse> Handle(GetFeedLabelQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dto = await _feedLabelReader.ReadAsync(request.Id!.Value, request.Sequence!.Value);

			var response = new GetFeedLabelQueryResponse();
			_mapper.Map(dto, response);
			_mapper.Map(request, response);

			return response;
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedLabelQueryResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedLabelQueryResponse>(new DietPreparationException(FeedLabelErrorCode.ReadException));
		}
	}
}