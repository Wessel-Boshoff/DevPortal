using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Requests.Users;

namespace WebAppPortalApiService.Services.Users
{
    public interface IUserService
    {
        Task<AddUserResponse> Add(User request, CancellationToken cancellationToken);
        Task<AuthUserResponse> Login(Login request, CancellationToken cancellationToken);
    }
}