using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    [Table("contracts")]
    public class Contract
    {
        [Key]
        [Column("contract_id")]
        public int ContractId { get; set; }

        [Column("contract_date")]
        public DateTime ContractDate { get; set; }

        [Column("insurance_sum")]
        public double InsuranceSum { get; set; }

        [Column("tariff_rate")]
        public double TariffRate { get; set; }

        [Column("client_id")]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        [Column("agent_id")]
        public int? AgentId { get; set; }
        public Agent? Agent { get; set; }

        [Column("insurance_type_id")]
        public int? InsuranceTypeId { get; set; }
        public InsuranceType? InsuranceType { get; set; }

        [Column("branch_id")]
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
