using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppPortalApi.Database.Tables.dbo;
using WebAppPortalApi.Database.Tables.log;

namespace WebAppPortal.Tests.Mock
{
    public static class TestEntities
    {
        public static User User()
        {
            var user = new User
            {
                FirstNames = "Test",
                LastName = "Test",
                EmailAddress = "Test@example.com",
                Created = DateTime.Now,
                LastSignIn = DateTime.Now,
                Moniker = Guid.Parse("686b752c-6a68-8011-a809-748a82653386"),
                Password = "Test",
                RegistrationStatus = WebAppPortalApi.Common.Enums.RegistrationStatus.Full,
                Role = WebAppPortalApi.Common.Enums.Role.Admin,
                Salt = "Test",
                Products = new List<Product>()
            };

            var product = Product(user);
            user.Products.Add(product);

            return user;
        }

        public static Product Product(User? owner = null) => new()
        {
            Created = DateTime.Now,
            Description = "Test",
            Extension = ".png",
            ImageData = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAADmUlEQVR4AbxWPUxTURQ+99YYeVVxMTGQmLgZIkpABBNgdsAJCa0uBicSY9RR4mRwVOMAkwQHpUaZZHCHKC0/wWiMGxNqwtRoqwPt9Xzv9dTb19s+VEpzv95zz/edn3d73+vTtNPP8MeDTcl00ktkJhlvGV+9RHo7QIbtDHyT0BBrd5o2soH4SPoMF3nixfJZZdRzTjzGOM84RqRiAYhtgm8MGmgRg1iK+NRtIJ5IPzBKrROpUSKqq2XeHqxVo4hFDpsI2ywMu4jiV1bavcTyqiF1q5r9Ow9yeInMKnK6IqsaOJBc6jOF4gKR6XQF/KOvEzkPJFf6wvEVDaBLbfQ8i5oZuz2atSnOx5NLp+3EFQ1wlzNMNqI4p/VHsyH9lIYNH15//edgxfnAsWs3t53TOYahDi+28kgYfwdwu+CwiLPxs7neNLLUizp+A0bRDSwagf62QySw82ulb2Ktg6eWuorFnaEWAmCHgSTgMIc5rOG3+Td3T1JutpswC7CGFjBEI15isUU37ctdZIdm0EDbYRq/1Op3jLWN8aFWn0MyFLM52DaPtWgmXm0ScOHeZ3+2myCzf1Dzo7MfAQBEmFEEsw1JCF89fuHTd0jKuD/3hQD4MYOQJngXBnDlHXDWg13cpbP5iblNl8TpU0q1o4ETNuvaBWyvaKJ4XKlow7PdqM8Zc5wbMEf9RelLEthiscEBkIrPtoWDLwzo5ULKOkVHuIGwlPzDAi+CANiAbK8kAAeAA4SHLcCdAeDcQItY2UX+vylwA2pLxDLLYUGQdA0OwZglQS0emjDkTpDYgFdb3ABtBAv3N7oGI8Vh24jicTECR44NNMAvHHbKwI4nlwOj9B3e3ii+FBY1rWujDP/3R+mIHN1XBEXxFeLSArX1z+34a14XGVUDVwng96si2QEOcPG1/Bwmo4jaml6e+sGnEe8BQlTN+A2rnJajFl/LH4SaGdTGGSBl6HHg3Ltvqek3kHvR816RebhX5VELNVHPbwBGLtVzm0itUeM/a0GtoFC5ASxVTOG9IAu7QciqmEaNcnpdttjIPTv7oaiKg2w2ookscqMG5y+Pigbg/TXbu8hd4h1hF38OtYacyI0aNqoaAIku86lzXTgsWP8PkCOf6u5CTlceZwMixGFRxvALi5lmn/NhxX7XYK2ZRixyuATiq9sARLhd8qmea/mC18yPzsvsm2K8Y3zjB1ghALFN8E1BAy1iEMu6uuM3AAAA//+B/rYhAAAABklEQVQDAFcThZ6vm5MRAAAAAElFTkSuQmCC"),
            Moniker = Guid.Parse("686b752c-6a68-8011-a809-748a82653386"),
            Name = "Test Product",
            User = owner
        };

        public static Request Request() => new()
        {
           Archived = 1,
           HttpMethod = "POST",
           HttpStatusCode = System.Net.HttpStatusCode.OK,
           RequestBody = "Test",
           RequestDate = DateTime.Now,
           RequestHeaders = "Test",
           ResponseBody = "Test",
           ResponseDate = DateTime.Now.AddMinutes(1),
           ResponseHeaders = "Test",
           TimeTaken = DateTime.Now.AddMinutes(1) - DateTime.Now,
           Url = "Test",
        };
    }
}
