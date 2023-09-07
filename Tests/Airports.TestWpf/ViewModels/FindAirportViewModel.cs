using Airports.DAL.Entityes;
using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Infrastructure.Extensions;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using YandexAPI.Enums;
using YandexAPI.Mаps;
using YandexAPI.Mаps.Interfaces;

namespace Airports.TestWpf.ViewModels
{
    internal class FindAirportViewModel:ViewModel
    {
        #region Поля
        private readonly IFindAirportsService _FindAirports;
        private readonly IStaticMaps _StaticMaps;
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
        public AirportDBModel AirportDBSearchNearest 
        { 
            get => _AirportDBSearchNearest;
            set
            {
                Set(ref _AirportDBSearchNearest, value);
                AirportDBMaps = AirportDBSearchNearest;
            } 
        }

        #endregion

        #region IEnumerable<AirportDBModel> : AirportDBModel - Модель поиска аэропортов по радиусу

        /// <summary>Модель поиска аэропортов по радиусу</summary>
        private IEnumerable<AirportDBModel>? _AirportDBSearchRadius;

        /// <summary>Модель поиска аэропортов по радиусу </summary>
        public IEnumerable<AirportDBModel>? AirportDBSearchRadius { get => _AirportDBSearchRadius; set => Set(ref _AirportDBSearchRadius, value); }

        #endregion

        #region SelectedAirportDB : AirportDBModel - Выбранный аэропорт из списка

        /// <summary>Выбранный аэропорт из списка</summary>
        private AirportDBModel? _SelectedAirportDB;

        /// <summary>Выбранный аэропорт из списка</summary>
        public AirportDBModel? SelectedAirportDB 
        { 
            get => _SelectedAirportDB; 
            set 
            {
                Set(ref _SelectedAirportDB, value);
               AirportDBMaps = SelectedAirportDB;
            }  
        }

        #region AirportDBMaps : AirportDBModel - Модель показа на карте

        /// <summary>Модель поиска ближайшего аэропорта </summary>
        private AirportDBModel _AirportDBMaps;

        /// <summary>Модель поиска ближайшего аэропорта </summary>
        public AirportDBModel AirportDBMaps
        { 
            get => _AirportDBMaps;
            set 
            {
                Set(ref _AirportDBMaps, value);
                if (SelectSearch == 1)
                    UpdateSelectMap(AirportDBMaps);
                else
                    UpdateSelectMaps(AirportDBSearchRadius, AirportDBMaps, PosinionScroll);
            } 
        }

        #endregion
        #endregion

        #region PosinionScroll : int - Положение ползунка

        /// <summary>Положение ползунка</summary>
        private int _PosinionScroll=10;

        /// <summary>Положение ползунка</summary>
        public int PosinionScroll
        {
            get => _PosinionScroll;
            set
            {
                Set(ref _PosinionScroll, value);
                if(SelectSearch == 1)
                    UpdateSelectMap(AirportDBMaps, PosinionScroll);
                else
                    UpdateSelectMaps(AirportDBSearchRadius, SelectedAirportDB, PosinionScroll);
            }
        }

        /// <summary>Вспомогательное свойство</summary>
        public int SelectSearch { get; set; }

        #endregion

        #region ImageSelectMap : BitmapSource - Карта полученная с Яндекса

        /// <summary>Карта полученная с Яндекса</summary>
        private BitmapSource _ImageSelectMap;

        /// <summary>Карта полученная с Яндекса</summary>
        public BitmapSource ImageSelectMap { get => _ImageSelectMap; set => Set(ref _ImageSelectMap, value); }

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
            SelectSearch = 1;
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
        private async void OnSearchRadiusCommandCommandExecuted(object p)
        {
            SelectSearch = 2;
            
            AirportDBSearchRadius=null;
            //AirportDBSearchRadius = _FindAirports.FindAirportsRadius(PointSearchRadius, Radius);
            //AirportDBSearchRadius = _FindAirports.FindAirportsRadiusSql(PointSearchRadius, Radius);
            AirportDBSearchRadius  = await Task.Run( async() => await _FindAirports.FindAirportsRadiusSqlAsync(PointSearchRadius, Radius).ConfigureAwait(false));
            if (AirportDBSearchRadius!=null)
            {
                SelectedAirportDB =  AirportDBSearchRadius.FirstOrDefault();
            }
        }

        #endregion

        #endregion

      

        #region Конструктор
        public FindAirportViewModel(IFindAirportsService findAirports, IStaticMaps staticMaps)
        {
            _FindAirports = findAirports;
            _StaticMaps = staticMaps;
            PointSearchNearest =new GeoPoint(0,0);
            PointSearchRadius = new GeoPoint(0, 0);
        }
        #endregion

        #region Методы
        /// <summary>Обновление карты </summary>
        /// <param name="airport">Объект аэропорта</param>
        /// <param name="position">Уровень масштабирования</param>
        private void UpdateSelectMap(AirportDBModel airport ,int position=10)
        {
            if(airport != null)
            {
                var point = new GeoPoint((double)airport.LatitudeDeg, (double)airport.LongitudeDeg);
                string Marker = _StaticMaps.MarkerSplit(point, StyleMarker.pm2,SizeMarker.l,ColorMarker.rd,"1");


                ImageSelectMap = BitmapConversion.BitmapToBitmapSource(_StaticMaps.DownloadMapImage(_StaticMaps.GetUrlMapImage(TypeMapEnum.Map,
                                                                                                                         (double)airport.LatitudeDeg,
                                                                                                                         (double)airport.LongitudeDeg,
                                                                                                                         500,
                                                                                                                         450,
                                                                                                                         Marker, position)));

            }        
        }

        /// <summary>Обновление карты </summary>
        /// <param name="airport">Объект аэропорта</param>
        /// <param name="position">Уровень масштабирования</param>
        private void UpdateSelectMaps(IEnumerable<AirportDBModel>? Airports,AirportDBModel? selectAirport, int position = 0)
        {
            if (selectAirport != null && Airports!=null)
            {
                var selectPoint = new GeoPoint((double)selectAirport.LatitudeDeg, (double)selectAirport.LongitudeDeg);
                List<GeoPoint> points = new List<GeoPoint>();

                foreach (var airport in Airports)
                {
                    var point = new GeoPoint((double)airport.LatitudeDeg, (double)airport.LongitudeDeg);
                    points.Add(point);
                }

                string marker = _StaticMaps.MarkerSplits(points, selectPoint, StyleMarker.pm2, SizeMarker.l, ColorMarker.bl, ColorMarker.rd);

                ImageSelectMap = BitmapConversion.BitmapToBitmapSource(_StaticMaps.DownloadMapImage(_StaticMaps.GetUrlMapImage(TypeMapEnum.Map,
                                                                                                                          selectPoint, 500,450,marker, position)));
            }
        }
        #endregion
    }
}
