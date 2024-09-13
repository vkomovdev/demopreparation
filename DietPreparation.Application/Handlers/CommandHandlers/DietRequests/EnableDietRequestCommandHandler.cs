using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class EnableDietRequestCommandHandler : IRequestHandler<EnableDietRequestRequest, EnableDietRequestResponse>
{
	private readonly IDietRequestUpdater _dietRequestUpdater;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public EnableDietRequestCommandHandler(IDietRequestUpdater dietRequestUpdater, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestUpdater = dietRequestUpdater;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<EnableDietRequestResponse> Handle(EnableDietRequestRequest request, CancellationToken cancellationToken)
	{
		try
		{
			await _dietRequestUpdater.EnableAsync(request.Id!.Value);

			return new EnableDietRequestResponse { Id = request.Id!.Value };
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<EnableDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.UpdateException));
		}
	}
}