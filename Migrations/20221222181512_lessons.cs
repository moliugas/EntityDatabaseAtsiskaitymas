using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityDB.Migrations
{
    /// <inheritdoc />
    public partial class lessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_Student.Department",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Student.Department",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_Student.Department",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "Student.Department");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_Student.Department");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_Student.Department",
                table: "Students",
                column: "Student.Department",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
