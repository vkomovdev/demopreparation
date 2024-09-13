using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class DisableDietRequestCommandHandler : IRequestHandler<DisableDietRequestRequest, DisableDietRequestResponse>
{
	private readonly IDietRequestUpdater _dietRequestUpdater;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public DisableDietRequestCommandHandler(IDietRequestUpdater dietRequestUpdater, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestUpdater = dietRequestUpdater;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<DisableDietRequestResponse> Handle(DisableDietRequestRequest request, CancellationToken cancellationToken)
	{
		try
		{
			await _dietRequestUpdater.DisableAsync(request.Id!.Value);

			return new DisableDietRequestResponse { Id = request.Id!.Value };
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<DisableDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.UpdateException));
		}
	}
}