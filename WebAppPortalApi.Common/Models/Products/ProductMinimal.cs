using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Common.Models.Products
{
    public class ProductMinimal
    {
        public string? Name { get; set; }
        public string? ImageBase64Thumbnail { get; set; }
        public string? Extension { get; set; }
        public Guid Moniker { get; set; }

    }
}
