using MediatR;

namespace Piistech.Ecommerce.Application.Users.Commands.Delete;

public class UserDeleteCommand : IRequest<PiistechEcommerceResponse>
{
    public Guid Id { get; set; }
}
