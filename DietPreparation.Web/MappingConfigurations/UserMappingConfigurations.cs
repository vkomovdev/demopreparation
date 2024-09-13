using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Models.Users;
using Mapster;
using System.Web;

namespace DietPreparation.Web.MappingConfigurations
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
			config.NewConfig<UserDto, UserListItemViewModel>()
				.Map(dest => dest.EncodedUserId, src => HttpUtility.UrlEncode(src.UserId))
				.Map(dest => dest.AccessTypeNumber, src => (int)src.AccessType)
				.Map(dest => dest.AccessTypeLevel, src => src.AccessType.GetDisplayName());

			config.NewConfig<GetUserQueryResponse, UserViewModel>()
				.Map(dest => dest, src => src.User);

			config.NewConfig<TableOptionsViewModel, GetUsersQueryRequest>()
				.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy));
		}

		private void RegisterCommands(TypeAdapterConfig config)
		{
			config.NewConfig<UserViewModel, CreateUserRequest>();
			config.NewConfig<UserViewModel, EditUserRequest>();
		}

		private static OrderByDto? MapOrderBy(OrderByViewModel? src)
		{
			return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
		}
	}
}