using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("client_id")]
        public int ClientId { get; set; }

        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("email")]
        public string? Email { get; set; }
    }
}