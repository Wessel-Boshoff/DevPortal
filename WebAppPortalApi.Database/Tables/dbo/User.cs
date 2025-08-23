using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppPortalApi.Common.Enums;

namespace WebAppPortalApi.Database.Tables.dbo
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(254)")]
        public string? EmailAddress { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string? Salt { get; set; }
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string? FirstNames { get; set; }
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string? LastName { get; set; }
        [Required]
        public Guid Moniker { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public Role Role { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public RegistrationStatus RegistrationStatus { get; set; }

        public List<Product> Products { get; set; }

        [Required]
        public DateTime Created { get; set; }
        public DateTime? LastSignIn { get; set; }
    }
}
