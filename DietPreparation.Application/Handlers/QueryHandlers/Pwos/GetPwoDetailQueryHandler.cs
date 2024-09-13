using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Customers;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace DietPreparation.Application.Handlers.QueryHandlers.PWOs;

internal class GetPwoDetailQueryHandler : IRequestHandler<GetPwoDetailQueryRequest, GetPwoDetailQueryResponse>
{
	private readonly IPwoReader _pwoReader;
	private readonly ILocationReader _locationReader;
	private readonly ICustomerReader _customerReader;
	private readonly ISampleReader _sampleReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetPwoDetailQueryHandler(
		IPwoReader pwoReader, 
		ILocationReader locationReader,
		ICustomerReader customerReader,
		ISampleReader sampleReader,
		IMapper mapper, 
		IDietPreparationLogger logger)
	{
		_pwoReader = pwoReader;
		_locationReader = locationReader;
		_customerReader = customerReader;
		_sampleReader = sampleReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetPwoDetailQueryResponse> Handle(GetPwoDetailQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var header = await _pwoReader.ReadHeaderAsync(request.RequestId, request.Sequence);
			
			if (header is null || header.PwoDto is null)
			{
				throw new DietPreparationException(CommonErrorCode.UnprocessableEntity);
			}

			if (header.DietRequest?.LocationId is not null && header.DietRequest.Location is null)
			{
				header.DietRequest.Location = await _locationReader.ReadAsync(header.DietRequest.LocationId.Value);
			}

			if (header.DietRequest?.RecieverId is not null) // TODO Receiver null check. Receiver here is always only with Id
			{
				header.DietRequest.Receiver = await _customerReader.ReadAsync(header.DietRequest.RecieverId.Value);
			}

			if (header.DietRequest?.HasSamples is not null && header.DietRequest.Samples is null)
			{
				header.DietRequest.Samples = await _sampleReader.ReadByRequestIdAsync(request.RequestId);
			}

			var ingredients = await _pwoReader.ReadIngredientsAsync(header.PwoDto.PwoId);
			var drugs = await _pwoReader.ReadDrugsAsync(header.PwoDto.PwoId);
			var premixes = await _pwoReader.ReadPremixesAsync(header.PwoDto.PwoId);
			var premixDrugs = await _pwoReader.ReadPremixDrugsAsync(header.PwoDto.PwoId);

			var response = new GetPwoDetailQueryResponse();
			_mapper.Map(request.RequestId, response);
			_mapper.Map(header, response);
			_mapper.Map(ingredients, response);
			_mapper.Map(drugs, response);
			_mapper.Map(premixes, response);
			_mapper.Map(premixDrugs, response);

			return response;
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetPwoDetailQueryResponse>(new DietPreparationException(PwoErrorCode.ReadException));
		}
	}
}
