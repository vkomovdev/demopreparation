using DietPreparation.Application.Commands.Requests.PWOs;
using DietPreparation.Application.Commands.Responses.PWOs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.PWOs;

internal class PwoCloseCommandHandler : IRequestHandler<PwoCloseRequest, PwoCloseResponse>
{
	private readonly IPwoCloser _pwoCloser;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public PwoCloseCommandHandler(IPwoCloser pwoCloser, IMapper mapper, IDietPreparationLogger logger)
	{
		_pwoCloser = pwoCloser;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<PwoCloseResponse> Handle(PwoCloseRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var model = _mapper.Map<PwoCloseDto>(request);

			await _pwoCloser.CloseAsync(model);

			return _mapper.Map<PwoCloseResponse>(model);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<PwoCloseResponse>(new DietPreparationException(PwoErrorCode.CloseException));
		}
	}
}