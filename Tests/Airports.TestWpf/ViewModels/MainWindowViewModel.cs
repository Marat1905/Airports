using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Model;
using Airports.TestWpf.Resources.Controls;
using Airports.TestWpf.ViewModels.Base;
using Microsoft.Identity.Client;
using System;
using System.Windows.Input;

namespace Airports.TestWpf.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {   
        #region Заголовок окна. 
        private string _Title="Главное окно";
       
        /// <summary>Заголовок окна.</summary>
        public string Title { get => _Title ; set { Set(ref _Title, value); } }
        #endregion

        #region Status : string - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";

        /// <summary>Статус программы</summary>
        public string Status {  get => _Status; set => Set(ref _Status, value); }
        #endregion

        #region SelectedPageIndex : int - Номер выбранной вкладки

        /// <summary>Номер выбранной вкладки</summary>
        private int _SelectedPageIndex = 1;

        /// <summary>Номер выбранной вкладки</summary>
        public int SelectedPageIndex
        {get => _SelectedPageIndex;set => Set(ref _SelectedPageIndex, value); }
        public AirportsViewModel AirportsViewModel { get; }
        public FindAirportViewModel FindAirportViewModel { get; }

        #endregion


        #region Command LightThemeCommand - Перейти на светлую сторону

        /// <summary>Перейти на светлую сторону</summary>
        private ICommand _LightThemeCommand;

        /// <summary>Перейти на светлую сторону</summary>
        public ICommand LightThemeCommand => _LightThemeCommand
            ??= new LambdaCommand(OnLightThemeCommandExecuted, CanLightThemeCommandExecute);

        /// <summary>Проверка возможности выполнения - Перейти на светлую сторону</summary>
        private static bool CanLightThemeCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Перейти на светлую сторону</summary>
        private void OnLightThemeCommandExecuted(object p)
        {
            AppTheme.ChangeTheme(new Uri("Resources/Themes/Light.xaml", UriKind.Relative));
        }

        #endregion

        #region Command DarkThemeCommand - Перейти на светлую сторону

        /// <summary>Перейти на светлую сторону</summary>
        private ICommand _DarkThemeCommand;

        /// <summary>Перейти на светлую сторону</summary>
        public ICommand DarkThemeCommand => _DarkThemeCommand
            ??= new LambdaCommand(OnDarkThemeCommandExecuted, CanDarkThemeCommandExecute);

        /// <summary>Проверка возможности выполнения - Перейти на светлую сторону</summary>
        private static bool CanDarkThemeCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Перейти на светлую сторону</summary>
        private void OnDarkThemeCommandExecuted(object p)
        {
            AppTheme.ChangeTheme(new Uri("Resources/Themes/Dark.xaml", UriKind.Relative));
        }

        #endregion

        public MainWindowViewModel(AirportsViewModel airportsViewModel,FindAirportViewModel findAirportViewModel)
        {
             AirportsViewModel = airportsViewModel;
            FindAirportViewModel = findAirportViewModel;
        }
    }
}
