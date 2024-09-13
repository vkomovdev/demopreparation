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

internal class PwoConfirmCommandHandler : IRequestHandler<ConfirmPwoRequest, ConfirmPwoResponse>
{
	private readonly IPwoConfirm _pwoConfirm;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public PwoConfirmCommandHandler(IPwoConfirm pwoConfirm, IMapper mapper, IDietPreparationLogger logger)
	{
		_pwoConfirm = pwoConfirm;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<ConfirmPwoResponse> Handle(ConfirmPwoRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var model = _mapper.Map<PwoConfirmDto>(request);

			await _pwoConfirm.ConfirmAsync(model);

			return _mapper.Map<ConfirmPwoResponse>(model);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<ConfirmPwoResponse>(new DietPreparationException(PwoErrorCode.CloseException));
		}
	}
}