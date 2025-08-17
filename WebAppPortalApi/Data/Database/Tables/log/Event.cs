using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace WebAppPortalApi.Data.Database.Tables.log
{
    [Table("Events", Schema = "log")]
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public string? LogLevel { get; set; } 
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string? State { get; set; } 
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string? Message { get; set; } 
        [Required]
        [Column( TypeName = "varchar(max)")]
        public string? StackTrace { get; set; } 
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string? Exception { get; set; } 
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
