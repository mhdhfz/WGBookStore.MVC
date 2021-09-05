using Microsoft.EntityFrameworkCore.Migrations;

namespace WGBookStore.MVC.Migrations
{
    public partial class AddedCoverPhotoUrlColumnInBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoUrl",
                table: "Books");
        }
    }
}
