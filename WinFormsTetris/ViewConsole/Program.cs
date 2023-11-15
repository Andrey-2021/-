using ControllerClassLibrary;
using Microsoft.VisualBasic;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using ViewInterfaces;

namespace ViewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsoleController().Go();
            
        }
    }
}
