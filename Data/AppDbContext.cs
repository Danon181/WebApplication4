using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(e => {
                e.ToTable("branches");
                e.HasKey(x => x.BranchId);
                e.Property(x => x.BranchId).HasColumnName("branch_id");
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Address).HasColumnName("address");
                e.Property(x => x.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Agent>(e => {
                e.ToTable("agents");
                e.HasKey(x => x.AgentId);
                e.Property(x => x.AgentId).HasColumnName("agent_id");
                e.Property(x => x.LastName).HasColumnName("last_name");
                e.Property(x => x.FirstName).HasColumnName("first_name");
                e.Property(x => x.MiddleName).HasColumnName("middle_name");
                e.Property(x => x.Address).HasColumnName("address");
                e.Property(x => x.Phone).HasColumnName("phone");
                e.Property(x => x.BranchId).HasColumnName("branch_id");
            });

            modelBuilder.Entity<Client>(e => {
                e.ToTable("clients");
                e.HasKey(x => x.ClientId);
                e.Property(x => x.ClientId).HasColumnName("client_id");
                e.Property(x => x.LastName).HasColumnName("last_name");
                e.Property(x => x.FirstName).HasColumnName("first_name");
                e.Property(x => x.MiddleName).HasColumnName("middle_name");
                e.Property(x => x.Address).HasColumnName("address");
                e.Property(x => x.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<InsuranceType>(e => {
                e.ToTable("insurance_types");
                e.HasKey(x => x.InsuranceTypeId);
                e.Property(x => x.InsuranceTypeId).HasColumnName("insurance_type_id");
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.SalaryPercent).HasColumnName("salary_percent");
            });

            modelBuilder.Entity<Contract>(e => {
                e.ToTable("contracts");
                e.HasKey(x => x.ContractId);
                e.Property(x => x.ContractId).HasColumnName("contract_id");
                e.Property(x => x.ContractDate).HasColumnName("contract_date");
                e.Property(x => x.InsuranceSum).HasColumnName("insurance_sum");
                e.Property(x => x.TariffRate).HasColumnName("tariff_rate");
                e.Property(x => x.ClientId).HasColumnName("client_id");
                e.Property(x => x.AgentId).HasColumnName("agent_id");
                e.Property(x => x.InsuranceTypeId).HasColumnName("insurance_type_id");
                e.Property(x => x.BranchId).HasColumnName("branch_id");
            });
        }
    }
}
