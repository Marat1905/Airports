﻿using Airports.TestWpf.Infrastructure.Commands.Base;
using System.Windows;

namespace Airports.TestWpf.Infrastructure.Commands
{
    class CloseDialogCommand : Command
    {
        public bool? DialogResult { get; set; }

        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            var window = (Window)parameter;
            window.DialogResult = DialogResult;
            window.Close();
        }
    }
}
