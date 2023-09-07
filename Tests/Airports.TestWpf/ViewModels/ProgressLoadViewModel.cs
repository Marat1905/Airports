using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Airports.TestWpf.ViewModels
{
    internal class ProgressLoadViewModel:ViewModel
    {
        private readonly IUserDialogService _UserDialog;
        private readonly CancellationTokenSource _TokenSource;
        private readonly int _Files;
        #region Свойства

        #region PercentProgress : double - Для отображения в ProgressBar

        /// <summary>Для отображения в ProgressBar </summary>
        private double _PercentProgress = 0.0;

        /// <summary>Для отображения в ProgressBar</summary>
        public double PercentProgress
        {
            get
            {
                double result =0.0;
                result = ((CountDownloadFiles-1)*(100.0 / _Files)) + (((100.0 / _Files) * ProgressCount) / CountRows);
                if (double.IsNaN(result))
                    _PercentProgress = 0.0;
                else
                    _PercentProgress =result;

                return _PercentProgress;
            }
            set
            {
                if (double.IsNaN(value))
                    Set(ref _PercentProgress, 0.0);
                else
                    Set(ref _PercentProgress, value);
            }
                
        }

        #endregion

        #region CountRows : int - Общее количество итераций

        /// <summary>Общее количество итераций  </summary>
        private int _CountRows;

        /// <summary>Общее количество итераций</summary>
        public int CountRows { get => _CountRows; set => Set(ref _CountRows, value); }

        #endregion

        #region ProgressCount : int - Счетчик строк 

        /// <summary>Счетчик строк </summary>
        private int _ProgressCount;

        /// <summary>Счетчик строк </summary>
        public int ProgressCount
        { 
            get => _ProgressCount;
            set
            {
                if(Set(ref _ProgressCount, value))
                    OnPropertyChanged(nameof(PercentProgress));
            }
        }

        #endregion

        #region CountDownloadFiles : double - Счетчик загруженных файлов загруженных файлов 

        /// <summary>Счетчик загруженных файлов загруженных файлов </summary>
        private int _CountDownloadFiles = 0;

        /// <summary>Количество загруженных файлов</summary>
        public int CountDownloadFiles 
        { 
            get => _CountDownloadFiles;
            set
            {
                if(value > _Files)
                    throw new ArgumentOutOfRangeException(nameof(value),"Загружаемых файлов не может быть больше установленного в конструкторе");

                Set(ref _CountDownloadFiles, value);
                    OnPropertyChanged(nameof(ProgressText));
            } 
        }

        #endregion

        #region PercentProgress : string - Для отображения в текста

        /// <summary>Для отображения в текста </summary>
        private string _ProgressText;

        /// <summary>Для отображения в текста</summary>
        public string ProgressText 
        {
            get 
            {
                return string.Format("Загрузка данных {0} из {1}", CountDownloadFiles, _Files);
            } 
            set => Set(ref _ProgressText, value); 
        }
        #endregion

        #region FileDownload : int - Общее количество итераций

        /// <summary>Общее количество итераций  </summary>
        private string _FileDownload;

        /// <summary>Общее количество итераций</summary>
        public string FileDownload { get => _FileDownload; set => Set(ref _FileDownload, value); }

        #endregion

        #endregion

        #region Команды

        #region Command CancelCommand - Кнопка Отмена

        /// <summary>Кнопка Отмена</summary>
        private ICommand _CancelCommand;

        /// <summary>Кнопка Отмена</summary>
        public ICommand CancelCommand => _CancelCommand
            ??= new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);

        /// <summary>Проверка возможности выполнения - Кнопка Отмена</summary>
        private bool CanCancelCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Кнопка Отмена</summary>
        private void OnCancelCommandExecuted(object p)
        {
          if( _UserDialog.Confirm("Вы действительно хотите остановить процесс?","Отмена операции"))
            {
                //отменяем выполнение задачи
                _TokenSource.Cancel();

                if (p is Window window)
                    window.Close();
            }
        }

        #endregion
        #endregion

        public ProgressLoadViewModel(IUserDialogService _userDialog, CancellationTokenSource tokenSource = default, int files=1)
        {
            _UserDialog= _userDialog;
            _TokenSource = tokenSource;
            _Files = files;
        }
    }
}
