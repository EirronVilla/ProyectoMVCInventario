using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2_MVC_AaronVillalobosArguedas.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadDeMedida = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    CantidadMaxima = table.Column<int>(type: "int", nullable: false),
                    CantidadActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    CantidadDePedido = table.Column<int>(type: "int", nullable: false),
                    PrecioPorUnidadDeMedida = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonaQueEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaQueRecibe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaQueRecibe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadARetirar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retiros_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoId",
                table: "Pedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Retiros_ProductoId",
                table: "Retiros",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Retiros");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
