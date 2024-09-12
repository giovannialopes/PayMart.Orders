using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayMart.Infrastructure.Orders.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Tb_Order",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Tb_Order",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tb_Order",
                newName: "OrderName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tb_Order",
                newName: "OrderDate");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Tb_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tb_Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Tb_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Tb_Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tb_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Tb_Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tb_Order",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tb_Order");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tb_Order");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tb_Order",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Tb_Order",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "OrderName",
                table: "Tb_Order",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Tb_Order",
                newName: "Date");
        }
    }
}
