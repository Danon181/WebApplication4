using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    middle_name = table.Column<string>(type: "TEXT", nullable: true),
                    address = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "insurance_types",
                columns: table => new
                {
                    insurance_type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    salary_percent = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurance_types", x => x.insurance_type_id);
                });

            migrationBuilder.CreateTable(
                name: "agents",
                columns: table => new
                {
                    agent_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    middle_name = table.Column<string>(type: "TEXT", nullable: true),
                    address = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    base_rate = table.Column<double>(type: "REAL", nullable: true),
                    branch_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agents", x => x.agent_id);
                    table.ForeignKey(
                        name: "FK_agents_branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branches",
                        principalColumn: "branch_id");
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    contract_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contract_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    insurance_sum = table.Column<double>(type: "REAL", nullable: false),
                    tariff_rate = table.Column<double>(type: "REAL", nullable: false),
                    client_id = table.Column<int>(type: "INTEGER", nullable: true),
                    agent_id = table.Column<int>(type: "INTEGER", nullable: true),
                    insurance_type_id = table.Column<int>(type: "INTEGER", nullable: true),
                    branch_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.contract_id);
                    table.ForeignKey(
                        name: "FK_contracts_agents_agent_id",
                        column: x => x.agent_id,
                        principalTable: "agents",
                        principalColumn: "agent_id");
                    table.ForeignKey(
                        name: "FK_contracts_branches_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branches",
                        principalColumn: "branch_id");
                    table.ForeignKey(
                        name: "FK_contracts_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id");
                    table.ForeignKey(
                        name: "FK_contracts_insurance_types_insurance_type_id",
                        column: x => x.insurance_type_id,
                        principalTable: "insurance_types",
                        principalColumn: "insurance_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_agents_branch_id",
                table: "agents",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_agent_id",
                table: "contracts",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_branch_id",
                table: "contracts",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_client_id",
                table: "contracts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_insurance_type_id",
                table: "contracts",
                column: "insurance_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "agents");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "insurance_types");

            migrationBuilder.DropTable(
                name: "branches");
        }
    }
}
