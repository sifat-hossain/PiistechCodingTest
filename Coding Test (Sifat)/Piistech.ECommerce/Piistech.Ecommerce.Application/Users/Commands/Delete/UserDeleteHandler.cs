using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Application.Users.Commands.Delete;

public class UserDeleteHandler(IEcommerceDbContext context) : IRequestHandler<UserDeleteCommand,
    PiistechEcommerceResponse>
{
    private readonly IEcommerceDbContext _context = context;

    public async Task<PiistechEcommerceResponse> Handle(UserDeleteCommand command, CancellationToken cancellationToken)
    {
        try
        {
            User? user = await _context.User
                .Where(p => p.Id == command.Id && p.IsDeleted == false)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (user != null)
            {
                user.IsDeleted = true;
                _context.User.Update(user);
                await _context.SaveChangesAsync(cancellationToken);

                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = true,
                    Message = null,
                };
            }
            else
            {
                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = true,
                    Message = "User not found",
                };
            }
        }
        catch (Exception ex)
        {
            return new PiistechEcommerceResponse<UserModel>
            {
                IsSuccessful = false,
                Message = $"Failed to Delete user with message: {ex.Message}, with inner exception:{ex.InnerException?.Message}"
            };
        }
    }
}
