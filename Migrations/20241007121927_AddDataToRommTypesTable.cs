using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PruebaNET_JuanJoseZapata.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToRommTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "room_types",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "A cozy basic room with a single bed, ideal for single travelers.", "single room" },
                    { 2, "It offers flexibility with two single beds or a double bed, perfect for couples or friends.", "Double Room" },
                    { 3, "Spacious and luxurious, with a king size bed and a separate living room, ideal for those seeking comfort and exclusivity.", "Suite" },
                    { 4, "Designed for families, with additional space and several beds for a comfortable stay.", "Family Room" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
