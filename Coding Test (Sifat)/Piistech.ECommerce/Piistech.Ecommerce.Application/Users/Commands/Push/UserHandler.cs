using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Common;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Application.Users.Commands.Push
{
    public class UserHandler(IEcommerceDbContext context) : IRequestHandler<UserCommand,
        PiistechEcommerceResponse<UserModel>>
    {
        private readonly IEcommerceDbContext _context = context;

        public async Task<PiistechEcommerceResponse<UserModel>> Handle(UserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _context.User
                    .Where(p => p.Id == command.Id && p.IsDeleted == false)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if (user == null)
                {
                    user = new User
                    {
                        Email = command.Email,
                        Password = PasswordEncryption.HashPassword(command.Password),
                        Role = command.Role,
                    };
                    await _context.User.AddAsync(user, cancellationToken);
                }
                await _context.SaveChangesAsync(cancellationToken);

                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = true,
                    Message = null,
                    Model = UserModel.Create(user)
                };
            }
            catch (Exception ex)
            {
                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = false,
                    Message = $"Failed to insert user with message: {ex.Message}, with inner exception:{ex.InnerException?.Message}"
                };
            }
        }
    }
}
