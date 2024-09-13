using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers;

internal class GetPremixesQueryHandler : IRequestHandler<GetPremixesQueryRequest, GetPremixesQueryResponse>
{
	private readonly IPremixReader _premixReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetPremixesQueryHandler(IPremixReader premixReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_premixReader = premixReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetPremixesQueryResponse> Handle(GetPremixesQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var medicatedPremixes = await _premixReader.ReadAllAsync();

			return _mapper.Map<GetPremixesQueryResponse>(medicatedPremixes);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetPremixesQueryResponse>(new DietPreparationException(DietRequestErrorCode.ReadException));
		}
	}
}