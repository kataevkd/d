using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ManageInformation.Infrastructure.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gibdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    License = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gibdd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mvd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Passport = table.Column<int>(type: "integer", nullable: false),
                    FamilyName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mvd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nalogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    INN = table.Column<int>(type: "integer", nullable: false),
                    property = table.Column<string>(type: "text", nullable: false),
                    bills = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nalogi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SNILS = table.Column<int>(type: "integer", nullable: false),
                    WorkBook = table.Column<int>(type: "integer", nullable: false),
                    SocialStatus = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarNumber = table.Column<string>(type: "text", nullable: false),
                    OwnerLicenseId = table.Column<int>(type: "integer", nullable: false),
                    CarMarka = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_gibdd_OwnerLicenseId",
                        column: x => x.OwnerLicenseId,
                        principalTable: "gibdd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MVDId = table.Column<int>(type: "integer", nullable: false),
                    NalogovayaId = table.Column<int>(type: "integer", nullable: false),
                    GIBDDId = table.Column<int>(type: "integer", nullable: false),
                    PFRId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_gibdd_GIBDDId",
                        column: x => x.GIBDDId,
                        principalTable: "gibdd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_mvd_MVDId",
                        column: x => x.MVDId,
                        principalTable: "mvd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_nalogi_NalogovayaId",
                        column: x => x.NalogovayaId,
                        principalTable: "nalogi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_pfr_PFRId",
                        column: x => x.PFRId,
                        principalTable: "pfr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_OwnerLicenseId",
                table: "cars",
                column: "OwnerLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_person_GIBDDId",
                table: "person",
                column: "GIBDDId");

            migrationBuilder.CreateIndex(
                name: "IX_person_MVDId",
                table: "person",
                column: "MVDId");

            migrationBuilder.CreateIndex(
                name: "IX_person_NalogovayaId",
                table: "person",
                column: "NalogovayaId");

            migrationBuilder.CreateIndex(
                name: "IX_person_PFRId",
                table: "person",
                column: "PFRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "gibdd");

            migrationBuilder.DropTable(
                name: "mvd");

            migrationBuilder.DropTable(
                name: "nalogi");

            migrationBuilder.DropTable(
                name: "pfr");
        }
    }
}
