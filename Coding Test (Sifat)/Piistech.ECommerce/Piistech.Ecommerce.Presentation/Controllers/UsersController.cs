using MediatR;
using Microsoft.AspNetCore.Mvc;
using Piistech.Ecommerce.Application;
using Piistech.Ecommerce.Application.Users;
using Piistech.Ecommerce.Application.Users.Commands.Delete;
using Piistech.Ecommerce.Application.Users.Commands.Push;
using Piistech.Ecommerce.Application.Users.Query.Login;
using Piistech.Ecommerce.Application.Users.Query.Pull;

namespace Piistech.Ecommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<List<UserModel>> Pull([FromQuery] UserQuery request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost]
    public async Task<PiistechEcommerceResponse<UserModel>> Push(UserCommand command)
    {
        command.Role = command.Role ?? "user";
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<PiistechEcommerceResponse> Delete(Guid id)
    {
        UserDeleteCommand command = new UserDeleteCommand
        {
            Id = id
        };
        return await _mediator.Send(command);
    }

    [HttpGet("Login")]
    public async Task<PiistechEcommerceResponse<UserModel>> Login([FromQuery] UserLoginQuery userLoginQuery)
    {

        return await _mediator.Send(userLoginQuery);
    }

}
