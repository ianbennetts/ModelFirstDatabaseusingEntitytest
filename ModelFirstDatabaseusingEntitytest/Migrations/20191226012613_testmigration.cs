using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelFirstDatabaseusingEntitytest.Migrations
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parm1 = table.Column<string>(maxLength: 100, nullable: true),
                    Parm2 = table.Column<string>(maxLength: 100, nullable: true),
                    Parm3 = table.Column<string>(maxLength: 100, nullable: true),
                    API = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfSpaces = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteArea",
                columns: table => new
                {
                    SiteId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteArea", x => new { x.SiteId, x.AreaId });
                    table.ForeignKey(
                        name: "FK_SiteArea_ParkingAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "ParkingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteArea_ParkingSite_SiteId",
                        column: x => x.SiteId,
                        principalTable: "ParkingSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteArea_AreaId",
                table: "SiteArea",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteArea");

            migrationBuilder.DropTable(
                name: "ParkingAreas");

            migrationBuilder.DropTable(
                name: "ParkingSite");
        }
    }
}
