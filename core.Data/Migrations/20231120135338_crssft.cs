using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace core.Data.Migrations
{
    public partial class crssft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CateringCompanies",
                columns: table => new
                {
                    CateringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringCompanies", x => x.CateringId);
                });

            migrationBuilder.CreateTable(
                name: "PrisonBlocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockDirection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonBlocks", x => x.BlockId);
                });

            migrationBuilder.CreateTable(
                name: "Prisons",
                columns: table => new
                {
                    PrisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrisonPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockCount = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    CateringId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisons", x => x.PrisonId);
                    table.ForeignKey(
                        name: "FK_Prisons_CateringCompanies_CateringId",
                        column: x => x.CateringId,
                        principalTable: "CateringCompanies",
                        principalColumn: "CateringId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrisonWards",
                columns: table => new
                {
                    PrisonWardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardBlock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardNumber = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    HowManyPrisonNum = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonWards", x => x.PrisonWardId);
                    table.ForeignKey(
                        name: "FK_PrisonWards_PrisonBlocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "PrisonBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrisonManagers",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrisonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrisonManagers", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_PrisonManagers_Prisons_PrisonId",
                        column: x => x.PrisonId,
                        principalTable: "Prisons",
                        principalColumn: "PrisonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prisoners",
                columns: table => new
                {
                    PrisonerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrisonerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrisonerLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PrisonersCrime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrimeDuration = table.Column<int>(type: "int", nullable: false),
                    PrisonWardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prisoners", x => x.PrisonerId);
                    table.ForeignKey(
                        name: "FK_Prisoners_PrisonWards_PrisonWardId",
                        column: x => x.PrisonWardId,
                        principalTable: "PrisonWards",
                        principalColumn: "PrisonWardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    GuardianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.GuardianId);
                    table.ForeignKey(
                        name: "FK_Guardians_PrisonBlocks_BlockId",
                        column: x => x.BlockId,
                        principalTable: "PrisonBlocks",
                        principalColumn: "BlockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guardians_PrisonManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "PrisonManagers",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idendificationNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrisonerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.VisitorId);
                    table.ForeignKey(
                        name: "FK_Visitors_Prisoners_PrisonerId",
                        column: x => x.PrisonerId,
                        principalTable: "Prisoners",
                        principalColumn: "PrisonerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_BlockId",
                table: "Guardians",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_ManagerId",
                table: "Guardians",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisoners_PrisonWardId",
                table: "Prisoners",
                column: "PrisonWardId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonManagers_PrisonId",
                table: "PrisonManagers",
                column: "PrisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Prisons_CateringId",
                table: "Prisons",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_PrisonWards_BlockId",
                table: "PrisonWards",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_PrisonerId",
                table: "Visitors",
                column: "PrisonerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "PrisonManagers");

            migrationBuilder.DropTable(
                name: "Prisoners");

            migrationBuilder.DropTable(
                name: "Prisons");

            migrationBuilder.DropTable(
                name: "PrisonWards");

            migrationBuilder.DropTable(
                name: "CateringCompanies");

            migrationBuilder.DropTable(
                name: "PrisonBlocks");
        }
    }
}
