using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels.Base;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Airports.TestWpf.ViewModels
{
    internal class ProgressLoadViewModel:ViewModel
    {
        private readonly IUserDialogService _UserDialog;
        private readonly CancellationTokenSource _TokenSource;
        #region Свойства

        #region PercentProgress : double - Для отображения в ProgressBar

        /// <summary>Для отображения в ProgressBar </summary>
        private double _PercentProgress;

        /// <summary>Для отображения в ProgressBar</summary>
        public double PercentProgress { get => _PercentProgress; set => Set(ref _PercentProgress, value); }
        #endregion

        #region PercentProgress : string - Для отображения в текста

        /// <summary>Для отображения в текста </summary>
        private string _ProgressText;

        /// <summary>Для отображения в текста</summary>
        public string ProgressText { get => _ProgressText; set => Set(ref _ProgressText, value); }
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

        public ProgressLoadViewModel(IUserDialogService _userDialog, CancellationTokenSource tokenSource = default)
        {
            _UserDialog= _userDialog;
            _TokenSource = tokenSource;
        }
    }
}
