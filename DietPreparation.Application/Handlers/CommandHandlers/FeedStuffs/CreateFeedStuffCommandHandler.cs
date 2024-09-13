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

public class CreateFeedStuffCommandHandler : IRequestHandler<CreateFeedStuffRequest, CreateFeedStuffResponse>
{
	private readonly IFeedStuffUpdater _feedStuffUpdater;
	private readonly ITestService _testService;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateFeedStuffCommandHandler(IFeedStuffUpdater feedStuffUpdater, ITestService testService, IMapper mapper, IDietPreparationLogger logger)
	{
		_feedStuffUpdater = feedStuffUpdater;
		_testService = testService;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateFeedStuffResponse> Handle(CreateFeedStuffRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var updateEntity = _mapper.Map<FeedStuffDto>(request);

			if (await _testService.IngredientCheckExists(request.Name))
			{
				throw new DietPreparationException(FeedStuffErrorCode.DuplicateNameNotAllowed);
			}

			await _feedStuffUpdater.UpdateAsync(updateEntity);
			return _mapper.Map<CreateFeedStuffResponse>(updateEntity);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateFeedStuffResponse>(new DietPreparationException(FeedStuffErrorCode.ReadException));
		}
	}
}