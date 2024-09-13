using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Commands.Responses.Users;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Customers;
using DietPreparation.Services.Users.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.Users;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
	private readonly IUserUpdater _userWriter;
	private readonly IUserReader _userReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public CreateUserCommandHandler(IUserUpdater userWriter, IUserReader userReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_userWriter = userWriter;
		_userReader = userReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
	{
		try
		{
			if (request.UserId is null)
			{
				throw new DietPreparationException(CommonErrorCode.ParametersNullException);
			}

			if (await UserIdExists(request.UserId))
			{
				throw new DietPreparationException(UserErrorCode.UserIdAlreadyExists);
			}

			var createUserDto = _mapper.Map<UserDto>(request);
			await _userWriter.UpdateAsync(createUserDto);

			return _mapper.Map<CreateUserResponse>(createUserDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<CreateUserResponse>(new DietPreparationException(UserErrorCode.CreateException));
		}
	}

	private async Task<bool> UserIdExists(string userId)
	{
		return await _userReader.ReadAsync(userId) is not null;
	}
}