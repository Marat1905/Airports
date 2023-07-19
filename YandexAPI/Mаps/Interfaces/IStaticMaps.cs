using System.Collections.Generic;
using System.Drawing;
using System.Net;
using YandexAPI.Enums;

namespace YandexAPI.Mаps.Interfaces
{
    public interface IStaticMaps
    {

        /// <summary>Возвращает URL на статический рисунок карты с точкой поиска в центре </summary>
        /// <param name="type">Слои и типы карт</param>
        /// <param name="Latitude">Широта</param>
        /// <param name="Longitude">Долгота</param>
        /// <param name="zPosition">Уровень масштабирования. Может быть от 1 до 17. Если выбран 0 то без маштабирования</param>
        /// <param name="width">Ширина. Может быть от 1 до 650</param>
        /// <param name="height">Высота. Может быть от 1 до 450</param>
        /// <param name="marker">Маркер должен иметь вид {долгота},{широта},{стиль}{цвет}{размер}{контент}</param>
        /// <returns>Url на Image</returns>
        string GetUrlMapImage(TypeMapEnum type, double Latitude, double Longitude, int width, int height, string marker, int zPosition);

        /// <summary>Возвращает URL на статический рисунок карты с точкой поиска в центре </summary>
        /// <param name="type">Слои и типы карт</param>
        /// <param name="CentrPoint">Географические координаты</param>
        /// <param name="zPosition">Уровень масштабирования. Может быть от 1 до 17</param>
        /// <param name="width">Ширина. Может быть от 1 до 650</param>
        /// <param name="height">Высота. Может быть от 1 до 450</param>
        /// <param name="marker">Маркер должен иметь вид {долгота},{широта},{стиль}{цвет}{размер}{контент}</param>
        /// <returns>Url на Image</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        string GetUrlMapImage(TypeMapEnum type, GeoPoint CentrPoint, int width, int height, string marker, int zPosition);

        /// <summary> Для сбора метки </summary>
        /// <param name="point">Координаты метки </param>
        /// <param name="styleMarker">Стиль метки</param>
        /// <param name="sizeMarker">Размер метки</param>
        /// <param name="colorMarker">Цвет метки</param>
        /// <param name="contentMarker">Контент метки</param>
        /// <returns>Возвращаем в текстовом виде</returns>
        string MarkerSplit(GeoPoint point, StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, string contentMarker);

        /// <summary> Для сбора метки </summary>
        /// <param name="points">Коллекция координат меток</param>
        /// <param name="SetPoint">Выбранная метка</param>
        /// <param name="styleMarker">Стиль метки</param>
        /// <param name="sizeMarker">Размер метки</param>
        /// <param name="colorMarker">Цвет метки</param>
        /// <param name="setColorMarker">Цвет выбранной метки</param>
        /// <returns>Возвращаем в текстовом виде</returns>
        string MarkerSplits(IEnumerable<GeoPoint> points, GeoPoint SetPoint, StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, ColorMarker setColorMarker);

        /// <summary> Для сбора метки </summary>
        /// <param name="Latitude">Широта</param>
        /// <param name="Longitude">Долгота</param>
        /// <param name="styleMarker">Стиль метки</param>
        /// <param name="sizeMarker">Размер метки</param>
        /// <param name="colorMarker">Цвет метки</param>
        /// <param name="contentMarker">Контент метки</param>
        /// <returns>Возвращаем в текстовом виде</returns>
        string MarkerSplit(double Latitude, double Longitude, StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, string contentMarker);

       

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="URL">URL скачиваемой Image</param>
        /// <param name="Proxy">Передаем Proxy для подключения</param>
        /// <returns>Возвращаем объект Image</returns>
        Bitmap DownloadMapImage(string Url, WebProxy Proxy = null);

    }
}
