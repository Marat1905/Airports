using Airports.DAL.Entityes;
using Airports.DAL.Extensions;
using Airports.Data.Models;
using Airports.Data.Service.Interfaces;
using Airports.Interfaces;
using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airports.TestWpf.ViewModels
{
    internal class AirportsViewModel:ViewModel
    {
        #region Поля
        private readonly IRepository<AirportDBModel> _AirportDB;
        private readonly IRepository<RegionDBModel> _RegionDB;
        private readonly IRepository<CountryDBModel> _CountryDB;
        private readonly IRepository<AirportFrequenceDBModel> _AirportFrequenceDB;
        private readonly IRepository<NavaidDBModel> _NavaidDB;
        private readonly IRepository<RunwayDBModel> _RunwayDB;
        private readonly IReadAirportsCsvService _ReadAirportsCsv;
        private const string FILE_COUNTRIES = "countries.csv";
        private const string FILE_REGIONS = "regions.csv";
        private const string FILE_AIRPORTS = "airports.csv";
        private const string FILE_AIRPORT_FREQUENCIES = "airport-frequencies.csv";
        private const string FILE_NAVAIDS = "navaids.csv";
        private const string FILE_RUNWAYS = "runways.csv";

        #endregion


        #region Свойства
        #region AirportsDBModel : IEnumerable<AirportsDBModel> - Список аэропортов

        /// <summary>Список аэропортов</summary>
        private IEnumerable<AirportDBModel> _AirportsDBModel;

        /// <summary>Список аэропортов</summary>
        public IEnumerable<AirportDBModel> AirportsDBModel
        {
            get => _AirportsDBModel;
            private set => Set(ref _AirportsDBModel, value);
        }

        #endregion

        #region SelectedAirport : AirportDBModel - Выбранный аэропорт

        /// <summary>Выбранный аэропорт</summary>
        private AirportDBModel _SelectedAirport;

        /// <summary>Выбранный аэропорт</summary>
        public AirportDBModel SelectedAirport { get => _SelectedAirport; set => Set(ref _SelectedAirport, value); }

        #endregion

        #endregion

        #region Команды

        public ICommand ReadCsvToSqlDataCommand { get; }

        private async void OnReadCsvToSqlDataCommandExecuted(object p)
        {
            if (_AirportDB.Items.Count() != 0)
            {
                await _AirportDB.ClearAsync();
                await _CountryDB.ClearAsync();
                await _NavaidDB.ClearAsync();
                await _RunwayDB.ClearAsync();
                await _RegionDB.ClearAsync();
                await _AirportFrequenceDB.ClearAsync();
            }
            await Load();
            AirportsDBModel = _AirportDB.Items.ToArray();
        }

        #endregion

        #region Конструкторы

        public AirportsViewModel(IRepository<AirportDBModel> airportDB,
           IRepository<RegionDBModel> regionDB,
           IRepository<CountryDBModel> countryDB,
           IRepository<AirportFrequenceDBModel> airportFrequenceDB,
           IRepository<NavaidDBModel> navaidDB,
           IRepository<RunwayDBModel> runwayDB,
          IReadAirportsCsvService readAirportsCsv,
          IFindAirportsService findAirportsService   
          )
        {
            _AirportDB = airportDB;
            _RegionDB = regionDB;
            _CountryDB = countryDB;
            _AirportFrequenceDB = airportFrequenceDB;
            _NavaidDB = navaidDB;
            _RunwayDB = runwayDB;
            _ReadAirportsCsv = readAirportsCsv;

           
            ReadCsvToSqlDataCommand = new LambdaCommand(OnReadCsvToSqlDataCommandExecuted);
        }
        #endregion
  
        async Task Load()
        {
            var timer = Stopwatch.StartNew();

            await ReadCsvWriteSql<RegionInfo, RegionDBModel>(_ReadAirportsCsv, _RegionDB, FILE_REGIONS).ConfigureAwait(false);

            await ReadCsvWriteSql<CountryInfo, CountryDBModel>(_ReadAirportsCsv, _CountryDB, FILE_COUNTRIES).ConfigureAwait(false);
            await ReadCsvWriteSql<AirportInfo, AirportDBModel>(_ReadAirportsCsv, _AirportDB, FILE_AIRPORTS).ConfigureAwait(false);
            await ReadCsvWriteSql<AirportFrequenceInfo, AirportFrequenceDBModel>(_ReadAirportsCsv, _AirportFrequenceDB, FILE_AIRPORT_FREQUENCIES).ConfigureAwait(false);
            await ReadCsvWriteSql<NavaidInfo, NavaidDBModel>(_ReadAirportsCsv, _NavaidDB, FILE_NAVAIDS).ConfigureAwait(false);
            await ReadCsvWriteSql<RunwayInfo, RunwayDBModel>(_ReadAirportsCsv, _RunwayDB, FILE_RUNWAYS).ConfigureAwait(false);

            Debug.WriteLine("Writing completed at {0}", timer.Elapsed);

        }
        
        async Task ReadCsvWriteSql<Tinfo, TDbModel>(IReadAirportsCsvService info, IRepository<TDbModel> model,string files) where Tinfo : class,new()
                                                                                                                            where TDbModel : class,IEntity,new()
        {
            model.AutoSaveChanges = false;
            foreach (var item in info.GetCsv<Tinfo>(files))
            {
                model?.Add(item.ModelMap<Tinfo, TDbModel>());
            }
            if (!model.AutoSaveChanges)
              await  model.SaveAsAsync().ConfigureAwait(false);
        }
    }
}
