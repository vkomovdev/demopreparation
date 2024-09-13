namespace DietPreparation.Web.Options;

public record PaginationOptions
{
	public int FirstPage { get; set; }

	public int PageSize { get; set; }
}
