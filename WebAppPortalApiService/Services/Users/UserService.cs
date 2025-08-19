using WebAppPortalApiService.Models.Users;
using WebAppPortalApiService.Requests.Users;

namespace WebAppPortalApiService.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApiService apiService;

        public UserService(ApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<AddUserResponse> Add(User request, CancellationToken cancellationToken) =>
           await apiService.Post<User, AddUserResponse>("Users", request, cancellationToken) ?? new();

        public async Task<AuthUserResponse> Login(Login request, CancellationToken cancellationToken) =>
            await apiService.Post<Login, AuthUserResponse>("Users/Login", request, cancellationToken) ?? new();

    }
}
