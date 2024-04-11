using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieCategorySearch.Infrastructure.MovieCategorySearch.Infrastructure.Data.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    tmdb_movie_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "0"),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<int>(type: "integer", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie", x => x.tmdb_movie_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    mail_address = table.Column<string>(type: "character varying(319)", maxLength: 319, nullable: false),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    user_cls = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "0"),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<int>(type: "integer", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    create_user_id = table.Column<int>(type: "integer", nullable: false),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false, defaultValue: "0"),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<int>(type: "integer", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_user_create_user_id",
                        column: x => x.create_user_id,
                        principalTable: "user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_map",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    movie_id = table.Column<int>(type: "integer", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<int>(type: "integer", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_map", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_map_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_map_movie_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movie",
                        principalColumn: "tmdb_movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_create_user_id",
                table: "category",
                column: "create_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_map_category_id",
                table: "category_map",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_map_movie_id",
                table: "category_map",
                column: "movie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_map");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "movie");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
