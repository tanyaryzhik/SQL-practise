using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staffs_staffs_manager_id",
                schema: "sales",
                table: "staffs");

            migrationBuilder.DropIndex(
                name: "IX_staffs_manager_id",
                schema: "sales",
                table: "staffs");

            migrationBuilder.AlterColumn<int>(
                name: "store_id",
                schema: "sales",
                table: "orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                schema: "production",
                table: "brands",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[,]
                {
                    { 1, "BrandFirst" },
                    { 2, "BrandSecond" }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 3, "CategoryFirst" },
                    { 4, "CategorySecond" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "customers",
                columns: new[] { "customer_id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 9, "Akron", "allanpau@gmail.com", "Allan", "Pau", "54698", "Ohio", "3rd St", 25641 },
                    { 10, "Los Angeles", "katyperry@gmail.com", "Katy", "Perry", "25489", "California", "4th St", 26543 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "stores",
                columns: new[] { "store_id", "city", "email", "phone", "state", "store_name", "street", "zip_code" },
                values: new object[,]
                {
                    { 7, "New York", "firststore@gmail.com", "12345", "WashingtonDC", "StoreFirst", "1st Ave", 25364 },
                    { 8, "Dallas", "secondstore@gmail.com", "678910", "Texas", "StoreSecond", "2nd Ave", 52147 }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "products",
                columns: new[] { "product_id", "brand_id", "category_id", "model_year", "product_name", "list_price" },
                values: new object[,]
                {
                    { 5, 1, 3, 2000, "ProductFirst", 200.50m },
                    { 6, 2, 4, 2010, "ProductSecond", 400.50m }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "staffs",
                columns: new[] { "staff_id", "active", "email", "first_name", "last_name", "manager_id", "phone", "store_id" },
                values: new object[,]
                {
                    { 11, true, "jimkerry@gmail.com", "Jim", "Kerry", 20, "2598", 7 },
                    { 12, true, "katylerry@gmail.com", "Katy", "lerry", 20, "3654", 8 },
                    { 20, true, "katyJerry@gmail.com", "Katy", "Jerry", 0, "3654", 8 }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "stocks",
                columns: new[] { "store_id", "product_id", "quantity" },
                values: new object[,]
                {
                    { 8, 5, 10 },
                    { 7, 6, 5 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "orders",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[,]
                {
                    { 14, 9, new DateTime(2020, 3, 16, 18, 1, 5, 906, DateTimeKind.Local).AddTicks(5472), "Pending", new DateTime(2020, 3, 16, 18, 1, 5, 906, DateTimeKind.Local).AddTicks(5496), new DateTime(2020, 3, 16, 18, 1, 5, 906, DateTimeKind.Local).AddTicks(5508), 11, 8 },
                    { 13, 10, new DateTime(2020, 3, 16, 18, 1, 5, 903, DateTimeKind.Local).AddTicks(3197), "Pending", new DateTime(2020, 3, 16, 18, 1, 5, 906, DateTimeKind.Local).AddTicks(2979), new DateTime(2020, 3, 16, 18, 1, 5, 906, DateTimeKind.Local).AddTicks(3692), 12, 7 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "order_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[] { 14, 6, 0, 100m, 1 });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "order_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[] { 13, 5, 0, 52m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "store_id", "product_id" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "store_id", "product_id" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "order_id", "product_id" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "order_id", "product_id" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "store_id",
                schema: "sales",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_staffs_manager_id",
                schema: "sales",
                table: "staffs",
                column: "manager_id");

            migrationBuilder.AddForeignKey(
                name: "FK_staffs_staffs_manager_id",
                schema: "sales",
                table: "staffs",
                column: "manager_id",
                principalSchema: "sales",
                principalTable: "staffs",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
