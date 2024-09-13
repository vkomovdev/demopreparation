using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class CloneDietRequestCommandHandler : IRequestHandler<CloneDietRequestRequest, CloneDietRequestResponse>
{
	private IDietRequestCloner _dietRequestCloner;
	private IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CloneDietRequestCommandHandler(IDietRequestCloner dietRequestCloner, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestCloner = dietRequestCloner;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CloneDietRequestResponse> Handle(CloneDietRequestRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var dietRequest = await _dietRequestCloner.CloneAsync(request.Id);
			return _mapper.Map<CloneDietRequestResponse>(dietRequest);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CloneDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.CloneException));
		}
	}
}