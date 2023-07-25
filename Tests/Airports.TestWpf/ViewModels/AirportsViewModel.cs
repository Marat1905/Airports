using Airports.DAL.Entityes;
using Airports.DAL.Extensions;
using Airports.Data.Models;
using Airports.Data.Service.Interfaces;
using Airports.Interfaces;
using Airports.TestWpf.Data;
using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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
        private readonly IUserDialogService _UserDialog;
        private readonly DbInitializer _DbInit;
        private const string FILE_COUNTRIES = "countries.csv";
        private const string FILE_REGIONS = "regions.csv";
        private const string FILE_AIRPORTS = "airports.csv";
        private const string FILE_AIRPORT_FREQUENCIES = "airport-frequencies.csv";
        private const string FILE_NAVAIDS = "navaids.csv";
        private const string FILE_RUNWAYS = "runways.csv";
        //источник токена отмены
        private CancellationTokenSource _TokenSource;
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

        #region ProgressLoad : ProgressLoadViewModel - Модель окна прогресс бара

        /// <summary>Модель окна прогресс бара</summary>
        private ProgressLoadViewModel _ProgressLoad;

        /// <summary>Модель окна прогресс бара</summary>
        public ProgressLoadViewModel ProgressLoad { get => _ProgressLoad; set => Set(ref _ProgressLoad, value); }

        #endregion

        #endregion

        #region Команды

        #region Command OpenProgressCommand - Создание нового студента

        /// <summary>Создание нового студента</summary>
        private ICommand _OpenProgressCommand;

        /// <summary>Создание нового студента</summary>
        public ICommand OpenProgressCommand => _OpenProgressCommand
            ??= new LambdaCommand(OnOpenProgressCommandExecuted, CanOpenProgressCommandExecute);

        /// <summary>Проверка возможности выполнения - Создание нового студента</summary>
        private static bool CanOpenProgressCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Создание нового студента</summary>
        private void OnOpenProgressCommandExecuted(object p)
        {
            //готовим токен отмены
            _TokenSource = new CancellationTokenSource();
            CancellationToken cancelToken = _TokenSource.Token;
            ProgressLoad = new ProgressLoadViewModel(_UserDialog, _TokenSource);
            Task.Run(() => Start(cancelToken));
            _UserDialog.Open(ProgressLoad);
           
        }

        #endregion



        #endregion

        #region Конструкторы

        public AirportsViewModel(IRepository<AirportDBModel> airportDB,
           IRepository<RegionDBModel> regionDB,
           IRepository<CountryDBModel> countryDB,
           IRepository<AirportFrequenceDBModel> airportFrequenceDB,
           IRepository<NavaidDBModel> navaidDB,
           IRepository<RunwayDBModel> runwayDB,
           IReadAirportsCsvService readAirportsCsv,
           IFindAirportsService findAirportsService ,
           IUserDialogService UserDialog,
           DbInitializer dbInit
          )
        {
            _AirportDB = airportDB;
            _RegionDB = regionDB;
            _CountryDB = countryDB;
            _AirportFrequenceDB = airportFrequenceDB;
            _NavaidDB = navaidDB;
            _RunwayDB = runwayDB;
            _ReadAirportsCsv = readAirportsCsv;
            _UserDialog = UserDialog;
            _DbInit = dbInit;
        }
        #endregion
  
        private async Task Start(CancellationToken Cancel = default)
        {
            AirportsDBModel= Enumerable.Empty<AirportDBModel>();
            await _DbInit.InitializeAsync();
          
            if (_AirportDB.Items.Count() != 0)
            {
                //await _AirportDB.ClearAsync(Cancel);
                //await _CountryDB.ClearAsync(Cancel);
                //await _NavaidDB.ClearAsync(Cancel);
                //await _RunwayDB.ClearAsync(Cancel);
                //await _RegionDB.ClearAsync(Cancel);
                //await _AirportFrequenceDB.ClearAsync(Cancel);
            }
            await Load(Cancel);
           
            _UserDialog.Close(ProgressLoad);
            AirportsDBModel = _AirportDB.Items.ToArray();
        }

        private async Task Load(CancellationToken Cancel = default)
        {
            var timer = Stopwatch.StartNew();

            await ReadCsvWriteSql<RegionInfo, RegionDBModel>(_ReadAirportsCsv, _RegionDB, FILE_REGIONS,Cancel).ConfigureAwait(false);
            await ReadCsvWriteSql<CountryInfo, CountryDBModel>(_ReadAirportsCsv, _CountryDB, FILE_COUNTRIES, Cancel).ConfigureAwait(false);
            await ReadCsvWriteSql<AirportInfo, AirportDBModel>(_ReadAirportsCsv, _AirportDB, FILE_AIRPORTS, Cancel).ConfigureAwait(false);
            await ReadCsvWriteSql<AirportFrequenceInfo, AirportFrequenceDBModel>(_ReadAirportsCsv, _AirportFrequenceDB, FILE_AIRPORT_FREQUENCIES, Cancel).ConfigureAwait(false);
            await ReadCsvWriteSql<NavaidInfo, NavaidDBModel>(_ReadAirportsCsv, _NavaidDB, FILE_NAVAIDS, Cancel).ConfigureAwait(false);
            await ReadCsvWriteSql<RunwayInfo, RunwayDBModel>(_ReadAirportsCsv, _RunwayDB, FILE_RUNWAYS, Cancel).ConfigureAwait(false);
            Debug.WriteLine("Writing completed at {0}", timer.Elapsed);

        }
        
        async Task ReadCsvWriteSql<Tinfo, TDbModel>(IReadAirportsCsvService info, IRepository<TDbModel> model,string files, CancellationToken Cancel = default) where Tinfo : class,new()
                                                                                                                            where TDbModel : class,IEntity,new()
        {
            model.AutoSaveChanges = false;
            foreach (var item in info.GetCsv<Tinfo>(files))
            {
                if (Cancel.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                {
                    Debug.WriteLine("Операция прервана");
                    break;     //  выходим из метода и тем самым завершаем задачу
                }
                // model?.Add(item.ModelMap<Tinfo, TDbModel>());
                await model.AddAsync(item.ModelMap<Tinfo, TDbModel>(), Cancel);
            }
            if (!model.AutoSaveChanges)
              await  model.SaveAsAsync(Cancel).ConfigureAwait(false);
        }

       
    }
}
