using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageProject.Migrations.My
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true),
                    AlbumCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyMedia_AlbumCategories_AlbumCategoryId",
                        column: x => x.AlbumCategoryId,
                        principalTable: "AlbumCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyMedia_AlbumCategoryId",
                table: "MyMedia",
                column: "AlbumCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyMedia");

            migrationBuilder.DropTable(
                name: "AlbumCategories");
        }
    }
}
