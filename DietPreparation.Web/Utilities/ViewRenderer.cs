using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DietPreparation.Web.Utilities;

public class ViewRenderer
{
	private readonly ICompositeViewEngine _viewEngine;
	private readonly ITempDataProvider _tempDataProvider;

	public ViewRenderer(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider)
	{
		_viewEngine = viewEngine;
		_tempDataProvider = tempDataProvider;
	}

	public async Task<string> RenderViewToString<TModel>(ActionContext actionContext, string viewName, TModel model)
	{
		var viewData = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
		{
			Model = model
		};

		await using var writer = new StringWriter();
		var viewResult = _viewEngine.FindView(actionContext, viewName, false);

		if (viewResult.View == null)
		{
			throw new ArgumentException($"View, '{viewName}', not found.");
		}

		var tempData = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);
		var viewContext = new ViewContext(actionContext, viewResult.View, viewData, tempData, writer, new HtmlHelperOptions());

		await viewResult.View.RenderAsync(viewContext);
		return writer.GetStringBuilder().ToString();
	}
}