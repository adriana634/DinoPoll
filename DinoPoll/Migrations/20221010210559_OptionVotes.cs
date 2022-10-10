using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DinoPoll.Migrations
{
    public partial class OptionVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Votes",
                table: "Options",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Options");
        }
    }
}
