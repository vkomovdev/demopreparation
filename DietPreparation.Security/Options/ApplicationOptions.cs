namespace DietPreparation.Security.Options;
public record ApplicationOptions
{
	public AuthorizationOptions Authorization { get; set; } = new AuthorizationOptions();
}