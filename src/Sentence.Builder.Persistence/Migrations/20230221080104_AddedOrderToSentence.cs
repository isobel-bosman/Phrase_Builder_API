using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sentence.Builder.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderToSentence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WordIdOrder",
                schema: "dbo",
                table: "Sentences",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WordIdOrder",
                schema: "dbo",
                table: "Sentences");
        }
    }
}
