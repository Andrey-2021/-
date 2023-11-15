using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс. Сопоставление Consol-цветов и Windows-цветов для фигур
    /// </summary>
   public static class ConsoleColorExtension
    {
        /// <summary>
        /// Преобразование Consol-цвета в Windows-цвет
        /// </summary>
        /// <param name="parConsoleColor">Consol-цвет</param>
        /// <returns>Windows-цвет</returns>
        public static Color ConvertToColor(this ConsoleColor parConsoleColor)
        {
            Dictionary<ConsoleColor, Color> converter = new Dictionary<ConsoleColor, Color>()
            {
                { ConsoleColor.Black, Color.Black },
                { ConsoleColor.DarkBlue, Color.DarkBlue },
                { ConsoleColor.DarkGreen, Color.DarkGreen },
                { ConsoleColor.DarkCyan, Color.DarkCyan },
                { ConsoleColor.DarkRed, Color.DarkRed },
                { ConsoleColor.DarkMagenta, Color.DarkMagenta },
                { ConsoleColor.DarkYellow, Color.Orange },
                { ConsoleColor.Gray, Color.Gray },
                { ConsoleColor.DarkGray, Color.DarkGray},
                { ConsoleColor.Blue, Color.Blue },
                { ConsoleColor.Green, Color.Green },
                { ConsoleColor.Cyan, Color.Cyan },
                { ConsoleColor.Red, Color.Red },
                { ConsoleColor.Magenta, Color.Magenta },
                { ConsoleColor.Yellow, Color.Yellow },
                { ConsoleColor.White, Color.White }
            };
            return converter.GetValueOrDefault(parConsoleColor);
        }
    }
}
