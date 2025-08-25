using WebAppPortal.Tests.Mock;
using WebAppPortal.Tests.Mock.Stores;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Handlers.Products;
using WebAppPortalApi.Core.Requests.Products;

namespace WebAppPortal.Tests.Handlers.Products
{
    [TestClass]
    public sealed class EditProductTests
    {
        [TestMethod]
        public async Task Valid()
        {
            // Arrange
            var productStore = new ProductStore();
            var userStore = new UserStore();
            var handler = new EditProductHandler(productStore, userStore);
            var request = new EditProductRequest()
            { 
                Product = TestModels.Product(TestModels.User()),
            };          

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Handler returned null result");
            Assert.IsNotNull(result.Product, "Product should not be null");
            Assert.AreEqual(ResponseCode.Successful, result.ResponseCode, "ResponseCode should be Successful");
            Assert.AreEqual(0, result.Errors.Count, "There should be no errors");

        }

    }
}
