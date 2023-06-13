using System.IO.Compression;

namespace Airports.Data.Service.Interfaces
{
    public interface IReadAirportsCsvService
    {
        /// <summary>Путь до архива. </summary> 
        string ZipPath { get;set; }
        
        /// <summary>Чтение архива </summary>
        /// <returns>Выдает список файлов в архиве </returns>
        /// <exception cref="FileNotFoundException"> Если не правильно указан путь к файлу за архивированного файла</exception>
        IEnumerable<ZipArchiveEntry> ReadZip();

        /// <summary>Проверяет наличие файла в архиве</summary>
        /// <param name="fileName">Имя файла с расширением</param>
        /// <returns></returns>
        bool IsFile(string fileName);

        /// <summary> </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Имя файла с расширением</param>
        /// <param name="separator">Разделитель</param>
        /// <returns></returns>
        IEnumerable<T> GetCsv<T>(string fileName, string separator = ",") where T : class, new();

        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileArhive">Имя файла с расширением</param>
        /// <param name="separator">Разделитель</param>
        /// <returns></returns>
        public IEnumerable<T> GetCsv<T>(ZipArchiveEntry fileArhive, string separator = ",") where T : class, new();
    }
}
