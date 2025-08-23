using WebAppPortalApiService.Models.Products;
using WebAppPortalApiService.Models.Users;
using WebAppPortalSite.Common.Models.Products;
namespace WebAppPortalSite.Mappers.Products
{
    internal static class ProductMapper
    {
        internal static Product Map(this ProductViewModel model) => model == default ? new() : new()
        {
            Moniker = model.Moniker,
            User = new User()
            {
                Moniker = model.UserMoniker
            },
            Description = model.Description,
            ImageBase64 = model.ImageBase64.Substring(model.ImageBase64.IndexOf(",") + 1),
            Name = model.Name,
            Extension = $".{model.ImageBase64.Split(";")[0].Split("/")[1]}"
        };


        internal static List<ProductViewModel> Map(this List<ProductMinimal> model) => model == default ? [] : [.. model.Select(c => c.Map())];
        internal static ProductViewModel Map(this ProductMinimal model) => model == default ? new() : new()
        {
            Moniker = model.Moniker,
            Name = model.Name,
            ImageBase64Thumbnail = model.ImageBase64Thumbnail,
            Extension = model.Extension

        };

        internal static ProductViewModel MapProduct(this Product model) => model == default ? new() : new()
        {
            Moniker = model.Moniker,
            Description = model.Description,
            ImageBase64 = model.ImageBase64,
            Name = model.Name,
            UserMoniker = model.User.Moniker,
            UserEmailAddress = model.User.EmailAddress,
            UserFirstNames = model.User.FirstNames,
            UserLastName = model.User.LastName,
            Created = model.Created
        };

    }
}
