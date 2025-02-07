using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignTechHomesTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ModifiedByUserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_CreatedBy",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ModifiedBy",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatedBy",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ModifiedBy",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ModifiedByUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUserId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedBy",
                table: "Projects",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ModifiedBy",
                table: "Projects",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedByUserId",
                table: "Clients",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModifiedByUserId",
                table: "Clients",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedByUserId",
                table: "Clients",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ModifiedByUserId",
                table: "Clients",
                column: "ModifiedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_CreatedBy",
                table: "Projects",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_ModifiedBy",
                table: "Projects",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
