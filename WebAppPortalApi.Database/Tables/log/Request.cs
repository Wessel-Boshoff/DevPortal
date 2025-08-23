using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace WebAppPortalApi.Database.Tables.log
{
    [Table("Requests", Schema = "log")]
    public class Request
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(2048)")]
        public string? Url { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public HttpStatusCode? HttpStatusCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(80)")]
        public string? HttpMethod { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string? RequestBody { get; set; }
        [Required]
        [Column(TypeName = "varchar(max)")]
        public string? ResponseBody { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string? RequestHeaders { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string? ResponseHeaders { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public TimeSpan? TimeTaken { get; set; }
        [Required]
        public int Archived { get; set; }
    }
}
