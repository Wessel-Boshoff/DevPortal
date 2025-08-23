using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Requests.Users;

namespace WebAppPortalApiService.Services.Users
{
    public interface IUserService
    {
        Task<AddUserResponse> Add(User request, CancellationToken cancellationToken);
        Task<RemoveUserResponse> Delete(Guid moniker, CancellationToken cancellationToken, string token);
        Task<EditUserResponse> Edit(User request, CancellationToken cancellationToken, string token);
        Task<GetUsersResponse> Get(CancellationToken cancellationToken, string token);
        Task<GetUserResponse> Get(Guid moniker, CancellationToken cancellationToken, string token);
        Task<AuthUserResponse> Login(Login request, CancellationToken cancellationToken);
        Task<SetUserPasswordResponse> SetPassword(Login request, CancellationToken cancellationToken);
    }
}