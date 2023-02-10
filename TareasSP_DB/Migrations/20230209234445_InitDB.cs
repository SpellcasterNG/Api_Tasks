using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasSPDB.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(name: "Id_User", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    IDTask = table.Column<int>(name: "ID_Task", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(name: "Creation_Date", type: "datetime2", nullable: false),
                    NotificacionDate = table.Column<DateTime>(name: "Notificacion_Date", type: "datetime2", nullable: false),
                    IDUser = table.Column<int>(name: "ID_User", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.IDTask);
                    table.ForeignKey(
                        name: "FK_Task_User_ID_User",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_ID_User",
                table: "Task",
                column: "ID_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
