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
        /// <param name="zPosition">Уровень масштабирования. Может быть от 1 до 17</param>
        /// <param name="width">Ширина. Может быть от 1 до 650</param>
        /// <param name="height">Высота. Может быть от 1 до 450</param>
        /// <returns>Url на Image</returns>
        string GetUrlMapImage(TypeMapEnum type, double Latitude, double Longitude, int zPosition, int width, int height);

        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="URL">URL скачиваемой Image</param>
        /// <param name="Proxy">Передаем Proxy для подключения</param>
        /// <returns>Возвращаем объект Image</returns>
        Bitmap DownloadMapImage(string Url, WebProxy Proxy = null);

    }
}
