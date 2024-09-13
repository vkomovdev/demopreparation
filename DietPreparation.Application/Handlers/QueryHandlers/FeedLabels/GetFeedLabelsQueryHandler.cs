using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Application.Queries.Responses.FeedLabels;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.FeedLabels;

internal class GetFeedLabelsQueryHandler : IRequestHandler<GetFeedLabelsQueryRequest, GetFeedLabelsQueryResponse>
{
	private readonly IDietRequestFilter _dietRequestSearcher;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFeedLabelsQueryHandler(IDietRequestFilter dietRequestSearcher, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestSearcher = dietRequestSearcher;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFeedLabelsQueryResponse> Handle(GetFeedLabelsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var feedLabels = await _dietRequestSearcher.FilterSortedAsync(request.FilterBy!, request.OrderBy!, request.Pagination!);

			var response = new GetFeedLabelsQueryResponse();
			if (request.Pagination is not null)
			{
				_mapper.Map(request.Pagination, response);
			}
			_mapper.Map(feedLabels, response);

			return response;
		}
		catch (DietPreparationException exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedLabelsQueryResponse>(exception);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedLabelsQueryResponse>(new DietPreparationException(FeedLabelErrorCode.ReadException));
		}
	}
}