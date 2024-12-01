using MediatR;

namespace Piistech.Ecommerce.Application.Users.Query.Pull;

public class UserQuery : IRequest<List<UserModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
