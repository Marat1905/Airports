using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airports.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    WikipediaLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.UniqueConstraint("AK_Countries_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikipediaLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.UniqueConstraint("AK_Regions_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ident = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatitudeDeg = table.Column<decimal>(type: "decimal(25,16)", precision: 25, scale: 16, nullable: true),
                    LongitudeDeg = table.Column<decimal>(type: "decimal(25,16)", precision: 25, scale: 16, nullable: true),
                    ElevationFt = table.Column<int>(type: "int", nullable: true),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    IsoCountry = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsoRegion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Municipality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GpsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IataCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikipediaLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.UniqueConstraint("AK_Airports_Ident", x => x.Ident);
                    table.ForeignKey(
                        name: "FK_Airports_Countries_IsoCountry",
                        column: x => x.IsoCountry,
                        principalTable: "Countries",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Airports_Regions_IsoRegion",
                        column: x => x.IsoRegion,
                        principalTable: "Regions",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "AirportFrequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportRef = table.Column<int>(type: "int", nullable: false),
                    AirportIdent = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyMhz = table.Column<double>(type: "float", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportFrequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportFrequences_Airports_AirportIdent",
                        column: x => x.AirportIdent,
                        principalTable: "Airports",
                        principalColumn: "Ident");
                });

            migrationBuilder.CreateTable(
                name: "Navaids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FrequencyKhz = table.Column<int>(type: "int", nullable: true),
                    LatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    ElevationFt = table.Column<int>(type: "int", nullable: true),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DmeFrequencyKhz = table.Column<int>(type: "int", nullable: true),
                    DmeChannel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DmeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    DmeLongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    DmeElevationFt = table.Column<int>(type: "int", nullable: true),
                    SlavedVariationDeg = table.Column<double>(type: "float", nullable: true),
                    MagneticVariationDeg = table.Column<double>(type: "float", nullable: true),
                    UsageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociatedAirport = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navaids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navaids_Airports_AssociatedAirport",
                        column: x => x.AssociatedAirport,
                        principalTable: "Airports",
                        principalColumn: "Ident");
                });

            migrationBuilder.CreateTable(
                name: "Runways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportRef = table.Column<int>(type: "int", nullable: false),
                    AirportIdent = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LengthFt = table.Column<int>(type: "int", nullable: true),
                    WidthFt = table.Column<int>(type: "int", nullable: true),
                    Surface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lighted = table.Column<int>(type: "int", nullable: true),
                    Closed = table.Column<int>(type: "int", nullable: true),
                    LeIdent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LeLongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LeElevationFt = table.Column<int>(type: "int", nullable: true),
                    LeHeadingDegT = table.Column<double>(type: "float", nullable: true),
                    LeDisplacedThresholdFt = table.Column<int>(type: "int", nullable: true),
                    HeIdent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    HeLongitudeDeg = table.Column<decimal>(type: "decimal(25,16)", precision: 25, scale: 16, nullable: true),
                    HeElevationFt = table.Column<int>(type: "int", nullable: true),
                    HeHeadingDegT = table.Column<double>(type: "float", nullable: true),
                    HeDisplacedThresholdFt = table.Column<int>(type: "int", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runways", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runways_Airports_AirportIdent",
                        column: x => x.AirportIdent,
                        principalTable: "Airports",
                        principalColumn: "Ident");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportFrequences_AirportIdent",
                table: "AirportFrequences",
                column: "AirportIdent");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_IsoCountry",
                table: "Airports",
                column: "IsoCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_IsoRegion",
                table: "Airports",
                column: "IsoRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Navaids_AssociatedAirport",
                table: "Navaids",
                column: "AssociatedAirport");

            migrationBuilder.CreateIndex(
                name: "IX_Runways_AirportIdent",
                table: "Runways",
                column: "AirportIdent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportFrequences");

            migrationBuilder.DropTable(
                name: "Navaids");

            migrationBuilder.DropTable(
                name: "Runways");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
