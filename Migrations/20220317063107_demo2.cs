using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_API_StudentClass.Migrations
{
    public partial class demo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ StudentClass_Class_IdClass",
                table: " StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_ StudentClass_Student_IdStudent",
                table: " StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ StudentClass",
                table: " StudentClass");

            migrationBuilder.RenameTable(
                name: " StudentClass",
                newName: "StudentClass");

            migrationBuilder.RenameIndex(
                name: "IX_ StudentClass_IdClass",
                table: "StudentClass",
                newName: "IX_StudentClass_IdClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass",
                columns: new[] { "IdStudent", "IdClass" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Class_IdClass",
                table: "StudentClass",
                column: "IdClass",
                principalTable: "Class",
                principalColumn: "IdClass");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClass_Student_IdStudent",
                table: "StudentClass",
                column: "IdStudent",
                principalTable: "Student",
                principalColumn: "IdStudent",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Class_IdClass",
                table: "StudentClass");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClass_Student_IdStudent",
                table: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClass",
                table: "StudentClass");

            migrationBuilder.RenameTable(
                name: "StudentClass",
                newName: " StudentClass");

            migrationBuilder.RenameIndex(
                name: "IX_StudentClass_IdClass",
                table: " StudentClass",
                newName: "IX_ StudentClass_IdClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ StudentClass",
                table: " StudentClass",
                columns: new[] { "IdStudent", "IdClass" });

            migrationBuilder.AddForeignKey(
                name: "FK_ StudentClass_Class_IdClass",
                table: " StudentClass",
                column: "IdClass",
                principalTable: "Class",
                principalColumn: "IdClass");

            migrationBuilder.AddForeignKey(
                name: "FK_ StudentClass_Student_IdStudent",
                table: " StudentClass",
                column: "IdStudent",
                principalTable: "Student",
                principalColumn: "IdStudent",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
