using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Application.Commands.Responses.Users;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.Users;

public record CreateUserRequest : BaseUserRequest, IRequest<CreateUserResponse>
{
}