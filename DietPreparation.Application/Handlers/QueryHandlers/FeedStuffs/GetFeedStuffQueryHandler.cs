using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.FeedStuffs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.FeedStuffs;

internal class GetFeedStuffQueryHandler : IRequestHandler<GetFeedStuffQueryRequest, GetFeedStuffQueryResponse>
{
	private readonly IFeedStuffReader _feedStuffReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetFeedStuffQueryHandler(IFeedStuffReader feedStuffReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_feedStuffReader = feedStuffReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetFeedStuffQueryResponse> Handle(GetFeedStuffQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var feedStuff = await _feedStuffReader.ReadAsync(request.FeedStuffId)
				?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			return _mapper.Map<GetFeedStuffQueryResponse>(feedStuff);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetFeedStuffQueryResponse>(new DietPreparationException(FeedStuffErrorCode.ReadException));
		}
	}
}