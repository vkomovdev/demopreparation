using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Customers;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.Customers
{
	internal class EditCustomerCommandHandler : IRequestHandler<EditCustomerRequest, EditCustomerResponse>
	{
		private readonly ICustomerUpdater _customerWriter;
		private readonly ICustomerReader _customerReader;
		private readonly IMapper _mapper;
		private readonly IDietPreparationLogger _logger;

		public EditCustomerCommandHandler(ICustomerUpdater customerWriter, ICustomerReader customerReader, IMapper mapper, IDietPreparationLogger logger)
		{
			_customerWriter = customerWriter;
			_customerReader = customerReader;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<EditCustomerResponse> Handle(EditCustomerRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var editCustomerDto = _mapper.Map<CustomerDto>(request);
				var currentCustomerDto = await _customerReader.ReadAsync(request.Id)
					?? throw new DietPreparationException(UserErrorCode.UserNotFound);

				var existCustomer = await _customerReader.FindAsync(editCustomerDto.Email);

				if (existCustomer is not null && existCustomer.Email != currentCustomerDto.Email)
				{
					return _mapper.Map<EditCustomerResponse>(new DietPreparationException(CustomerErrorCode.CustomerEmailAlreadyExists));
				}

				EnsureSameKeyId(currentCustomerDto, editCustomerDto);

				await _customerWriter.UpdateAsync(editCustomerDto);
				return _mapper.Map<EditCustomerResponse>(editCustomerDto);
			}
			catch (Exception exception)
			{
				_logger.Error(exception.Message, exception);
				return _mapper.Map<EditCustomerResponse>(new DietPreparationException(CustomerErrorCode.UpdateException));
			}
		}

		private static void EnsureSameKeyId(CustomerDto currentCustomerDto, CustomerDto editCustomerDto)
		{
			if (currentCustomerDto.Id != editCustomerDto.Id)
			{
				throw new DietPreparationException(UserErrorCode.UserNotFound);
			}
		}
	}
}