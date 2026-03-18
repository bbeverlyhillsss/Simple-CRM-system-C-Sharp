using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_CRM_system_C_Sharp_.Migrations
{
    /// <inheritdoc />
    public partial class AddComplaintEvidence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvidenceFilePath",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvidenceFilePath",
                table: "Complaints");
        }
    }
}
