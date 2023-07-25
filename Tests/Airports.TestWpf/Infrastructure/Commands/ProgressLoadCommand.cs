using Airports.TestWpf.Infrastructure.Commands.Base;
using Airports.TestWpf.Views.Windows;
using System;
using System.Windows;

namespace Airports.TestWpf.Infrastructure.Commands
{
    internal class ProgressLoadCommand:Command
    {
        private ProgressLoadWindow _Window;

        public override bool CanExecute(object parameter) => _Window == null;

        public override void Execute(object parameter)
        {
            var window = new ProgressLoadWindow
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object Sender, EventArgs E)
        {
            ((Window)Sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
