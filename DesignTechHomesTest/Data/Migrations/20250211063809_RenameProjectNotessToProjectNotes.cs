using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesignTechHomesTest.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameProjectNotessToProjectNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUploads_Projects_ProjectId",
                table: "ImageUploads");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectNotess_Projects_ProjectId",
                table: "ProjectNotess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectNotess",
                table: "ProjectNotess");

            migrationBuilder.RenameTable(
                name: "ProjectNotess",
                newName: "ProjectNotes");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectNotess_ProjectId",
                table: "ProjectNotes",
                newName: "IX_ProjectNotes_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectNotes",
                table: "ProjectNotes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUploads_Projects_ProjectId",
                table: "ImageUploads",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectNotes_Projects_ProjectId",
                table: "ProjectNotes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUploads_Projects_ProjectId",
                table: "ImageUploads");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectNotes_Projects_ProjectId",
                table: "ProjectNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectNotes",
                table: "ProjectNotes");

            migrationBuilder.RenameTable(
                name: "ProjectNotes",
                newName: "ProjectNotess");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectNotes_ProjectId",
                table: "ProjectNotess",
                newName: "IX_ProjectNotess_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectNotess",
                table: "ProjectNotess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUploads_Projects_ProjectId",
                table: "ImageUploads",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectNotess_Projects_ProjectId",
                table: "ProjectNotess",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
