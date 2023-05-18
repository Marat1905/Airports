using Airports.Data.Models;
using Airports.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO.Compression;
using System.Text;
using TestConsole;
using Airports.DAL.Entityes;
using Airports.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Airports.DAL.Extensions;
using TestConsole.Data;

namespace Airports.DataTests
{
    [TestClass()]
    public class EntityAirportsTest
    {
        string zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Tests\\TestConsole\\Airports.zip");
        //string zipPath = @"C:\Users\Marat\Downloads\Airports.zip";
        private static IHost __Host;
        private IServiceProvider Services;

        [TestInitialize]
        public  void Initialize()
        {
            // _services = Program.CreateHostBuilder(new string[] { }).Build().Services; // one line
            IHost Host = __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

            Services = Host.Services;
            using (var scope = Services.CreateScope())
            {
                 scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            }
        }

        [TestMethod()]
        public void ReadAirportsEntity()
        {
            //Arrange
            IRepository<AirportDBModel>? repositoryAirport = Services.CreateScope().ServiceProvider.GetService<IRepository<AirportDBModel>>();
            string fileAirports = "airports.csv"; ;
            List<string> Expecteds = new List<string>();
            ReadAirportsCsv readAirports = new ReadAirportsCsv(zipPath);
           
            // Act
            foreach (var item in ReadCsv(zipPath, fileAirports))
            {
                Expecteds.Add(item);
            }
            repositoryAirport!.AutoSaveChanges = false;
            foreach (var item in readAirports.GetCsv<AirportInfo>(fileAirports))
            {
                repositoryAirport?.Add(item.ModelMap<AirportInfo, AirportDBModel>());
            }
            repositoryAirport.SaveAs();
            //Assert
            Assert.AreEqual(Expecteds.Count, repositoryAirport?.Items.Count());
            
            for (int i = 0; i < Expecteds.Count; i++)
            {
                // Удаляем кавычки потому-что не у всех есть они.
                var expected = Expecteds[i].Replace("\"", "");
                var actual = ReadAirportsCsv.ToCsvFields<AirportInfo>(repositoryAirport!.Get(i + 1).ModelMapInfo<AirportDBModel, AirportInfo>());
                Assert.AreEqual(expected, actual);
            }
        }




        public static IEnumerable<string> ReadCsv(string zipPath, string fileName, string separator = ",")
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                var sample = archive.GetEntry(fileName);
                if (sample != null)
                {
                    using (var zipEntryStream = sample.Open())
                    {
                        using (StreamReader reader = new StreamReader(zipEntryStream, Encoding.Default))
                        {
                            var lines = reader.ReadLine();
                            while (!reader.EndOfStream)
                            {
                                yield return reader.ReadLine();
                            }

                        }
                    }
                }
            }
        }
    }
}
