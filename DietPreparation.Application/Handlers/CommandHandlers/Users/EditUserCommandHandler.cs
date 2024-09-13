using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Commands.Responses.Users;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Users.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.CommandHandlers.Users
{
	internal class EditUserCommandHandler : IRequestHandler<EditUserRequest, EditUserResponse>
	{
		private readonly IUserUpdater _userWriter;
		private readonly IUserReader _userReader;
		private readonly IMapper _mapper;
		private readonly IDietPreparationLogger _logger;

		public EditUserCommandHandler(IUserUpdater userWriter, IUserReader userReader, IMapper mapper, IDietPreparationLogger logger)
		{
			_userWriter = userWriter;
			_userReader = userReader;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<EditUserResponse> Handle(EditUserRequest request, CancellationToken cancellationToken)
		{
			try
			{
				if (request.UserId is null)
				{
					throw new DietPreparationException(CommonErrorCode.ParametersNullException);
				}

				var editUserDto = _mapper.Map<UserDto>(request);
				var currentUserDto = await _userReader.ReadAsync(request.UserId)
					?? throw new DietPreparationException(UserErrorCode.UserNotFound);

				EnsureSameKeyId(currentUserDto, editUserDto);

				await _userWriter.UpdateAsync(editUserDto);
				return _mapper.Map<EditUserResponse>(editUserDto);
			}
			catch (Exception exception)
			{
				_logger.Error(exception.Message, exception);
				return _mapper.Map<EditUserResponse>(new DietPreparationException(UserErrorCode.UpdateException));
			}
		}

		private static void EnsureSameKeyId(UserDto currentUserDto, UserDto editUserDto)
		{
			if (currentUserDto.KeyId != editUserDto.KeyId)
			{
				throw new DietPreparationException(UserErrorCode.UserNotFound);
			}
		}
	}
}