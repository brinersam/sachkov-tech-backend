using SachkovTech.Application.Authorization.Commands.Register;

namespace SachkovTech.API.Controllers.Accounts.Requests;

public record RegisterUserRequest(string Email, string UserName, string Password)
{
    public RegisterUserCommand ToCommand() => new (Email, UserName, Password);
};