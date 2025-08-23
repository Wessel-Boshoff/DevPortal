using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPortalApi.Database.Tables.dbo
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string? Description { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[]? ImageData { get; set; }

        [Column(TypeName = "varchar(35)")]
        public string? Extension { get; set; }

        [Required]
        public User? User { get; set; }

        [Required]
        public Guid Moniker { get; set; }
        [Required]
        public DateTime Created { get; set; }

    }
}
