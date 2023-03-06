// See https://aka.ms/new-console-template for more information

using Airports.Data;
using Airports.Data.Models;

Console.Title = "MyProg";

string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";
string fileCountries = "countries.csv";
string fileRegions = "regions.csv";
string fileAirports = "airports.csv";
string fileAirportFrequencies = "airport-frequencies.csv";
string fileNavaids = "navaids.csv";
string fileRunways = "runways.csv";

ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
var files = readAirports.ReadZip();
Console.WriteLine(readAirports.IsFile(" "));
Console.WriteLine(readAirports.IsFile("regions.csv"));
Console.WriteLine();
foreach (var item in files)
{
    Console.WriteLine(item.Name);
}


