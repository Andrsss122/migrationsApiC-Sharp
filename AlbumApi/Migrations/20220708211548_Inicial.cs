using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace AlbumApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artista",
                columns: table => new
                {
                    IdArtista = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artista", x => x.IdArtista);
                });

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    IdGenero = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 150, nullable: true),
                    artistaIdArtista = table.Column<int>(nullable: true),
                    generoIdGenero = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_album_artista_artistaIdArtista",
                        column: x => x.artistaIdArtista,
                        principalTable: "artista",
                        principalColumn: "IdArtista",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_album_genero_generoIdGenero",
                        column: x => x.generoIdGenero,
                        principalTable: "genero",
                        principalColumn: "IdGenero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_album_artistaIdArtista",
                table: "album",
                column: "artistaIdArtista");

            migrationBuilder.CreateIndex(
                name: "IX_album_generoIdGenero",
                table: "album",
                column: "generoIdGenero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "album");

            migrationBuilder.DropTable(
                name: "artista");

            migrationBuilder.DropTable(
                name: "genero");
        }
    }
}
