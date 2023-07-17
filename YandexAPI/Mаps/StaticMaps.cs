using System;
using System.Drawing;
using System.IO;
using System.Net;
using YandexAPI.Enums;
using YandexAPI.Mаps.Interfaces;

namespace YandexAPI.Mаps
{
    /// <summary>Формирует изображение карты в соответствии со значениями параметров, передаваемых сервису в URL </summary>
    internal class StaticMaps : IStaticMaps
    {
        
        public string GetUrlMapImage(TypeMapEnum type, double Latitude, double Longitude, int zPosition, int width, int height)
        {
            GeoPoint point = new GeoPoint(Latitude,Longitude);
            return GetUrlMapImage(type, point, zPosition, width, height);
        }

        public string GetUrlMapImage(TypeMapEnum type, GeoPoint CentrPoint, int zPosition, int width, int height)
        {
            if (zPosition < 0 || zPosition > 17)
                throw new ArgumentOutOfRangeException("Уровень масштабирования. Может быть от 1 до 17");

            if (width < 1 || width > 650)
                throw new ArgumentOutOfRangeException("Ширина. Может быть от 1 до 650");

            if (height < 1 || height > 450)
                throw new ArgumentOutOfRangeException("Высота. Может быть от 1 до 450");

            return String.Format("https://static-maps.yandex.ru/1.x/?ll={0}&size={1},{2}&z={3}&l={4}&pt={0},pm2rdm",
              CentrPoint.ToString(),
              width,
              height,
              zPosition,
              type.ToString().ToLower());
        }


        /// <summary>
        /// Метод для скачивания Image из интернета
        /// </summary>
        /// <param name="URL">URL скачиваемой Image</param>
        /// <param name="Proxy">Передаем Proxy для подключения</param>
        /// <returns>Возвращаем объект Image</returns>
        public Bitmap DownloadMapImage(string Url, WebProxy Proxy=null)
        {
            Bitmap tmpImage =null;

            // Открываем соединение
            HttpWebRequest HttpWebRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(Url);

            if (Proxy != null)
                HttpWebRequest.Proxy = Proxy;   

            HttpWebRequest.AllowWriteStreamBuffering = true;

            // Вы также можете указать дополнительные значения заголовка, такие как пользовательский агент или референт: (необязательно)
            HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
            HttpWebRequest.Referer = "http://www.google.com/";

            //установить тайм-аут на 20 секунд (необязательно)
            HttpWebRequest.Timeout = 20000;

            // Ответ на запрос:
            using (WebResponse WebResponse = HttpWebRequest.GetResponse())
            {
                // Открыть поток данных:
                using (Stream WebStream = WebResponse.GetResponseStream())
                {
                    // преобразовать веб-поток в изображение
                    tmpImage = (Bitmap)Bitmap.FromStream(WebStream);
                }
            }
            return tmpImage;
        }
    }
}
