using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace DietPreparation.Web.Attributes;

public class AxiosRedirectIfSuccessAttribute : ActionFilterAttribute
{
	private const string ControllerSuffix = "Controller";

	public string? Action { get; set; }
	public string? Controller { get; set; }

	public override void OnActionExecuted(ActionExecutedContext context)
	{
		if (context.Exception is null)
		{
			RedirectToUrl(context);
		}
	}

	private void RedirectToUrl(ActionExecutedContext context)
	{
		var urlHelperFactory = context.HttpContext.RequestServices.GetRequiredService<IUrlHelperFactory>();
		var urlHelper = urlHelperFactory.GetUrlHelper(context);
		var controllerName = Controller?.Replace(ControllerSuffix, string.Empty);
		var url = urlHelper.Action(Action, controllerName);
		context.Result = new JsonResult(new { redirectTo = url });
	}
}