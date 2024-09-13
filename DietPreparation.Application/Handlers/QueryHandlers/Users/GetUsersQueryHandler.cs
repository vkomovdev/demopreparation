using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Common.ErrorCodes;
using DietPreparation.Services.Users.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using MapsterMapper;
using MediatR;

namespace DietPreparation.Application.Handlers.QueryHandlers.Users;

internal class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, GetUsersQueryResponse>
{
	private readonly IUserReader _userReader;
	private readonly IMapper _mapper;

	public GetUsersQueryHandler(IUserReader userReader, IMapper mapper)
	{
		_userReader = userReader;
		_mapper = mapper;
	}

	public async Task<GetUsersQueryResponse> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
	{
		try
		{
			var userDtos = request.OrderBy is null
				? await _userReader.ReadAllAsync()
				: await _userReader.ReadAllAsync(request.OrderBy);

			return _mapper.Map<GetUsersQueryResponse>(userDtos);
		}
		catch (Exception)
		{
			return _mapper.Map<GetUsersQueryResponse>(new DietPreparationException(UserErrorCode.ReadException));
		}
	}
}