using WebAppPortalApi.Common.Models.Products;
using WebAppPortalApi.Core.Extensions;
using WebAppPortalApi.Core.Mappers.Products;
using WebAppPortalApi.Core.Mappers.Users;

namespace WebAppPortalApi.Core.Mappers.Products
{
    internal static class ProductMapper
    {
        /// <summary>
        /// purposely demonstrating implicit casting of complex objects 
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        internal static List<ProductMinimal> Map(this List<Database.Tables.dbo.Product> models) => models == default ? [] : [.. models.Select(c => c.Map(false))];

        internal static Product Map(this Database.Tables.dbo.Product entity, bool fullImage) =>
            entity == default ? new() : new()
            {
                Created = entity.Created,
                Description = entity.Description,
                ImageBase64 = fullImage ? Convert.ToBase64String(entity.ImageData) : null,
                ImageBase64Thumbnail = Convert.ToBase64String(entity.ImageData.GetThumbnail(entity.Extension)),
                Moniker = entity.Moniker,
                Name = entity.Name,
                User = entity.User?.Map() ?? new(),
                Extension = entity.Extension
            };

        internal static Database.Tables.dbo.Product MapAdd(this Product model, Database.Tables.dbo.User user) => model == default ? new() : new()
        {
            Created = DateTime.Now,
            Description = model.Description,
            Name = model.Name,
            ImageData = Convert.FromBase64String(model.ImageBase64 ?? ""),
            User = user,
            Moniker = Guid.NewGuid(),
            Extension = model.Extension
        };

        internal static Database.Tables.dbo.Product MapEdit(this Database.Tables.dbo.Product entity, Product model, Database.Tables.dbo.User user)
        {
            if (entity == default)
            {
                return entity ?? new();
            }

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageData = Convert.FromBase64String(model.ImageBase64 ?? "");
            entity.User = user;
            entity.Extension = model.Extension;

            return entity;
        }

    }
}
