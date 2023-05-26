using Airports.DAL.Entityes;
using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Models;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace Airports.TestWpf.ViewModels
{
    internal class FindAirportViewModel:ViewModel
    {
        #region Поля
        private readonly IFindAirportsService _FindAirports;
        #endregion

        #region Свойства      

        #region PointSearchNearest : GeoPoint - Координата для поиска ближайшего аэропорта

        /// <summary>Координата для поиска ближайшего аэропорта</summary>
        private GeoPoint _PointSearchNearest;

        /// <summary>Координата для поиска ближайшего аэропорта</summary>
        public GeoPoint PointSearchNearest { get => _PointSearchNearest; set => Set(ref _PointSearchNearest, value); }

        #endregion

        #region PointSearchRadius : GeoPoint - Координата для поиска по радиусу 

        /// <summary>Координата для поиска по радиусу </summary>
        private GeoPoint _PointSearchRadius;

        /// <summary>Координата для поиска по радиусу </summary>
        public GeoPoint PointSearchRadius { get => _PointSearchRadius; set => Set(ref _PointSearchRadius, value); }

        #endregion

        #region Radius : int - Радиус поиска 

        /// <summary>Радиус поиска </summary>
        private int _Radius;

        /// <summary>Радиус поиска </summary>
        public int Radius { get => _Radius; set => Set(ref _Radius, value); }

        #endregion

        #region AirportDBSearchNearest : AirportDBModel - Модель поиска ближайшего аэропорта

        /// <summary>Модель поиска ближайшего аэропорта </summary>
        private AirportDBModel _AirportDBSearchNearest;

        /// <summary>Модель поиска ближайшего аэропорта </summary>
        public AirportDBModel AirportDBSearchNearest { get => _AirportDBSearchNearest; set => Set(ref _AirportDBSearchNearest, value); }

        #endregion

        #region IEnumerable<AirportDBModel> : AirportDBModel - Модель поиска аэропортов по радиусу

        /// <summary>Модель поиска аэропортов по радиусу</summary>
        private IEnumerable<AirportDBModel> _AirportDBSearchRadius;

        /// <summary>Модель поиска аэропортов по радиусу </summary>
        public IEnumerable<AirportDBModel> AirportDBSearchRadius { get => _AirportDBSearchRadius; set => Set(ref _AirportDBSearchRadius, value); }

        #endregion

        #region SelectedAirportDB : AirportDBModel - Выбранная группа студентов

        /// <summary>Выбранная группа студентов</summary>
        private AirportDBModel _SelectedAirportDB;

        /// <summary>Выбранная группа студентов</summary>
        public AirportDBModel SelectedAirportDB { get => _SelectedAirportDB; set => Set(ref _SelectedAirportDB, value); }

        #endregion

        #endregion

        #region Команды
        #region Command SearchNearestCommand - Поиск ближайшего аэропорта команда

        /// <summary>Поиск ближайшего аэропорта команда</summary>
        private ICommand _SearchNearestCommand;

        /// <summary>Поиск ближайшего аэропорта команда</summary>
        public ICommand SearchNearestCommand => _SearchNearestCommand
            ??= new LambdaCommand(OnSearchNearestCommandExecuted, CanSearchNearestCommandExecute);

        /// <summary>Проверка возможности выполнения - Поиск ближайшего аэропорта команда</summary>
        private bool CanSearchNearestCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Поиск ближайшего аэропорта команда</summary>
        private void OnSearchNearestCommandExecuted(object p)
        {
            AirportDBSearchNearest = _FindAirports.FindТearestAirport(PointSearchNearest);
        }

        #endregion

        #region Command SearchRadiusCommand - Поиск аэропортов радиусе команда

        /// <summary>Поиск аэропортов радиусе команда</summary>
        private ICommand _SearchRadiusCommand;

        /// <summary>Поиск аэропортов радиусе команда</summary>
        public ICommand SearchRadiusCommand => _SearchRadiusCommand
            ??= new LambdaCommand(OnSearchRadiusCommandCommandExecuted, CanSearchRadiusCommandCommandExecute);

        /// <summary>Проверка возможности выполнения - Поиск аэропортов радиусе команда</summary>
        private bool CanSearchRadiusCommandCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Поиск аэропортов радиусе команда</summary>
        private void OnSearchRadiusCommandCommandExecuted(object p)
        {
            AirportDBSearchRadius = _FindAirports.FindAirportsRadius(PointSearchRadius, Radius);
        }

        #endregion

        #endregion

        #region Конструктор
        public FindAirportViewModel(IFindAirportsService findAirports)
        {
            _FindAirports = findAirports;
            PointSearchNearest=new GeoPoint(0,0);
            PointSearchRadius = new GeoPoint(0, 0);
        }
        #endregion
    }
}
