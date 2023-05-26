using Microsoft.Extensions.DependencyInjection;

namespace Airports.TestWpf.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel=>App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
