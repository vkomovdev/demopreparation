using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers;

internal class CreateUpdateDrugCommandHandler : IRequestHandler<CreateUpdateDrugRequest, CreateUpdateDrugResponse>
{
	private readonly IDrugUpdater _drugWriter;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateUpdateDrugCommandHandler(IDrugUpdater drugWriter, IMapper mapper, IDietPreparationLogger logger)
	{
		_drugWriter = drugWriter;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateUpdateDrugResponse> Handle(CreateUpdateDrugRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var updateDto = _mapper.Map<DrugUpdateDto>(request);
			var drugUpdateDto = await _drugWriter.UpdateAsync(updateDto);

			return _mapper.Map<CreateUpdateDrugResponse>(drugUpdateDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateUpdateDrugResponse>(new DietPreparationException(DietRequestErrorCode.CreateException));
		}
	}
}