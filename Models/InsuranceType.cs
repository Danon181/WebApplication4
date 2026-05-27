using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    [Table("insurance_types")]
    public class InsuranceType
    {
        [Key]
        [Column("insurance_type_id")]
        public int InsuranceTypeId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("salary_percent")]
        public double SalaryPercent { get; set; }
    }
}
