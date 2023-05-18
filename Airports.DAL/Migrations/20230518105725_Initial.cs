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
                name: "AirportFrequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportRef = table.Column<int>(type: "int", nullable: false),
                    AirportIdent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencyMhz = table.Column<double>(type: "float", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportFrequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    ElevationFt = table.Column<int>(type: "int", nullable: true),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsoRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    WikipediaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Navaids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ident = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FrequencyKhz = table.Column<int>(type: "int", nullable: true),
                    LatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    ElevationFt = table.Column<int>(type: "int", nullable: true),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DmeFrequencyKhz = table.Column<int>(type: "int", nullable: true),
                    DmeChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DmeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    DmeLongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    DmeElevationFt = table.Column<int>(type: "int", nullable: true),
                    SlavedVariationDeg = table.Column<double>(type: "float", nullable: true),
                    MagneticVariationDeg = table.Column<double>(type: "float", nullable: true),
                    UsageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociatedAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navaids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Continent = table.Column<int>(type: "int", nullable: false),
                    IsoCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WikipediaLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Runways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportRef = table.Column<int>(type: "int", nullable: false),
                    AirportIdent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthFt = table.Column<int>(type: "int", nullable: true),
                    WidthFt = table.Column<int>(type: "int", nullable: true),
                    Surface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lighted = table.Column<int>(type: "int", nullable: true),
                    Closed = table.Column<int>(type: "int", nullable: true),
                    LeIdent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LeLongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    LeElevationFt = table.Column<int>(type: "int", nullable: true),
                    LeHeadingDegT = table.Column<double>(type: "float", nullable: true),
                    LeDisplacedThresholdFt = table.Column<int>(type: "int", nullable: true),
                    HeIdent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeLatitudeDeg = table.Column<double>(type: "float", nullable: true),
                    HeLongitudeDeg = table.Column<double>(type: "float", nullable: true),
                    HeElevationFt = table.Column<int>(type: "int", nullable: true),
                    HeHeadingDegT = table.Column<double>(type: "float", nullable: true),
                    HeDisplacedThresholdFt = table.Column<int>(type: "int", nullable: true),
                    Identificator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runways", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportFrequences");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Navaids");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Runways");
        }
    }
}
