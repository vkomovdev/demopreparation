using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Customers;
using DietPreparation.Utilities.ExceptionHandler;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Customers;

internal class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
{
	private readonly ICustomerReader _customerReader;
	private readonly IMapper _mapper;

	public GetCustomersQueryHandler(ICustomerReader customerReader, IMapper mapper)
	{
		_customerReader = customerReader;
		_mapper = mapper;
	}

	public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var customerDtos = request.OrderBy is null
				? await _customerReader.ReadAllAsync()
				: await _customerReader.ReadAllAsync(request.OrderBy, request.Pagination);

			var response = new GetCustomersQueryResponse();

			_mapper.Map(request.Pagination, response);
			_mapper.Map(customerDtos, response);
			return response;
		}
		catch (Exception e)
		{
			return _mapper.Map<GetCustomersQueryResponse>(new DietPreparationException(CustomerErrorCode.ReadException));
		}
	}
}