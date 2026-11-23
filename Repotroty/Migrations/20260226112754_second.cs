using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Volunteers");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Tasks",
                newName: "TypeId");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsVolunteer",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    volunteersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsVolunteer", x => new { x.SkillsId, x.volunteersId });
                    table.ForeignKey(
                        name: "FK_SkillsVolunteer_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsVolunteer_Volunteers_volunteersId",
                        column: x => x.volunteersId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsVolunteer_volunteersId",
                table: "SkillsVolunteer",
                column: "volunteersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Skills_TypeId",
                table: "Tasks",
                column: "TypeId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Skills_TypeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "SkillsVolunteer");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TypeId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Tasks",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Volunteers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
