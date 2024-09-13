using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FeedStuffs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.FeedStuffs;

internal class GetFeedStuffPlanningQueryHandler : IRequestHandler<GetFeedStuffPlanningQueryRequest, GetFeedStuffPlanningQueryResponse>
{
	private readonly IFeedStuffFilter _feedStuffFilter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFeedStuffPlanningQueryHandler(IFeedStuffFilter feedStuffFilter, IMapper mapper, IDietPreparationLogger logger)
	{
		_feedStuffFilter = feedStuffFilter;
		_mapper = mapper;
		_logger = logger;
	}
	public async Task<GetFeedStuffPlanningQueryResponse> Handle(GetFeedStuffPlanningQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var report = await _feedStuffFilter.FilterSortedAsync(request.FilterBy, request.OrderBy, request.Pagination);

			var response = _mapper.Map<GetFeedStuffPlanningQueryResponse>(request.Pagination);

			if (report.Any())
			{
				_mapper.Map(report, response);
			}

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedStuffPlanningQueryResponse>(new DietPreparationException(FeedStuffErrorCode.ReadException));
		}
	}
}