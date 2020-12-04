using Microsoft.EntityFrameworkCore.Migrations;

namespace KlaipedaCity.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisineID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(nullable: true),
                    HotelAddress = table.Column<string>(nullable: true),
                    HotelRating = table.Column<int>(nullable: false),
                    HotelPrice = table.Column<int>(nullable: false),
                    HotelLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true),
                    CuisineNameCuisineID = table.Column<int>(nullable: false), //changes
                    RestaurantDesc = table.Column<string>(nullable: true),
                    RestaurantRating = table.Column<int>(nullable: false),
                    RestaurantPrice = table.Column<int>(nullable: false),
                    RestaurantLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantID);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cuisines_CuisineNameCuisineID",
                        column: x => x.CuisineNameCuisineID,
                        principalTable: "Cuisines",
                        principalColumn: "CuisineID",
                        onDelete: ReferentialAction.Cascade); //was Restrict before
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineNameCuisineID",
                table: "Restaurants",
                column: "CuisineNameCuisineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cuisines");
        }
    }
}
