namespace DietPreparation.Web.Options;

public record ApplicationOptions
{
	public string BuildVersion { get; set; } = string.Empty;

	public PaginationOptions Pagination { get; set; } = new PaginationOptions();

	public PrintOptions Print { get; set; } = new PrintOptions();

	public AuthorizationOptions Authorization { get; set; } = new AuthorizationOptions();
}