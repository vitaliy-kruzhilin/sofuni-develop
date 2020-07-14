using Microsoft.EntityFrameworkCore.Migrations;

namespace RentVacation.Statistics.Migrations
{
    public partial class InitStatisticsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartamentViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartamentViews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalApartaments = table.Column<int>(nullable: false),
                    TotalRentedApartaments = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalStatistics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartamentViews_ApartamentId",
                table: "ApartamentViews",
                column: "ApartamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartamentViews");

            migrationBuilder.DropTable(
                name: "TotalStatistics");
        }
    }
}
