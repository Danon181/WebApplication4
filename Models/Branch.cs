using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    [Table("branches")]
    public class Branch
    {
        [Key]
        [Column("branch_id")]
        public int BranchId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("phone")]
        public string? Phone { get; set; }
    }
}
