using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaNET_JuanJoseZapata.Migrations
{
    /// <inheritdoc />
    public partial class TableRoomsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "max_occupancy_persons",
                table: "rooms",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "max_occupancy_persons",
                table: "rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");
        }
    }
}
