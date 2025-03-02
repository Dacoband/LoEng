using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoEng.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    LevelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Levels__09F03C2652B547E7", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TagName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tags__657CF9ACBF3CA37D", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TopicName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Topics__022E0F5D1E796FE7", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CC332DD18", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WordTypes",
                columns: table => new
                {
                    WordTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WordType__C3532AAD5FA35DB9", x => x.WordTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EnglishWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VietnameseMeaning = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Pronunciation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WordTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Words__2C20F066D1723C41", x => x.WordId);
                    table.ForeignKey(
                        name: "FK__Words__LevelId__7D439ABD",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK__Words__TopicId__3B75D760",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId");
                    table.ForeignKey(
                        name: "FK__Words__WordTypeI__3C69FB99",
                        column: x => x.WordTypeId,
                        principalTable: "WordTypes",
                        principalColumn: "WordTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    ExampleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnglishExample = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VietnameseMeaning = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Examples__C464770951EE04F1", x => x.ExampleId);
                    table.ForeignKey(
                        name: "FK__Examples__WordId__440B1D61",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateTable(
                name: "Synonyms",
                columns: table => new
                {
                    SynonymId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SynonymWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Synonyms__066F6383DFAD1011", x => x.SynonymId);
                    table.ForeignKey(
                        name: "FK__Synonyms__WordId__412EB0B6",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateTable(
                name: "UserWords",
                columns: table => new
                {
                    UserWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsLearned = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LastReviewedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserWord__6E1BC12F8BAFDCC2", x => x.UserWordId);
                    table.ForeignKey(
                        name: "FK__UserWords__Level__7E37BEF6",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId");
                    table.ForeignKey(
                        name: "FK__UserWords__UserI__49C3F6B7",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__UserWords__WordI__4AB81AF0",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateTable(
                name: "WordTags",
                columns: table => new
                {
                    WordTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    WordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DelFlg = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WordTags__953D460CBC7084D6", x => x.WordTagId);
                    table.ForeignKey(
                        name: "FK__WordTags__TagId__534D60F1",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId");
                    table.ForeignKey(
                        name: "FK__WordTags__WordId__52593CB8",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "WordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_WordId",
                table: "Examples",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "UQ_LevelName",
                table: "Levels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Synonyms_WordId",
                table: "Synonyms",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "UQ_TagName",
                table: "Tags",
                column: "TagName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_TopicName",
                table: "Topics",
                column: "TopicName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWords_LevelId",
                table: "UserWords",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWords_UserId",
                table: "UserWords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWords_WordId",
                table: "UserWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LevelId",
                table: "Words",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_TopicId",
                table: "Words",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordTypeId",
                table: "Words",
                column: "WordTypeId");

            migrationBuilder.CreateIndex(
                name: "UQ_EnglishWord",
                table: "Words",
                column: "EnglishWord",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordTags_TagId",
                table: "WordTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_WordTags_WordId",
                table: "WordTags",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "UQ_TypeName",
                table: "WordTypes",
                column: "TypeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "Synonyms");

            migrationBuilder.DropTable(
                name: "UserWords");

            migrationBuilder.DropTable(
                name: "WordTags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "WordTypes");
        }
    }
}
