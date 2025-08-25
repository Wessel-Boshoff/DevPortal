using WebAppPortal.Tests.Mock;
using WebAppPortal.Tests.Mock.Stores;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Handlers.Users;
using WebAppPortalApi.Core.Requests.Users;
using WebAppPortalApi.Core.Utilities.Auths;

namespace WebAppPortal.Tests.Handlers.Users
{
    [TestClass]
    public sealed class AddUserTests
    {
        [TestMethod]
        public async Task Valid()
        {
            // Arrange
            var userStore = new UserStore
            {
                MockExist = false
            };
            var authUtility = new  AuthUtility(userStore,TestOptions.JwtTokenOptions());
            var handler = new AddUserHandler(userStore, authUtility);
            var request = new AddUserRequest()
            { 
                User = TestModels.User(),
            };          

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Handler returned null result");
            Assert.IsNotNull(result.User, "User should not be null");
            Assert.AreEqual(ResponseCode.Successful, result.ResponseCode, "ResponseCode should be Successful");
            Assert.AreEqual(0, result.Errors.Count, "There should be no errors");

        }

    }
}
