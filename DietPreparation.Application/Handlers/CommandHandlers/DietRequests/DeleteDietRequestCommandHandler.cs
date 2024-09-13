using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class DeleteDietRequestCommandHandler : IRequestHandler<DeleteDietRequestRequest, DeleteDietRequestResponse>
{
	private readonly IDietRequestDeleter _dietRequestDeleter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public DeleteDietRequestCommandHandler(IDietRequestDeleter dietRequestDeleter, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestDeleter = dietRequestDeleter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<DeleteDietRequestResponse> Handle(DeleteDietRequestRequest request, CancellationToken cancellationToken)
	{
		try
		{
			await _dietRequestDeleter.DeleteAsync(request.Id!.Value);

			return new DeleteDietRequestResponse { Id = request.Id!.Value };
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<DeleteDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.DeleteException));
		}
	}
}
