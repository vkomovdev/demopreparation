using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DietPreparation.Web.Attributes;

public class ExceptionHandleAttribute : ExceptionFilterAttribute
{
	public override void OnException(ExceptionContext context)
	{
		context.HttpContext.Items[nameof(Exception)] = context.Exception;
		context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
		context.ExceptionHandled = true;
	}
}