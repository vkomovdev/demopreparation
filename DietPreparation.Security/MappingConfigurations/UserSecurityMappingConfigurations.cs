using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Security.Models;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Security.MappingConfigurations;
internal class UserMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserDto, UserSecurityInfo>()
			.Map(dest => dest.Email, src => src.Email)
			.Map(dest => dest.Name, src => $"{src.FirstName} {src.LastName}")
			.Map(dest => dest.Permissions, src => MapAccessType(src.AccessType.GetDisplayName()));
	}

	private static List<PermissionInfo> MapAccessType(string accessType)
	{
		if (string.IsNullOrEmpty(accessType))
			return new List<PermissionInfo>();

		var permissions = PermissionRoles.Roles.TryGetValue(accessType, out var value) ? value
			: throw new DietPreparationException(CommonErrorCode.NotImplementedException, accessType);

		return permissions.Select(x => new PermissionInfo() { Name = x }).ToList();
	}

}
