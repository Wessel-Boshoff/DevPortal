using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Requests.Users;

namespace WebAppPortalApiService.Services.Users
{
    public interface IUserService
    {
        Task<AddUserResponse> Add(User request, CancellationToken cancellationToken);
        Task<RemoveUserResponse> Delete(Guid moniker, CancellationToken cancellationToken);
        Task<EditUserResponse> Edit(User request, CancellationToken cancellationToken);
        Task<GetUsersResponse> Get(CancellationToken cancellationToken);
        Task<GetUserResponse> Get(Guid moniker, CancellationToken cancellationToken);
        Task<AuthUserResponse> Login(Login request, CancellationToken cancellationToken);
    }
}