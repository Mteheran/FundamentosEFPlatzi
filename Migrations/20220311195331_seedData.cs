using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundamentosEFPlatzi.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("46a837b2-ce88-4304-82fb-b574d23c1e3e"), null, "Actividad personal", 0 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("ef6e255a-d835-48b0-87f4-4e33d138db5e"), null, "Pendientes", 0 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("33fd29d5-7bb4-4b54-85a1-e4348613c2e7"), new Guid("ef6e255a-d835-48b0-87f4-4e33d138db5e"), null, new DateTime(2022, 3, 11, 14, 53, 31, 65, DateTimeKind.Local).AddTicks(5894), 2, "Revisar la tesis de grado" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("c15dd6dc-aad8-4470-a23c-c3b84238fc72"), new Guid("46a837b2-ce88-4304-82fb-b574d23c1e3e"), null, new DateTime(2022, 3, 11, 14, 53, 31, 65, DateTimeKind.Local).AddTicks(5904), 0, "Comprar nuevo comic de batman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("33fd29d5-7bb4-4b54-85a1-e4348613c2e7"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("c15dd6dc-aad8-4470-a23c-c3b84238fc72"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("46a837b2-ce88-4304-82fb-b574d23c1e3e"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ef6e255a-d835-48b0-87f4-4e33d138db5e"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
