using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Customers;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;
using System;

namespace DietPreparation.Application.Handlers.CommandHandlers.Customers;

internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
	private readonly ICustomerUpdater _customerWriter;
	private readonly ICustomerReader _customerReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateCustomerCommandHandler(ICustomerUpdater customerWriter, ICustomerReader customerReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_customerWriter = customerWriter;
		_customerReader = customerReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
	{
		try
		{

			var createCustomerDto = _mapper.Map<CustomerDto>(request);

			var customer = await _customerReader.FindAsync(createCustomerDto.Email);

			if (customer is not null)
			{
				return _mapper.Map<CreateCustomerResponse>(new DietPreparationException(CustomerErrorCode.CustomerEmailAlreadyExists));
			}

			await _customerWriter.UpdateAsync(createCustomerDto);

			return _mapper.Map<CreateCustomerResponse>(createCustomerDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateCustomerResponse>(new DietPreparationException(CustomerErrorCode.CreateException));
		}
	}

	private async Task<bool> CustomerIdExists(int customerId)
	{
		return await _customerReader.ReadAsync(customerId) is not null;
	}
}