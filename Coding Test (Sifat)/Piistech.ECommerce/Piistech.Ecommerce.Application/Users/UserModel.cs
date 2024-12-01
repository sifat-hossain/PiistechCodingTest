using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using System.Linq.Expressions;

namespace Piistech.Ecommerce.Application.Users;

public class UserModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsDeleted { get; set; }

    public static Expression<Func<User, UserModel>> Projection
    {
        get
        {
            return entity => new UserModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Role = entity.Role,
                IsDeleted = entity.IsDeleted
            };
        }
    }

    public static UserModel Create(User user)
    {
        return Projection.Compile().Invoke(user);
    }
}
