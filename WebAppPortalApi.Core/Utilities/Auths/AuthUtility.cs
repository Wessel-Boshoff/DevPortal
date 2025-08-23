using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Common.Options;
using WebAppPortalSite.Data.Stores.Users;
using WebAppPortalSite.Database.Tables.dbo;

namespace WebAppPortalSite.Core.Utilities.Auths
{
    public class AuthUtility : IAuthUtility
    {
        private readonly IUserStore userStore;
        private readonly JwtTokenOptions options;

        public AuthUtility(IUserStore userStore, IOptionsMonitor<JwtTokenOptions> options)
        {
            this.userStore = userStore;
            this.options = options.CurrentValue;
        }

        public async Task<User> CaptureAuthProfile(User user, string password, CancellationToken cancellationToken)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(32);
            string saltBase64 = Convert.ToBase64String(saltBytes);

            string saltedPassword = password + saltBase64;

            using var sha = SHA256.Create();
            byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            string hashedPassword = Convert.ToBase64String(hashBytes);

            user.Salt = saltBase64;
            user.Password = hashedPassword;


            await userStore.SaveChanges(cancellationToken);

            return user;
        }

        public async Task<Tuple<Common.Models.Users.Auth, User>> Authenticate(string emailAddress, string password, CancellationToken cancellationToken)
        {
            Common.Models.Users.Auth resultAuth = new();

            //Authenticate user 
            var exists = await userStore.Exists(emailAddress, cancellationToken);
            if (!exists)
            {
                resultAuth.LoginStatus = LoginStatus.InvalidUseramePassword;
                return Tuple.Create(resultAuth,new User());
            }

            var user = await userStore.Get(emailAddress, cancellationToken);
            if (user.RegistrationStatus == RegistrationStatus.NeedPassword)
            {
                resultAuth.LoginStatus = LoginStatus.NeedPassword;
                return Tuple.Create(resultAuth, user);
            }

            string saltedPassword = password + user.Salt;

            using var sha = SHA256.Create();
            var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            string hashedPassword = Convert.ToBase64String(hashBytes);

            if (hashedPassword != user.Password)
            {
                resultAuth.LoginStatus = LoginStatus.InvalidUseramePassword;
                return Tuple.Create(resultAuth, new User());
            }

            user.LastSignIn = DateTime.Now;
            await userStore.SaveChanges(cancellationToken);

            //Generate Token
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, emailAddress),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new ("role", user.Role.ToString()),
            };



            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(options.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.Now.AddMinutes(options.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: creds
            );

            resultAuth.Token = new JwtSecurityTokenHandler().WriteToken(token);
            resultAuth.ExpireMinutes = options.ExpirationMinutes;
            resultAuth.LoginStatus = LoginStatus.Successful;
            return Tuple.Create(resultAuth, user);
        }
    }
}
