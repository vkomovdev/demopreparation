using DietPreparation.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class ErrorController : Controller
{
	[Route("Error/{statusCode:int}")]
	public IActionResult Error(int statusCode)
	{
		var viewModel = new ErrorViewModel
		{
			StatusCode = statusCode,
			OriginalPath = HttpContext.Features.Get<IStatusCodeReExecuteFeature>()?.OriginalPath,
			Exception = HttpContext.Items[nameof(Exception)] as Exception
		};
		
		return View(viewModel);
	}
}