using Airports.TestWpf.Infrastructure.Commands;
using Airports.TestWpf.Services.Interfaces;
using Airports.TestWpf.ViewModels;
using Airports.TestWpf.Views.Windows;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Airports.TestWpf.Services
{
    internal class WindowsUserDialogService : IUserDialogService
    {
        private static Window ActiveWindow => Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);

        public bool Open(ProgressLoadViewModel vm)
        {
            return OpenProgress(vm);
        }

        public void Close(ProgressLoadViewModel vm)
        {
            if (Application.Current.Dispatcher.CheckAccess())
            {
                CloseDialog(vm);
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(
                  DispatcherPriority.Background,
                  () => CloseDialog(vm));
            }
        }

        public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

        public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(
                Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;

       

        private static bool OpenProgress(ProgressLoadViewModel vm)
        {
            var dlg = new ProgressLoadWindow
            {
                DataContext= vm,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true) return false;

            return true;
        }

        private void CloseDialog(ProgressLoadViewModel vm)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext != null)
                {
                    if (window.DataContext.GetType() == vm.GetType())
                    {
                        window.Close();
                        break;
                    }
                }          
            }
        }
    }
}
