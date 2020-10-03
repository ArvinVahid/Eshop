using Microsoft.EntityFrameworkCore.Migrations;

namespace Eshop.Data.Migrations
{
    public partial class EditOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinally",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinaly",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinaly",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinally",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
