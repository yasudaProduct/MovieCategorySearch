using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCategorySearch.Infrastructure.Migrations
{
    public partial class AddUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    mail_address = table.Column<string>(type: "character varying(319)", maxLength: 319, nullable: false),
                    user_cls = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
