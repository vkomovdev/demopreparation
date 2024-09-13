using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Authorizations.Interfaces;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Models.Users;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DietPreparation.Web.Controllers;

public class UsersController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	private readonly IUserSecurityService _userSecurityService;
	private readonly IAuthContextAccessor _authContextAccessor;

	public UsersController(IMediator mediator, IMapper mapper, 
		IUserSecurityService userSecurityService, 
		IAuthContextAccessor authContextAccessor)
	{
		_mediator = mediator;
		_mapper = mapper;
		_userSecurityService = userSecurityService;
		_authContextAccessor = authContextAccessor;
	}

	[HttpGet]
	[Authorize(Permissions.Users.View)]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Users.View)]
	public async Task<IActionResult> Search([FromQuery] TableOptionsViewModel tableOptions)
	{
		if (tableOptions is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<GetUsersQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<UserListViewModel>(response);
		return Ok(new { users = viewModel.Users });
	}

	[HttpGet]
	[Authorize(Permissions.Users.Create)]
	public IActionResult Create()
	{
		return View(new UserViewModel());
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Users.Create)]
	public async Task<IActionResult> Create([FromBody] UserViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateUserRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.Users.Update)]
	public async Task<IActionResult> Edit(string encodedId)
	{
		if (string.IsNullOrEmpty(encodedId))
		{
			throw new DietPreparationException(CommonErrorCode.ParametersNullException);
		}

		var request = new GetUserQueryRequest { UserId = HttpUtility.UrlDecode(encodedId) };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<UserViewModel>(response);
		return View(viewModel);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Users.Update)]
	public async Task<IActionResult> Edit([FromBody] UserViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<EditUserRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[Authorize(Permissions.Basic.View)]
	[AxiosExceptionHandle]
	public async Task<IActionResult> PermissionList()
	{
		var userName = _authContextAccessor.UserName[1..].Split('\\')[^1].ToUpper();

		var userInfo = await _userSecurityService.GetUserSecurityInfo(userName);

		return Ok(userInfo.Permissions);
	}
}