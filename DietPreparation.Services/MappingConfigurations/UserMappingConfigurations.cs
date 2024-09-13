using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class UserMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<UserDao, UserDto>()
			.Map(dest => dest.UserId, src => src.UserID)
			.Map(dest => dest.FirstName, src => src.FirstName)
			.Map(dest => dest.MiddleName, src => src.MiddleName)
			.Map(dest => dest.LastName, src => src.LastName)
			.Map(dest => dest.Email, src => src.EmailAddress)
			.Map(dest => dest.AccessType, src => src.accessKey.GetEnum<AccessType>())
			.Map(dest => dest.KeyId, src => src.UserIDKey);

		config.NewConfig<UserDto, CreateUpdateUserDao>()
			.Map(dest => dest.USERIDKEY, src => src.KeyId)
			.Map(dest => dest.USERID, src => src.UserId)
			.Map(dest => dest.FIRSTNAME, src => src.FirstName)
			.Map(dest => dest.MIDDLENAME, src => src.MiddleName.ToDefaultIfEmpty(DefaultStrings.Space))
			.Map(dest => dest.LASTNAME, src => src.LastName)
			.Map(dest => dest.EMAILADDRESS, src => src.Email)
			.Map(dest => dest.ACCESSKEY, src => src.AccessType.GetNumber());
	}
}
