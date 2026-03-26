using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auto.Konfiguration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlToCarConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Felgen_RimsId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Lacke_PaintId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Motoren_EngineId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Configurations_CarConfigurationId",
                table: "Extras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motoren",
                table: "Motoren");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lacke",
                table: "Lacke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Felgen",
                table: "Felgen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Extras",
                table: "Extras");

            migrationBuilder.RenameTable(
                name: "Motoren",
                newName: "Engines");

            migrationBuilder.RenameTable(
                name: "Lacke",
                newName: "Paints");

            migrationBuilder.RenameTable(
                name: "Felgen",
                newName: "Rimses");

            migrationBuilder.RenameTable(
                name: "Extras",
                newName: "OptionalEquipments");

            migrationBuilder.RenameIndex(
                name: "IX_Extras_CarConfigurationId",
                table: "OptionalEquipments",
                newName: "IX_OptionalEquipments_CarConfigurationId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Configurations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engines",
                table: "Engines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paints",
                table: "Paints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rimses",
                table: "Rimses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionalEquipments",
                table: "OptionalEquipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Engines_EngineId",
                table: "Configurations",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Paints_PaintId",
                table: "Configurations",
                column: "PaintId",
                principalTable: "Paints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Rimses_RimsId",
                table: "Configurations",
                column: "RimsId",
                principalTable: "Rimses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionalEquipments_Configurations_CarConfigurationId",
                table: "OptionalEquipments",
                column: "CarConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Engines_EngineId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Paints_PaintId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Configurations_Rimses_RimsId",
                table: "Configurations");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionalEquipments_Configurations_CarConfigurationId",
                table: "OptionalEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rimses",
                table: "Rimses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paints",
                table: "Paints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionalEquipments",
                table: "OptionalEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engines",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Configurations");

            migrationBuilder.RenameTable(
                name: "Rimses",
                newName: "Felgen");

            migrationBuilder.RenameTable(
                name: "Paints",
                newName: "Lacke");

            migrationBuilder.RenameTable(
                name: "OptionalEquipments",
                newName: "Extras");

            migrationBuilder.RenameTable(
                name: "Engines",
                newName: "Motoren");

            migrationBuilder.RenameIndex(
                name: "IX_OptionalEquipments_CarConfigurationId",
                table: "Extras",
                newName: "IX_Extras_CarConfigurationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Felgen",
                table: "Felgen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lacke",
                table: "Lacke",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Extras",
                table: "Extras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motoren",
                table: "Motoren",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Felgen_RimsId",
                table: "Configurations",
                column: "RimsId",
                principalTable: "Felgen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Lacke_PaintId",
                table: "Configurations",
                column: "PaintId",
                principalTable: "Lacke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_Motoren_EngineId",
                table: "Configurations",
                column: "EngineId",
                principalTable: "Motoren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Configurations_CarConfigurationId",
                table: "Extras",
                column: "CarConfigurationId",
                principalTable: "Configurations",
                principalColumn: "Id");
        }
    }
}
