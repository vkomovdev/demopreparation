using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Users.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.Logger;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Users;

internal class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
{
	private readonly IUserReader _userReader;
	private readonly IMapper _mapper;
	private readonly IDietPreparationLogger _logger;

	public GetUserQueryHandler(IUserReader userReader, IMapper mapper, IDietPreparationLogger logger)
	{
		_userReader = userReader;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			if (request.UserId is null)
			{
				throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
			}

			var userDto = await _userReader.ReadAsync(request.UserId) ?? throw new DietPreparationException(CommonErrorCode.EntityNotFound);

			return _mapper.Map<GetUserQueryResponse>(userDto);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			return _mapper.Map<GetUserQueryResponse>(new DietPreparationException(UserErrorCode.ReadException));
		}
	}
}