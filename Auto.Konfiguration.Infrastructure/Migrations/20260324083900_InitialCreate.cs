using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auto.Konfiguration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Felgen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felgen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lacke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lacke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EngineId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaintId = table.Column<int>(type: "INTEGER", nullable: false),
                    RimsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Felgen_RimsId",
                        column: x => x.RimsId,
                        principalTable: "Felgen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Lacke_PaintId",
                        column: x => x.PaintId,
                        principalTable: "Lacke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Motoren_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Motoren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CarConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extras_Configurations_CarConfigurationId",
                        column: x => x.CarConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_EngineId",
                table: "Configurations",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_PaintId",
                table: "Configurations",
                column: "PaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_RimsId",
                table: "Configurations",
                column: "RimsId");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_CarConfigurationId",
                table: "Extras",
                column: "CarConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Felgen");

            migrationBuilder.DropTable(
                name: "Lacke");

            migrationBuilder.DropTable(
                name: "Motoren");
        }
    }
}
