using Airports.TestWpf.ViewModels.Base;


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

        public MainWindowViewModel(AirportsViewModel airportsViewModel,FindAirportViewModel findAirportViewModel)
        {
             AirportsViewModel = airportsViewModel;
            FindAirportViewModel = findAirportViewModel;
        }
    }
}
