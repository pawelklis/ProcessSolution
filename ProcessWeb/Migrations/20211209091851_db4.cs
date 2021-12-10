using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessWeb.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployeeDetails_tblEmployee_EmployeeId",
                table: "tblEmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblEmployeeDetails",
                table: "tblEmployeeDetails");

            migrationBuilder.RenameTable(
                name: "tblEmployeeDetails",
                newName: "EmployeeDetails");

            migrationBuilder.RenameIndex(
                name: "IX_tblEmployeeDetails_EmployeeId",
                table: "EmployeeDetails",
                newName: "IX_EmployeeDetails_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDetails",
                table: "EmployeeDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_tblEmployee_EmployeeId",
                table: "EmployeeDetails",
                column: "EmployeeId",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_tblEmployee_EmployeeId",
                table: "EmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDetails",
                table: "EmployeeDetails");

            migrationBuilder.RenameTable(
                name: "EmployeeDetails",
                newName: "tblEmployeeDetails");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "tblEmployeeDetails",
                newName: "IX_tblEmployeeDetails_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblEmployeeDetails",
                table: "tblEmployeeDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployeeDetails_tblEmployee_EmployeeId",
                table: "tblEmployeeDetails",
                column: "EmployeeId",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
