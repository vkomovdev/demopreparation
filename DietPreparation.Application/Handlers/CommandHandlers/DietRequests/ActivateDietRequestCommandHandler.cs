using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class ActivateDietRequestCommandHandler : IRequestHandler<ActivateDietRequestRequest, ActivateDietRequestResponse>
{
	private readonly IDietRequestActivator _dietRequestActivator;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public ActivateDietRequestCommandHandler(IDietRequestActivator dietRequestActivator, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestActivator = dietRequestActivator;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<ActivateDietRequestResponse> Handle(ActivateDietRequestRequest request, CancellationToken cancellationToken)
	{
		try
		{
			await _dietRequestActivator.ActivateAsync(request.Id!.Value);

			return new ActivateDietRequestResponse();
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<ActivateDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.ActivateException));
		}
	}
}