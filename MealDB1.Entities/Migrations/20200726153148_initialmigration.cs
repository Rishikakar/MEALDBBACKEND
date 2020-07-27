using Microsoft.EntityFrameworkCore.Migrations;

namespace MealDB1.Entities.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(nullable: true),
                    CountryImageUrl = table.Column<string>(nullable: true),
                    CountryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainIngredientName = table.Column<string>(nullable: true),
                    MainIngredientImageUrl = table.Column<string>(nullable: true),
                    MainIngredientDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(nullable: true),
                    UserSecondName = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(nullable: true),
                    MealImageUrl = table.Column<string>(nullable: true),
                    MealDescription = table.Column<string>(nullable: true),
                    SubIngredientOne = table.Column<string>(nullable: true),
                    SubIngredientOneUrl = table.Column<string>(nullable: true),
                    SubIngredientTwo = table.Column<string>(nullable: true),
                    SubIngredientTwoUrl = table.Column<string>(nullable: true),
                    SubIngredientThree = table.Column<string>(nullable: true),
                    SubIngredientThreeUrl = table.Column<string>(nullable: true),
                    SubIngredientFour = table.Column<string>(nullable: true),
                    SubIngredientFourUrl = table.Column<string>(nullable: true),
                    SubIngredientFive = table.Column<string>(nullable: true),
                    SubIngredientFiveUrl = table.Column<string>(nullable: true),
                    SubIngredientSix = table.Column<string>(nullable: true),
                    SubIngredientSixUrl = table.Column<string>(nullable: true),
                    MainIngredientsId = table.Column<int>(nullable: false),
                    CountrysId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Country_CountrysId",
                        column: x => x.CountrysId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meals_MainIngredients_MainIngredientsId",
                        column: x => x.MainIngredientsId,
                        principalTable: "MainIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_CountrysId",
                table: "Meals",
                column: "CountrysId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MainIngredientsId",
                table: "Meals",
                column: "MainIngredientsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "MainIngredients");
        }
    }
}
