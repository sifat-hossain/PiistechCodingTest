using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Common;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Application.Users.Query.Login;

public class UserLoginQueryHandler(IEcommerceDbContext context) : IRequestHandler<UserLoginQuery, PiistechEcommerceResponse<UserModel>>
{
    private readonly IEcommerceDbContext _context = context;
    public async Task<PiistechEcommerceResponse<UserModel>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
    {

        User? user = await _context.User
            .Where(x => !x.IsDeleted && x.Email == request.Email)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        try
        {
            if (user != null && PasswordEncryption.VerifyPassword(request.Password, user.Password))
            {

                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = true,
                    Message = null,
                    Model = UserModel.Create(user)
                };
            }
            else
            {
                return new PiistechEcommerceResponse<UserModel>
                {
                    IsSuccessful = true,
                    Message = null,
                    Model = new UserModel()
                };
            }
        }
        catch (Exception ex)
        {
            return new PiistechEcommerceResponse<UserModel>
            {
                IsSuccessful = true,
                Message = $"Failed with message {ex.Message}, Inner exception {ex.InnerException?.Message}",
                Model = new UserModel()
            };
        }

    }
}
