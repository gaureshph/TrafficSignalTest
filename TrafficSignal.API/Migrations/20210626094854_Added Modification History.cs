using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrafficSignal.API.Migrations
{
    public partial class AddedModificationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TrafficLights",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TrafficLights",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TrafficJunctions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TrafficJunctions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrafficLights_JunctionId",
                table: "TrafficLights",
                column: "JunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrafficLights_TrafficJunctions_JunctionId",
                table: "TrafficLights",
                column: "JunctionId",
                principalTable: "TrafficJunctions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrafficLights_TrafficJunctions_JunctionId",
                table: "TrafficLights");

            migrationBuilder.DropIndex(
                name: "IX_TrafficLights_JunctionId",
                table: "TrafficLights");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TrafficLights");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TrafficLights");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TrafficJunctions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TrafficJunctions");
        }
    }
}
