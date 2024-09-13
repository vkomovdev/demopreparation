using DietPreparation.Models.DTO;

namespace DietPreparation.Web.Options;

public record AuthorizationOptions
{
	public bool IsUsed { get; set; }

	public string[]? Domains { get; set; }

	public int SessionTimeout { get; set; }

	public UserDto? MockUser { get; set; }
}
