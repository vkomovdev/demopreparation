using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Drugs;

internal class GetDrugsQueryHandler : IRequestHandler<GetDrugsQueryRequest, GetDrugsQueryResponse>
{
	private readonly IDrugReader _drugReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetDrugsQueryHandler(IDrugReader drugReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_drugReader = drugReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetDrugsQueryResponse> Handle(GetDrugsQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var drugDtos = await _drugReader.ReadAllAsync();

			return _mapper.Map<GetDrugsQueryResponse>(drugDtos);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetDrugsQueryResponse>(new DietPreparationException(DrugErrorCode.ReadException));
		}
	}
}