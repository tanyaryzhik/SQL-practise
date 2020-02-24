using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class CreateMoviesDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    act_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    act_fname = table.Column<string>(maxLength: 20, nullable: true),
                    act_lname = table.Column<string>(maxLength: 20, nullable: true),
                    act_gender = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.act_id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    dir_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dir_fname = table.Column<string>(maxLength: 20, nullable: true),
                    dir_lname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.dir_id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    gen_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gen_title = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.gen_id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mov_title = table.Column<string>(maxLength: 50, nullable: true),
                    mov_year = table.Column<int>(nullable: false),
                    mov_time = table.Column<int>(nullable: false),
                    mov_lang = table.Column<string>(maxLength: 50, nullable: true),
                    mov_dt_rel = table.Column<DateTime>(nullable: false),
                    mov_rel_country = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.mov_id);
                });

            migrationBuilder.CreateTable(
                name: "Reviewer",
                columns: table => new
                {
                    rev_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rev_name = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviewer", x => x.rev_id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCast",
                columns: table => new
                {
                    act_id = table.Column<int>(nullable: false),
                    mov_id = table.Column<int>(nullable: false),
                    role = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCast", x => new { x.mov_id, x.act_id });
                    table.ForeignKey(
                        name: "FK_MovieCast_Actor_act_id",
                        column: x => x.act_id,
                        principalTable: "Actor",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCast_Movie_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movie",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirection",
                columns: table => new
                {
                    dir_id = table.Column<int>(nullable: false),
                    mov_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirection", x => new { x.mov_id, x.dir_id });
                    table.ForeignKey(
                        name: "FK_MovieDirection_Director_dir_id",
                        column: x => x.dir_id,
                        principalTable: "Director",
                        principalColumn: "dir_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirection_Movie_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movie",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    gen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.mov_id, x.gen_id });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_gen_id",
                        column: x => x.gen_id,
                        principalTable: "Genre",
                        principalColumn: "gen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movie",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    mov_id = table.Column<int>(nullable: false),
                    rev_id = table.Column<int>(nullable: false),
                    rev_stars = table.Column<int>(nullable: false),
                    num_of_rev = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => new { x.mov_id, x.rev_id });
                    table.ForeignKey(
                        name: "FK_Rating_Movie_mov_id",
                        column: x => x.mov_id,
                        principalTable: "Movie",
                        principalColumn: "mov_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Reviewer_rev_id",
                        column: x => x.rev_id,
                        principalTable: "Reviewer",
                        principalColumn: "rev_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_act_id",
                table: "MovieCast",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirection_dir_id",
                table: "MovieDirection",
                column: "dir_id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_gen_id",
                table: "MovieGenre",
                column: "gen_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_rev_id",
                table: "Rating",
                column: "rev_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCast");

            migrationBuilder.DropTable(
                name: "MovieDirection");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Reviewer");
        }
    }
}
