using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

[ExceptionHandle]
public class HomeController : Controller
{
	[Authorize(Permissions.Basic.View)]
	public IActionResult Index()
	{
		return View();
	}

	[Authorize(Permissions.Basic.View)]
	public IActionResult Privacy()
	{
		return View();
	}
}