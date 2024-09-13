using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.DietRequests;

internal class DeleteDietRequestWithAuditCommandHandler : IRequestHandler<DeleteDietRequestWithAuditRequest, DeleteDietRequestResponse>
{
	private readonly IDietRequestDeleter _dietRequestDeleter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public DeleteDietRequestWithAuditCommandHandler(IDietRequestDeleter dietRequestDeleter, IMapper mapper, IDietPreparationLogger logger)
	{
		_dietRequestDeleter = dietRequestDeleter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<DeleteDietRequestResponse> Handle(DeleteDietRequestWithAuditRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var audit = _mapper.Map<AuditCreateDto>(request);
			await _dietRequestDeleter.DeleteAsync(request.Id!.Value, audit);

			return new DeleteDietRequestResponse { Id = request.Id!.Value };
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<DeleteDietRequestResponse>(new DietPreparationException(DietRequestErrorCode.DeleteException));
		}
	}
}
