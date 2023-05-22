using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airports.TestWpf
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app=new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
