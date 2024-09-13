using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Application.Commands.Responses.FeedStuffs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.FeedStuffs.Interfaces;
using DietPreparation.Services.Tests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.FeedStuffs;

public class UpdateFeedStuffCommandHandler : IRequestHandler<UpdateFeedStuffRequest, UpdateFeedStuffResponse>
{
	private readonly IFeedStuffUpdater _feedStuffUpdater;
	private readonly ITestService _testService;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public UpdateFeedStuffCommandHandler(IFeedStuffUpdater feedStuffUpdater, ITestService testService, IMapper mapper, IDietPreparationLogger logger)
	{
		_feedStuffUpdater = feedStuffUpdater;
		_testService = testService;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<UpdateFeedStuffResponse> Handle(UpdateFeedStuffRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var updateDto = _mapper.Map<FeedStuffDto>(request);

			if (await _testService.IngredientCheckExists(request.Name, request.Id))
			{
				throw new DietPreparationException(FeedStuffErrorCode.DuplicateNameNotAllowed);
			}

			await _feedStuffUpdater.UpdateAsync(updateDto);
			return _mapper.Map<UpdateFeedStuffResponse>(updateDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<UpdateFeedStuffResponse>(new DietPreparationException(FeedStuffErrorCode.UpdateException));
		}
	}
}