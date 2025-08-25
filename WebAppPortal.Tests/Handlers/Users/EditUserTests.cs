using WebAppPortal.Tests.Mock;
using WebAppPortal.Tests.Mock.Stores;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Handlers.Products;
using WebAppPortalApi.Core.Handlers.Users;
using WebAppPortalApi.Core.Requests.Products;
using WebAppPortalApi.Core.Requests.Users;

namespace WebAppPortal.Tests.Handlers.Users
{
    [TestClass]
    public sealed class EditUserTests
    {
        [TestMethod]
        public async Task Valid()
        {
            // Arrange
            var userStore = new UserStore();
            var handler = new EditUserHandler(userStore);
            var request = new EditUserRequest()
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
