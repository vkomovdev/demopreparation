using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Web.Models;
using DietPreparation.Web.Options;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class AboutController : Controller
{
	private readonly ApplicationOptions _applicationOptions;
	private readonly IMapper _mapper;

	public AboutController(ApplicationOptions applicationOptions, IMapper mapper)
	{
		_applicationOptions = applicationOptions;
		_mapper = mapper;
	}

	[Authorize(Permissions.Basic.View)]
	public IActionResult Index()
	{
		return View(_mapper.Map<AboutViewModel>(_applicationOptions));
	}
}