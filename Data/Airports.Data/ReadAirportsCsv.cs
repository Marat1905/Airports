using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.Data
{
    public class ReadAirportsCsv
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
        /// <summary>Инициализирует новый экземпляр класса <see cref="ReadAirportsCsv"/>. </summary>
        /// <param name="zipPath">Полный путь до архива.</param>
        public ReadAirportsCsv(string zipPath) => ZipPath = zipPath;
        #endregion

        #region Методы
        /// <summary>Чтение архива </summary>
        /// <returns>Выдает список файлов в архиве </returns>
        /// <exception cref="FileNotFoundException"> Если не правильно указан путь к файлу за архивированного файла</exception>
        public IEnumerable<ZipArchiveEntry> ReadZip()
        {
            List<ZipArchiveEntry> result = new List<ZipArchiveEntry>();
            //Проверяем правильность указания пути к архиву.
            FileInfo file = new FileInfo(ZipPath);
            if (!file.Exists)
                throw new FileNotFoundException("Не правильно указан путь к архиву", ZipPath);
            //Получаем список файлов в архиве
            using (ZipArchive archive = ZipFile.OpenRead(ZipPath))
            {
                result.AddRange(archive.Entries);
            }
            return result;
        }
        /// <summary>Проверяет наличие файла в архиве</summary>
        /// <param name="fileName">Имя файла с расширением</param>
        /// <returns></returns>
        public bool IsFile(string fileName)
        {
            return ReadZip().Any(x => x.Name == fileName);
        }
        #endregion
    }
}
