using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Services.FilterYear;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers;

internal class EditFilterYearCommandHandler : IRequestHandler<EditFilterYearRequest, EditFilterYearResponse>
{
	private readonly IFilterYearUpdater _filterYearUpdater;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public EditFilterYearCommandHandler(
		IFilterYearUpdater filterYearUpdater,
		IMapper mapper,
		IDietPreparationLogger logger)
	{
		_filterYearUpdater = filterYearUpdater;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<EditFilterYearResponse> Handle(EditFilterYearRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var model = await _filterYearUpdater.UpdateAsync(request.Year);
			return _mapper.Map<EditFilterYearResponse>(model);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<EditFilterYearResponse>(new DietPreparationException(CommonErrorCode.EntityNotFound));
		}
	}
}