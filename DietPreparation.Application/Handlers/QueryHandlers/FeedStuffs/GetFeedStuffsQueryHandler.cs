using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FeedStuffs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.FeedStuffs;

internal class GetFeedStuffsQueryHandler : IRequestHandler<GetFeedStuffsQueryRequest, GetFeedStuffsQueryResponse>
{
	private readonly IFeedStuffReader _reader;
	private readonly IFeedStuffFilter _filter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFeedStuffsQueryHandler(IFeedStuffReader reader, IFeedStuffFilter filter, IMapper mapper, IDietPreparationLogger logger)
	{
		_reader = reader;
		_filter = filter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFeedStuffsQueryResponse> Handle(GetFeedStuffsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var feedStuffList = request.OrderBy is null
				? await _reader.ReadAllAsync()
				: await _filter.SortAsync(request.OrderBy);

			return _mapper.Map<GetFeedStuffsQueryResponse>(feedStuffList);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedStuffsQueryResponse>(new DietPreparationException(FeedStuffErrorCode.ReadException));
		}
	}
}