using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CuisineOrdersAPI.Migrations
{
    public partial class IntialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OnlineOrderHeader",
                columns: table => new
                {
                    OnlineOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppOrderID = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: true),
                    OrderKey = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CreatedVia = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Version = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Status = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Currency = table.Column<string>(unicode: false, fixedLength: true, maxLength: 3, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountTotal = table.Column<decimal>(type: "money", nullable: true),
                    DiscountTax = table.Column<decimal>(type: "money", nullable: true),
                    CartTax = table.Column<decimal>(type: "money", nullable: true),
                    CartTotal = table.Column<decimal>(type: "money", nullable: true),
                    PriceIncludesTax = table.Column<bool>(nullable: true),
                    CustomerID = table.Column<int>(nullable: true),
                    CustomerFirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CustomerLastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CustomerEmail = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CustomerPhone = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CustomerEmployeeNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PaymentMethod = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    TransactionID = table.Column<int>(nullable: true),
                    DatePaid = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrderURL = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CustomerNotes = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CuisineOrderStatus = table.Column<string>(unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('Not Processed')"),
                    OrderLinesSaved = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineOrderHeader", x => x.OnlineOrderID);
                });

            migrationBuilder.CreateTable(
                name: "OnlineOrderLines",
                columns: table => new
                {
                    OnlineOrderLineID = table.Column<int>(nullable: false),
                    OnlineOrderHeaderID = table.Column<int>(nullable: true),
                    AppOrderID = table.Column<int>(nullable: true),
                    AppOrderLineID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    SKU = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: true),
                    SubTotalTax = table.Column<decimal>(type: "money", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    ProductDescription = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Category = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineOrderLines", x => x.OnlineOrderLineID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineOrderHeader");

            migrationBuilder.DropTable(
                name: "OnlineOrderLines");
        }
    }
}
