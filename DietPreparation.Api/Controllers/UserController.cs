using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Commands.Responses.Users;
using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Application.Queries.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.ServicesApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
	private readonly IMediator _mediatr;

	public UserController(IMediator mediatr)
	{
		_mediatr = mediatr;
	}

	[HttpGet]
	public async Task<ActionResult<GetUsersQueryResponse>> GetUsers(GetUsersQueryRequest request)
	{
		return await _mediatr.Send(request);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GetUserQueryResponse>> GetUser(string id)
	{
		return await _mediatr.Send(new GetUserQueryRequest() { UserId = id });
	}

	[HttpPost]
	public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest request)
	{
		return await _mediatr.Send(request);
	}

	[HttpPut]
	public async Task<ActionResult<EditUserResponse>> UpdateUser(EditUserRequest request)
	{
		return await _mediatr.Send(request);
	}
}
