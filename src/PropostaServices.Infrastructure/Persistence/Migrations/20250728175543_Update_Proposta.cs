using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostaServices.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Proposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Propostas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Propostas");
        }
    }
}
