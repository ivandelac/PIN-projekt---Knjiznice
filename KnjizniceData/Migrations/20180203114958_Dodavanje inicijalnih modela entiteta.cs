using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KnjizniceData.Migrations
{
    public partial class Dodavanjeinicijalnihmodelaentiteta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClanskaIskaznicaId",
                table: "Clanovi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaticnaKnjiznicaId",
                table: "Clanovi",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClanskeIskaznice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    Zakasnine = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanskeIskaznice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjiznice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adresa = table.Column<string>(nullable: false),
                    DatumOtvaranja = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiznice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statusi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statusi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RadnoVrijeme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DanTjedna = table.Column<int>(nullable: false),
                    KnjiznicaId = table.Column<int>(nullable: true),
                    VrijemeOtvaranja = table.Column<int>(nullable: false),
                    VrijemeZatvaranja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoVrijeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoVrijeme_Knjiznice_KnjiznicaId",
                        column: x => x.KnjiznicaId,
                        principalTable: "Knjiznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradjaKnjiznice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPrimjeraka = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    GodinaIzdavanja = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: false),
                    LokacijaId = table.Column<int>(nullable: true),
                    Naslov = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    Autor = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Redatelj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradjaKnjiznice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradjaKnjiznice_Knjiznice_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Knjiznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GradjaKnjiznice_Statusi_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posudbe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaIskaznicaId = table.Column<int>(nullable: true),
                    Do = table.Column<DateTime>(nullable: false),
                    GradjaKnjizniceId = table.Column<int>(nullable: false),
                    Od = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posudbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posudbe_ClanskeIskaznice_ClanskaIskaznicaId",
                        column: x => x.ClanskaIskaznicaId,
                        principalTable: "ClanskeIskaznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posudbe_GradjaKnjiznice_GradjaKnjizniceId",
                        column: x => x.GradjaKnjizniceId,
                        principalTable: "GradjaKnjiznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PovijestPosudbi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaIskaznicaId = table.Column<int>(nullable: false),
                    GradjaKnjizniceId = table.Column<int>(nullable: false),
                    Posudjeno = table.Column<DateTime>(nullable: false),
                    Vraceno = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PovijestPosudbi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PovijestPosudbi_ClanskeIskaznice_ClanskaIskaznicaId",
                        column: x => x.ClanskaIskaznicaId,
                        principalTable: "ClanskeIskaznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PovijestPosudbi_GradjaKnjiznice_GradjaKnjizniceId",
                        column: x => x.GradjaKnjizniceId,
                        principalTable: "GradjaKnjiznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClanskaIskaznicaId = table.Column<int>(nullable: true),
                    GradjaKnjizniceId = table.Column<int>(nullable: true),
                    Rezervirano = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_ClanskeIskaznice_ClanskaIskaznicaId",
                        column: x => x.ClanskaIskaznicaId,
                        principalTable: "ClanskeIskaznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_GradjaKnjiznice_GradjaKnjizniceId",
                        column: x => x.GradjaKnjizniceId,
                        principalTable: "GradjaKnjiznice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_ClanskaIskaznicaId",
                table: "Clanovi",
                column: "ClanskaIskaznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_MaticnaKnjiznicaId",
                table: "Clanovi",
                column: "MaticnaKnjiznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_GradjaKnjiznice_LokacijaId",
                table: "GradjaKnjiznice",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_GradjaKnjiznice_StatusId",
                table: "GradjaKnjiznice",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Posudbe_ClanskaIskaznicaId",
                table: "Posudbe",
                column: "ClanskaIskaznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Posudbe_GradjaKnjizniceId",
                table: "Posudbe",
                column: "GradjaKnjizniceId");

            migrationBuilder.CreateIndex(
                name: "IX_PovijestPosudbi_ClanskaIskaznicaId",
                table: "PovijestPosudbi",
                column: "ClanskaIskaznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PovijestPosudbi_GradjaKnjizniceId",
                table: "PovijestPosudbi",
                column: "GradjaKnjizniceId");

            migrationBuilder.CreateIndex(
                name: "IX_RadnoVrijeme_KnjiznicaId",
                table: "RadnoVrijeme",
                column: "KnjiznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_ClanskaIskaznicaId",
                table: "Rezervacije",
                column: "ClanskaIskaznicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_GradjaKnjizniceId",
                table: "Rezervacije",
                column: "GradjaKnjizniceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_ClanskeIskaznice_ClanskaIskaznicaId",
                table: "Clanovi",
                column: "ClanskaIskaznicaId",
                principalTable: "ClanskeIskaznice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_Knjiznice_MaticnaKnjiznicaId",
                table: "Clanovi",
                column: "MaticnaKnjiznicaId",
                principalTable: "Knjiznice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_ClanskeIskaznice_ClanskaIskaznicaId",
                table: "Clanovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_Knjiznice_MaticnaKnjiznicaId",
                table: "Clanovi");

            migrationBuilder.DropTable(
                name: "Posudbe");

            migrationBuilder.DropTable(
                name: "PovijestPosudbi");

            migrationBuilder.DropTable(
                name: "RadnoVrijeme");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "ClanskeIskaznice");

            migrationBuilder.DropTable(
                name: "GradjaKnjiznice");

            migrationBuilder.DropTable(
                name: "Knjiznice");

            migrationBuilder.DropTable(
                name: "Statusi");

            migrationBuilder.DropIndex(
                name: "IX_Clanovi_ClanskaIskaznicaId",
                table: "Clanovi");

            migrationBuilder.DropIndex(
                name: "IX_Clanovi_MaticnaKnjiznicaId",
                table: "Clanovi");

            migrationBuilder.DropColumn(
                name: "ClanskaIskaznicaId",
                table: "Clanovi");

            migrationBuilder.DropColumn(
                name: "MaticnaKnjiznicaId",
                table: "Clanovi");
        }
    }
}
