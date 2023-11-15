using ControllerClassLibrary;
//using IViewForGameOverController;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewInterfaces;
using WinFormsApp1;
using static ControllerClassLibrary.Controller;

namespace WinFormsTetris
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new WindowsController().Go();
        }
    }
}
