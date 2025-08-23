using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<GetUsersResponse> Get(CancellationToken cancellationToken) =>
            await apiService.Get<GetUsersResponse>("Users", cancellationToken) ?? new();

        public async Task<GetUserResponse> Get(Guid moniker, CancellationToken cancellationToken) =>
           await apiService.Get<GetUserResponse>($"Users/{moniker}", cancellationToken) ?? new();

        public async Task<RemoveUserResponse> Delete(Guid moniker, CancellationToken cancellationToken) =>
           await apiService.Delete<RemoveUserResponse>($"Users/{moniker}", cancellationToken) ?? new();

        public async Task<EditUserResponse> Edit(User request, CancellationToken cancellationToken) =>
           await apiService.Put<User, EditUserResponse>("Users", request, cancellationToken) ?? new();

        public async Task<AddUserResponse> Add(User request, CancellationToken cancellationToken) =>
           await apiService.Post<User, AddUserResponse>("Users", request, cancellationToken) ?? new();

        public async Task<AuthUserResponse> Login(Login request, CancellationToken cancellationToken) =>
            await apiService.Post<Login, AuthUserResponse>("Users/Login", request, cancellationToken) ?? new();

        public async Task<SetUserPasswordResponse> SetPassword(Login request, CancellationToken cancellationToken) =>
             await apiService.Post<Login, SetUserPasswordResponse>("Users/SetPassword", request, cancellationToken) ?? new();

    }
}
