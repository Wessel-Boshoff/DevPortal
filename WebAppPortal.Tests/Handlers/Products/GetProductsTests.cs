using WebAppPortal.Tests.Mock;
using WebAppPortal.Tests.Mock.Stores;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Core.Handlers.Products;
using WebAppPortalApi.Core.Requests.Products;

namespace WebAppPortal.Tests.Handlers.Products
{
    [TestClass]
    public sealed class GetProductsTests
    {
        [TestMethod]
        public async Task Valid()
        {
            // Arrange
            var productStore = new ProductStore();
            var handler = new GetProductsHandler(productStore);
            var request = new GetProductsRequest()
            { 
            };          

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Handler returned null result");
            Assert.IsNotNull(result.Products, "Product should not be null");
            Assert.AreEqual(ResponseCode.Successful, result.ResponseCode, "ResponseCode should be Successful");
            Assert.AreEqual(0, result.Errors.Count, "There should be no errors");

        }

    }
}
