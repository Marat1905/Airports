namespace Airports.TestWpf.Model
{
    public record struct ProgressLoadModel
    {
        /// <summary>Общее количество итераций</summary>
        public int CountRows { get; set; }
        /// <summary>Счетчик строк </summary>
        public int ProgressCount { get; set; }
        /// <summary>Количество загруженных файлов</summary>
        public int CountDownloadFiles { get; set; }
        /// <summary>Какой файл грузится </summary>
        public string File { get; set; }

        /// <summary>Для прогресс бара </summary>
        /// <param name="countRows">Общее количество итераций</param>
        /// <param name="progressCount">Счетчик строк</param>
        /// <param name="countDownloadFiles">Количество загруженных файлов</param>
        /// <param name="file">Какой файл грузится</param>
        public ProgressLoadModel(int countRows,int progressCount,int countDownloadFiles,string file)
        {
            CountRows = countRows;
            ProgressCount = progressCount;
            CountDownloadFiles = countDownloadFiles;
            File = file;
        }
    }
}
