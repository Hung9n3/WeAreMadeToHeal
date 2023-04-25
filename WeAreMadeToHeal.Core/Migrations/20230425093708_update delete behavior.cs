using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeAreMadeToHeal.Migrations
{
    /// <inheritdoc />
    public partial class updatedeletebehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TagProducts_Products_ProductId",
                table: "TagProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TagProducts_Tags_TagId",
                table: "TagProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TagProducts_Products_ProductId",
                table: "TagProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagProducts_Tags_TagId",
                table: "TagProducts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TagProducts_Products_ProductId",
                table: "TagProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TagProducts_Tags_TagId",
                table: "TagProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponUsers_Coupons_CouponId",
                table: "CouponUsers",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagProducts_Products_ProductId",
                table: "TagProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagProducts_Tags_TagId",
                table: "TagProducts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
