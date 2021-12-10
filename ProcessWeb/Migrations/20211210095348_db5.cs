using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessWeb.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_tblEmployee_EmployeeId",
                table: "EmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDetails",
                table: "EmployeeDetails");

            migrationBuilder.RenameTable(
                name: "EmployeeDetails",
                newName: "employeedetails");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "employeedetails",
                newName: "IX_employeedetails_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "tblEmployee",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeedetails",
                table: "employeedetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_AddressId",
                table: "tblEmployee",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_employeedetails_tblEmployee_EmployeeId",
                table: "employeedetails",
                column: "EmployeeId",
                principalTable: "tblEmployee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEmployee_Address_AddressId",
                table: "tblEmployee",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeedetails_tblEmployee_EmployeeId",
                table: "employeedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEmployee_Address_AddressId",
                table: "tblEmployee");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_tblEmployee_AddressId",
                table: "tblEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeedetails",
                table: "employeedetails");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "tblEmployee");

            migrationBuilder.RenameTable(
                name: "employeedetails",
                newName: "EmployeeDetails");

            migrationBuilder.RenameIndex(
                name: "IX_employeedetails_EmployeeId",
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
    }
}
