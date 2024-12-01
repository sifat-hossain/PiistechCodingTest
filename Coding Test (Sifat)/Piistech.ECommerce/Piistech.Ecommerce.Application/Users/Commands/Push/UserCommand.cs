using MediatR;

namespace Piistech.Ecommerce.Application.Users.Commands.Push;

public class UserCommand : IRequest<PiistechEcommerceResponse<UserModel>>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public bool IsDeleted { get; set; }
}
