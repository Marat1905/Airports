using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using YandexAPI.Enums;
using YandexAPI.Mаps.Interfaces;

namespace YandexAPI.Mаps
{
    /// <summary>Формирует изображение карты в соответствии со значениями параметров, передаваемых сервису в URL </summary>
    internal class StaticMaps : IStaticMaps
    {
        
        public string GetUrlMapImage(TypeMapEnum type, 
                                        double Latitude, 
                                        double Longitude, 
                                        int width, 
                                        int height, 
                                        string marker,
                                        int zPosition=0)
        {
            GeoPoint point = new GeoPoint(Latitude,Longitude);
            return GetUrlMapImage(type, point, width, height, marker, zPosition);
        }

        public string GetUrlMapImage(TypeMapEnum type, GeoPoint CentrPoint, int width, int height,string marker, int zPosition = 0)
        {
            ValidateMapResolution(width, height);
            string position = "";
            if (zPosition!=0)
            {
                ValidateZPosition(zPosition);
                position = string.Format("&z={0}", zPosition);
            }
              
           
           
            return String.Format("https://static-maps.yandex.ru/1.x/?ll={0}&size={1},{2}{3}&l={4}&pt={5}",
                                                                                                            CentrPoint.ToString(),
                                                                                                            width,
                                                                                                            height,
                                                                                                            position,
                                                                                                            type.ToString().ToLower(),
                                                                                                            marker);
        }

        public string MarkerSplit(double Latitude,double Longitude, StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, string contentMarker)
        {
            GeoPoint point = new GeoPoint(Latitude, Longitude);
            return MarkerSplit(point, styleMarker, sizeMarker, colorMarker, contentMarker);
        }

        public string MarkerSplit(GeoPoint point,StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, string contentMarker)
        {
            //{долгота},{широта},{стиль}{цвет}{размер}{контент}
           return String.Format("{0},{1}{2}{3}{4}", point,styleMarker.ToString(), colorMarker.ToString(), sizeMarker.ToString(), contentMarker.ToString());
        }

        public string MarkerSplits(IEnumerable<GeoPoint> points, GeoPoint SetPoint, StyleMarker styleMarker, SizeMarker sizeMarker, ColorMarker colorMarker, ColorMarker setColorMarker)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            string txt = "";
            foreach (GeoPoint point in points)
            { 
               i++;
                if(point== SetPoint)
                    txt="~" + MarkerSplit(point, styleMarker, sizeMarker, setColorMarker, i.ToString());
                else
                {
                    if (sb.Length > 2) sb.Append("~");
                    sb.Append(MarkerSplit(point, styleMarker, sizeMarker, colorMarker, i.ToString()));
                }
                   
            }
            // пишу в конец чтоб он был сверху.
            sb.Append(txt);
            return sb.ToString();
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
        #region Приватные методы

        /// <summary>Проверка уровня масштабирования </summary>
        /// <param name="zPosition">Уровень масштабирования. Может быть от 1 до 17</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateZPosition(int zPosition)
        {
            if (zPosition < 0 || zPosition > 17)
                throw new ArgumentOutOfRangeException("Уровень масштабирования. Может быть от 1 до 17");
        }

        /// <summary> Проверка разрешение карты </summary>
        /// <param name="width">Ширина. Может быть от 1 до 650</param>
        /// <param name="height">Высота. Может быть от 1 до 450</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateMapResolution(int width, int height)
        {
            if (width < 1 || width > 650)
                throw new ArgumentOutOfRangeException("Ширина. Может быть от 1 до 650");

            if (height < 1 || height > 450)
                throw new ArgumentOutOfRangeException("Высота. Может быть от 1 до 450");
        }

        #endregion
    }
}
