using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Application.Users.Query.Pull;

public class UserQueryHandler(IEcommerceDbContext context) : IRequestHandler<UserQuery, List<UserModel>>
{
    private readonly IEcommerceDbContext _context = context;
    public async Task<List<UserModel>> Handle(UserQuery request, CancellationToken cancellationToken)
    {
        int skip = request.Skip ?? 0;
        int take = request.Take ?? 50;

        List<User> users = await _context.User
            .Skip(skip)
            .Take(take)
            .Where(x => !x.IsDeleted)
            .ToListAsync(cancellationToken: cancellationToken);

        return users.Select(p => UserModel.Create(p)).ToList();
    }
}
