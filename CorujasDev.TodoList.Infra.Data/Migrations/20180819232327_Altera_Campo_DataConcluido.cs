using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorujasDev.TodoList.Infra.Data.Migrations
{
    public partial class Altera_Campo_DataConcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConcluido",
                table: "Tarefas",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataConcluido",
                table: "Tarefas",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
