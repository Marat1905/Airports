using Airports.Data.Infrastructure.Attributes;
using Airports.Data.Infrastructure.Helper;
using Airports.Data.Service.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Airports.Data.Service
{
    public class ReadAirportsCsvService:IReadAirportsCsvService
    {
        #region Поля
        private string zipPath;
        #endregion

        #region Свойства
        /// <summary>Путь до архива. </summary>
        public string ZipPath
        {
            get { return zipPath; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Строка не может быть пустой или null строкой или содержать пробел", nameof(value));
                zipPath = value;
            }
        }

     
        #endregion

        #region Конструкторы
        /// <summary>Инициализирует новый экземпляр класса <see cref="ReadAirportsCsvService"/>. </summary>
        /// <param name="zipPath">Полный путь до архива.</param>
        public ReadAirportsCsvService(string zipPath) => ZipPath = zipPath;
        public ReadAirportsCsvService() { }
        #endregion

        #region Методы

        /// <summary>Чтение архива </summary>
        /// <returns>Выдает список файлов в архиве </returns>
        /// <exception cref="FileNotFoundException"> Если не правильно указан путь к файлу за архивированного файла</exception>
        public IEnumerable<ZipArchiveEntry> ReadZip()
        {
            //Проверяем правильность указания пути к архиву.
            FileInfo file = new FileInfo(ZipPath);
            if (!file.Exists)
                throw new FileNotFoundException("Не правильно указан путь к архиву", ZipPath);
            //Получаем список файлов в архиве
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
                foreach (var entry in archive.Entries)
                    yield return entry;
        }

        /// <summary>Проверяет наличие файла в архиве</summary>
        /// <param name="fileName">Имя файла с расширением</param>
        /// <returns></returns>
        public bool IsFile(string fileName)
        {
            return ReadZip().Any(x => x.Name == fileName);
        }

        public int Count(string filename)
        {
            int countOfLines = 0;
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                var sample = archive.GetEntry(filename);
                if (sample != null)
                {
                    using (var zipEntryStream = sample.Open())
                        using (StreamReader reader = new StreamReader(zipEntryStream))
                            while (reader.ReadLine()!= null)
                                countOfLines++;
                }
            }
            return countOfLines;
        }

        /// <summary> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Имя файла с расширением</param>
        /// <param name="separator">Разделитель</param>
        /// <returns></returns>
        public IEnumerable<T> GetCsv<T>(string fileName, string separator = ",") where T : class, new()
        {
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                var sample = archive.GetEntry(fileName);
                if (sample != null)
                {
                    using (var zipEntryStream = sample.Open())
                    {
                        using (StreamReader reader = new StreamReader(zipEntryStream, Encoding.Default))
                        {
                            // Возвращаем словарь MapProp словарь с информацией о свойствах и атрибутом 
                            Dictionary<PropertyInfo, CsvAttribute> MapProp = MapProperties(typeof(T));

                            // Получаем первую строку и делим ее на название столбцов
                            // string pattern = string.Format("{0}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))", separator);
                            var pattern = new Regex($"""{separator}(?=(?:[^"]*"[^"]*")*(?![^"]*"))""", RegexOptions.Compiled);
                            var header = reader.ReadLine();
                            var headers = pattern.Split(header);

                            //// Создаем словарь 
                            Dictionary<string, int> myMap = MapHeaders(headers);

                            // читаем в цикле до конца файла
                            while (!reader.EndOfStream)
                            {
                                // Получаем строку и разбиваем на массив
                                string line = reader.ReadLine();
                                string[] lines = pattern.Split(line);
                                lines = lines.Select(x => x.Replace("\"", "")).ToArray();

                                var result = new T();
                                for (var i = 0; i < headers.Length; i++)
                                {
                                    var value = lines[i];
                                    // зная индекс массива получаем с словаря его KeyValuePair 
                                    var map = myMap.Where(x => x.Value == i).FirstOrDefault();
                                    // из полученного KeyValuePair словаря получаем KeyValuePair второго словаря
                                    var mapProp = MapProp.Where(x => x.Value.Name == map.Key).FirstOrDefault();
                                    // Устанавливаем значение
                                    SetPropertyValue(result, value, map, mapProp);
                                }
                                yield return result;

                                //var result = new T();
                                //StringReader sr= new StringReader(reader.ReadLine());
                                //using (TextFieldParser parser = new TextFieldParser(sr))
                                //{
                                //    parser.TextFieldType = FieldType.Delimited;
                                //    parser.SetDelimiters(",");

                                //    while (!parser.EndOfData)
                                //    {
                                //        var fields = parser.ReadFields();
                                //        for (var i = 0; i < headers.Length; i++)
                                //        {
                                //            var value = fields[i].Replace("\"", "");

                                //            // зная индекс массива получаем с словаря его KeyValuePair 
                                //            var map = myMap.Where(x => x.Value == i).FirstOrDefault();
                                //            // из полученного KeyValuePair словаря получаем KeyValuePair второго словаря
                                //            var mapProp = MapProp.Where(x => x.Value.Name == map.Key).FirstOrDefault();
                                //            // Устанавливаем значение
                                //            SetPropertyValue(result, value, map, mapProp);
                                //        }
                                //    }
                                //}
                                //yield return result;
                            }
                        }
                    }
                }
            }
        }
        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileArhive">Имя файла с расширением</param>
        /// <param name="separator">Разделитель</param>
        /// <returns></returns>
        public IEnumerable<T> GetCsv<T>(ZipArchiveEntry fileArhive, string separator = ",") where T : class, new()
        {
            foreach (var temp in GetCsv<T>(fileArhive.Name, separator: separator))
                yield return temp;
        }

        #endregion

        #region Приватные методы
        private static void SetPropertyValue<T>(T result, string value, KeyValuePair<string, int> map, KeyValuePair<PropertyInfo, CsvAttribute> mapProp) where T : class, new()
        {
            if (mapProp.Value != null)
            {
                if (mapProp.Value.Name == map.Key)
                {
                    if (mapProp.Key.PropertyType.IsEnum)
                    {
                        Type enumType = mapProp.Key.PropertyType;
                        var en = enumType.GetFields();
                        var t = EnumHelper.GetValueFromDescription(enumType, value);
                        mapProp.Key.SetValue(result, Enum.Parse(mapProp.Key.PropertyType, t.Name));
                    }
                    else
                    {
                        Type t = Nullable.GetUnderlyingType(mapProp.Key.PropertyType) ?? mapProp.Key.PropertyType;
                        object safeValue = string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, t, CultureInfo.InvariantCulture);
                        mapProp.Key.SetValue(result, safeValue, null);
                    }

                }
            }
        }
        /// <summary>Получаем словарь свойств и атрибутов</summary>
        /// <param name="type">Получаем тип модели</param>
        /// <returns>Возвращаем словарь свойств и атрибутами</returns>
        private Dictionary<PropertyInfo, CsvAttribute> MapProperties(Type type)
        {
            //Получаем массив свойств текущего объекта
            var properties = type.GetProperties();
            // Создаем словарь информацией о свойствах и атрибутом
            Dictionary<PropertyInfo, CsvAttribute> MapProp = new Dictionary<PropertyInfo, CsvAttribute>();
            // Заполняем словарь свойством и атрибутами
            foreach (PropertyInfo property in properties)
            {
                CsvAttribute attribute =
                    Attribute.GetCustomAttribute(property, typeof(CsvAttribute)) as CsvAttribute;
                if (attribute != null)
                    MapProp[property] = attribute;
            }
            return MapProp;
        }
        /// <summary>Метод для получения словаря заголовков</summary>
        /// <param name="header">Первая строка прочитанная</param>
        /// <returns> Возвращаем словарь заголовков </returns>
        private Dictionary<string, int> MapHeaders(string[] headers)
        {
            //// Создаем словарь 
            Dictionary<string, int> myMap = new Dictionary<string, int>();
            // Убираем двойные кавычки в массиве 
            headers = headers.Select(x => x.Replace("\"", "")).ToArray();
            //Заполняем словарь название столбца и его положение 
            for (int i = 0; i < headers.Length; i++)
            {
                myMap[headers[i]] = i;// отслеживание индекса имени каждого столбца
            }
            return myMap;
        }

       
        #endregion
    }
}
