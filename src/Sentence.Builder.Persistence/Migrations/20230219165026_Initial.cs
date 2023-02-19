using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sentence.Builder.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "PartOfSpeech",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartOfSpeech = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfSpeech", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sentences",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PartOfSpeechEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_PartOfSpeech_PartOfSpeechEntityId",
                        column: x => x.PartOfSpeechEntityId,
                        principalSchema: "dbo",
                        principalTable: "PartOfSpeech",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentenceEntityWordEntity",
                schema: "dbo",
                columns: table => new
                {
                    SentenceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceEntityWordEntity", x => new { x.SentenceEntityId, x.WordsId });
                    table.ForeignKey(
                        name: "FK_SentenceEntityWordEntity_Sentences_SentenceEntityId",
                        column: x => x.SentenceEntityId,
                        principalSchema: "dbo",
                        principalTable: "Sentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SentenceEntityWordEntity_Words_WordsId",
                        column: x => x.WordsId,
                        principalSchema: "dbo",
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PartOfSpeech",
                columns: new[] { "Id", "DateCreated", "Description", "PartOfSpeech" },
                values: new object[,]
                {
                    { new Guid("0e92fd95-9627-4b2c-9b37-9c8a68866d94"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Determiner", "DET" },
                    { new Guid("11c261a1-c620-49ad-8239-18fd1b7edcb9"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Adjective", "ADJ" },
                    { new Guid("263b6887-e033-467f-a431-d08bfe68143c"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Preposition", "ADP" },
                    { new Guid("2890e295-9d27-4d6f-a49d-225cf6b0d806"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Adverb", "ADV" },
                    { new Guid("2e501489-e32b-41c0-b550-159e72e64a3f"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Conjunction", "CONJ" },
                    { new Guid("46c69f36-3c6f-4554-b172-99b1cb01c893"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Particle", "PRT" },
                    { new Guid("558bb598-c38f-493c-89c4-76db7860f466"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Pronoun", "PRON" },
                    { new Guid("5e48e8d4-c7a5-4bae-8e0a-fa0bf0558909"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Other", "X" },
                    { new Guid("7d2f7dd3-cf94-4357-8a66-9f9b84bdbe5b"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Punctuation Mark", "." },
                    { new Guid("9b074e51-5657-4955-8194-7c6b6b2aa531"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Numeral", "NUM" },
                    { new Guid("eec0e07d-88e6-4a7c-8a3d-07bd369ff1d2"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Exclamation", "EXC" },
                    { new Guid("f36bd21f-12fd-4072-bdcd-8b8b73ae0583"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Noun", "NOUN" },
                    { new Guid("f72f86bf-149b-4114-94a0-4bdc1ec4fc47"), new DateTimeOffset(new DateTime(2023, 2, 19, 12, 13, 50, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "Verb", "VERB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentenceEntityWordEntity_WordsId",
                schema: "dbo",
                table: "SentenceEntityWordEntity",
                column: "WordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_PartOfSpeechEntityId",
                schema: "dbo",
                table: "Words",
                column: "PartOfSpeechEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentenceEntityWordEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sentences",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Words",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PartOfSpeech",
                schema: "dbo");
        }
    }
}
