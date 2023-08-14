using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2_MVC_AaronVillalobosArguedas.Data.Migrations
{
    public partial class AddPropertyToPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Entregado",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entregado",
                table: "Pedidos");
        }
    }
}
