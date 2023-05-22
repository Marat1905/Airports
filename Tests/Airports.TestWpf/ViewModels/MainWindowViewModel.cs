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



    }
}
