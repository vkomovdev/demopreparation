using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Commands.Responses.Users;
using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations
{
	internal class UserMappingConfigurations : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			RegisterQueries(config);
			RegisterCommands(config);
		}

		private void RegisterQueries(TypeAdapterConfig config)
		{
			config.NewConfig<IEnumerable<UserDto>, GetUsersQueryResponse>()
				.Map(dest => dest.Users, src => src);

			config.NewConfig<UserDto, GetUserQueryResponse>()
				.Map(dest => dest.User, src => src);
		}

		private void RegisterCommands(TypeAdapterConfig config)
		{
			config.NewConfig<CreateUserRequest, UserDto>();
			config.NewConfig<EditUserRequest, UserDto>();
			config.NewConfig<UserDto, CreateUserResponse>();
			config.NewConfig<UserDto, EditUserResponse>();

			config.NewConfig<DietPreparationException, CreateUserResponse>()
				.Map(dest => dest.Exception, src => src);

			config.NewConfig<DietPreparationException, EditUserResponse>()
				.Map(dest => dest.Exception, src => src);

			config.NewConfig<DietPreparationException, GetUserQueryResponse>()
				.Map(dest => dest.Exception, src => src);

			config.NewConfig<DietPreparationException, GetUsersQueryResponse>()
				.Map(dest => dest.Exception, src => src);
		}
	}
}