// See https://aka.ms/new-console-template for more information

using Airports.Data;
using Airports.Data.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;

Console.Title = "MyProg";
string exePath = AppDomain.CurrentDomain.BaseDirectory;
string zipPath = Path.Combine(exePath, "..\\..\\..\\Airports.zip");
//string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";

string fileCountries = "countries.csv";
string fileRegions = "regions.csv";
string fileAirports = "airports.csv";
string fileAirportFrequencies = "airport-frequencies.csv";
string fileNavaids = "navaids.csv";
string fileRunways = "runways.csv";


Stopwatch stopwatch = new Stopwatch();
List<RegionInfo> regions = new List<RegionInfo>();
List<CountryInfo> countries = new List<CountryInfo>();
List<AirportInfo> airpots = new List<AirportInfo>();
List<AirportFrequenceInfo> airportFrequencies = new List<AirportFrequenceInfo>();
List<NavaidInfo> airportNavaids = new List<NavaidInfo>();
List<RunwayInfo> airportRunways = new List<RunwayInfo>();


//ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
//var files = readAirports.ReadZip();
//Console.WriteLine(readAirports.IsFile(" "));
//Console.WriteLine(readAirports.IsFile("regions.csv"));
//Console.WriteLine();
//foreach (var item in files)
//{
//    Console.WriteLine(item.Name);
//}

Console.Write("Нажмите Enter чтоб продолжить");
Console.ReadLine();
stopwatch.Start();
ReadAirportsCsv readRunways = new ReadAirportsCsv(zipPath);
var files = readRunways.ReadZip();


foreach (var item in readRunways.GetCsv<RunwayInfo>(files.Where(x => x.Name == fileRunways).FirstOrDefault()))
{
    airportRunways.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(airportRunways, stopwatch);

Console.ReadLine();


stopwatch.Reset();
stopwatch.Start();
ReadAirportsCsv readNavaids = new ReadAirportsCsv(zipPath);

foreach (var item in readNavaids.GetCsv<NavaidInfo>(fileNavaids))
{
    airportNavaids.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(airportNavaids, stopwatch);

Console.ReadLine();

stopwatch.Reset();
stopwatch.Start();
ReadAirportsCsv readAirportFrequencies = new ReadAirportsCsv(zipPath);
foreach (var item in readAirportFrequencies.GetCsv<AirportFrequenceInfo>(fileAirportFrequencies))
{
    airportFrequencies.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(airportFrequencies, stopwatch);

Console.ReadLine();

stopwatch.Reset();
stopwatch.Start();
ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
foreach (var item in readAirports.GetCsv<AirportInfo>(fileAirports))
{
    airpots.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(airpots, stopwatch);

Console.ReadLine();



stopwatch.Reset();
stopwatch.Start();
ReadAirportsCsv readRegions = new ReadAirportsCsv(zipPath);
foreach (var item in readRegions.GetCsv<RegionInfo>(fileRegions))
{
    regions.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(regions, stopwatch);
Console.ReadLine();

stopwatch.Reset();
stopwatch.Start();
ReadAirportsCsv readCountries = new ReadAirportsCsv(zipPath);
foreach (var item in readCountries.GetCsv<CountryInfo>(fileCountries))
{
    countries.Add(item);
    Console.WriteLine(item);
}
stopwatch.Stop();
ConsoleWrite(countries, stopwatch);


Console.ReadLine();

static void ConsoleWrite<T>(List<T> newList, Stopwatch stopwatch)
{
    TimeSpan timeTaken = stopwatch.Elapsed;
    string foo = "Время выполнения: " + timeTaken.ToString(@"m\:ss\.fff");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Всего записей {newList.Count}: {foo}");
    Console.ResetColor();
}


//using Airports.DAL.Entityes;
//using Airports.Data;
//using Airports.Interfaces;
//using Airports.Lib.Enums;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Reflection.Emit;
//using System.Reflection.Metadata;
//using TestConsole.Data;

//internal class Program
//{
//    private static IHost __Host;
//    private static async Task Main(string[] args)
//    {
//        Console.Title = "MyProg";
//        string exePath = AppDomain.CurrentDomain.BaseDirectory;
//        string zipPath = Path.Combine(exePath, "..\\..\\..\\Airports.zip");
//        //string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";

//        string fileCountries = "countries.csv";
//        string fileRegions = "regions.csv";
//        string fileAirports = "airports.csv";
//        string fileAirportFrequencies = "airport-frequencies.csv";
//        string fileNavaids = "navaids.csv";
//        string fileRunways = "runways.csv";

//        Stopwatch stopwatch = new Stopwatch();

//        IHost Host = __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


//        IServiceProvider Services = Host.Services;


//        using (var scope = Services.CreateScope())
//        {
//           await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();
//        }


//        IRepository<Airport>? repositoryAirport= Services.CreateScope().ServiceProvider.GetService<IRepository<Airport>>();

//        Airport air = new Airport { Id= 6523, Ident= "00A", Type= TypeAirport.Heliport, Name="Total Rf Heliport", LatitudeDeg= 40.07080078125m, LongitudeDeg= - 74.93360137939453, ElevationFt= 11, Continent= ContinentCode.NorthAmerica, IsoCountry= "US", IsoRegion= "US-PA", Municipality= "Bensalem", ScheduledService= "no", GpsCode= "00A", LocalCode= "00A" };



//        Console.Write("Нажмите Enter чтоб продолжить");
//        Console.ReadLine();
//        stopwatch.Start();
//        ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
//        List<Airports.Data.Models.AirportInfo> airpots = new List<Airports.Data.Models.AirportInfo>();
//        foreach (var item in readAirports.GetCsv<Airports.Data.Models.AirportInfo>(fileAirports))
//        {
//           // repositoryAirport?.Add(item);
//            airpots.Add(item);
//            Console.WriteLine(item);
//        }
//        stopwatch.Stop();
//        ConsoleWrite(airpots, stopwatch);

//        Console.ReadLine();


//    }

//    static void ConsoleWrite<T>(List<T> newList, Stopwatch stopwatch)
//    {
//        TimeSpan timeTaken = stopwatch.Elapsed;
//        string foo = "Время выполнения: " + timeTaken.ToString(@"m\:ss\.fff");
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine($"Всего записей {newList.Count}: {foo}");
//        Console.ResetColor();
//    }

//    static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
//            .AddDatabase(host.Configuration.GetSection("Database"))
//   ;

//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//       Host.CreateDefaultBuilder(args)
//           .ConfigureServices(ConfigureServices);
//}