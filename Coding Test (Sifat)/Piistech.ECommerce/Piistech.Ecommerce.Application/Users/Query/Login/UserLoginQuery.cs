using MediatR;

namespace Piistech.Ecommerce.Application.Users.Query.Login;

public class UserLoginQuery : IRequest<PiistechEcommerceResponse<UserModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }

}
