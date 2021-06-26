using Microsoft.EntityFrameworkCore.Migrations;

namespace TrafficSignal.API.Migrations
{
    public partial class MadeStatusDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusChangeDate",
                table: "TrafficLights",
                newName: "StatusChangeDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusChangeDateTime",
                table: "TrafficLights",
                newName: "StatusChangeDate");
        }
    }
}
