using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Drugs;

internal class GetDrugQueryHandler : IRequestHandler<GetDrugQueryRequest, GetDrugQueryResponse>
{
	private readonly IDrugReader _drugReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetDrugQueryHandler(IDrugReader drugReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_drugReader = drugReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetDrugQueryResponse> Handle(GetDrugQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var userDto = await _drugReader.ReadAsync(request.DrugId);

			if (userDto is null)
			{
				throw new DietPreparationException(CommonErrorCode.EntityNotFound);
			}

			return _mapper.Map<GetDrugQueryResponse>(userDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetDrugQueryResponse>(new DietPreparationException(DrugErrorCode.ReadException));
		}
	}
}
