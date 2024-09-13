namespace DietPreparation.ServicesApi.Options;

public record CorsPolicyOptions
{
	public string PolicyName { get; set; } = string.Empty;

	public string Origins { get; set; } = string.Empty;
}
