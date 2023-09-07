using Airports.TestWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airports.TestWpf.Services.Interfaces
{
    internal interface IUserDialogService
    {
        bool Open(ProgressLoadViewModel vm);

        void Close(ProgressLoadViewModel vm);

        void ShowInformation(string Information, string Caption);

        void ShowWarning(string Message, string Caption);

        void ShowError(string Message, string Caption);

        bool Confirm(string Message, string Caption, bool Exclamation = false);

    }
}
