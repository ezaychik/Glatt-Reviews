using Microsoft.EntityFrameworkCore.Migrations;

namespace GlattReviews.Data.Migrations
{
    public partial class nonnullableFKsreviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ServiceProviders_ServiceProviderId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ServiceProviders_ServiceProviderId",
                table: "Reviews",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_ServiceProviders_ServiceProviderId",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceProviderId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Reviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Reviewers_ReviewerId",
                table: "Reviews",
                column: "ReviewerId",
                principalTable: "Reviewers",
                principalColumn: "ReviewerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_ServiceProviders_ServiceProviderId",
                table: "Reviews",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
