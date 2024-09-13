namespace DietPreparation.Security.Models;

public record UserSecurityInfo
{
	public string? Email { get; set; }

	public string? Name { get; set; }

	public ICollection<PermissionInfo> Permissions { get; set; } = new List<PermissionInfo>();
}
