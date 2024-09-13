using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Customers;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Customers;

internal class GetCustomerQueryHandler : IRequestHandler<GetCustomerQueryRequest, GetCustomerQueryResponse>
{
	private readonly ICustomerReader _customerReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetCustomerQueryHandler(ICustomerReader customerReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_customerReader = customerReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetCustomerQueryResponse> Handle(GetCustomerQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			if (request.CustomerId is null)
			{
				throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
			}

			var customerDto = await _customerReader.ReadAsync(int.Parse(request.CustomerId)) ?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			return _mapper.Map<GetCustomerQueryResponse>(customerDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetCustomerQueryResponse>(new DietPreparationException(UserErrorCode.ReadException));
		}
	}
}