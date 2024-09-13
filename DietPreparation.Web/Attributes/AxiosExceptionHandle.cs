using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DietPreparation.Web.Attributes;

public class AxiosExceptionHandleAttribute : ExceptionFilterAttribute
{
	public override void OnException(ExceptionContext context)
	{
		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

		// TODO Research and delete. This stopped working after refactoring: ExceptionResponse
		//if (context.Exception is DietPreparationException)
		//{
		//	context.Result = new JsonResult(new { dietErrors = context.Exception.Message });
		//}

		// TODO Research this changes
		// If a non-DietPreparationException occurs here, then unexpected behavior will occur.
		// And it can get here, for example, if something breaks in the controller.
		context.Result = new JsonResult(new { dietErrors = context.Exception.Message });
		base.OnException(context);
	}
}