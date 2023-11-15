using ModelHelper;
using System;
using System.Collections.Generic;
using ViewInterfaces;

namespace ViewConsole
{
    /// <summary>
    /// Класс. Представляет окно Помощи
    /// </summary>
    class ViewHelp : IViewInterfaceForHelp
    {
        /// <summary>
        /// Ширина окна
        /// </summary>
        static readonly int _width = 65;

        /// <summary>
        /// Высота окна
        /// </summary>
        static readonly int _height = 30;

        /// <summary>
        /// Координата Х верхнего левого угла окна
        /// </summary>
        readonly int _startX = (Console.WindowWidth - _width) / 2;

        /// <summary>
        /// Координата Y верхнего левого угла окна
        /// </summary>
        readonly int _startY = (Console.WindowHeight - _height) / 2;

        /// <summary>
        /// Флаг. Закончен показ окна
        /// </summary>
        //bool _isEndShowGameOverWindow = false;

        /// <summary>
        /// Ширина выделяемая под меню, содержащее параграфы помощи
        /// </summary>
        const int _menuWidth = 20;

        /// <summary>
        /// Отступ от краёв по Х
        /// </summary>
        int _dx = 2;

        /// <summary>
        /// Отступ от краёв по Y
        /// </summary>
        int _dy = 2;

        /// <summary>
        /// Список пунктов меню
        /// </summary>
        List<string> _paragraphList = new List<string>();


        public event EventHandler GettingParagraphList;
        public event EventHandler<string> GettingText;
        public event EventHandler CloseWindow;


        public void ShowView()
        {
            ConsoleHelper.DrawWindow(_startX, _startY, _height, _width);
            GettingParagraphList?.Invoke(this, EventArgs.Empty);

            if (_paragraphList.Count > 0)
                OnRecivingText(_paragraphList[0]);
        }

        /// <summary>
        /// Получить команду от пользователя
        /// </summary>
        /// <returns></returns>
        public void GetUserCommand(object sender, ConsoleKeyInfo parClick)
        {
            if (parClick.Key == ConsoleKey.F10)
            {
                CloseWindow?.Invoke(this, EventArgs.Empty);
                // isEndShowGameOverWindow = true;
                return;
            }

            var ch = parClick.KeyChar;

            if (byte.TryParse(ch.ToString(), out byte n)) //если пользователь ввёл число
            {
                if (n >= 0 && _paragraphList.Count > n)
                    OnRecivingText(_paragraphList[n]);
                else Console.Beep();
            }
            else Console.Beep();
        }


        public void SetModel(IModelHelpIntefaceForViewer parModel)
        {
            parModel.NewParagraphsRecived += RevreshParagraphList;
            parModel.NewTextRecived += RevreshText;
            parModel.ShowNewWindow += ShowWindow;
        }

        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow(Object obj, EventArgs args)
        {
            ShowView();
        }




        /// <summary>
        /// Обновляем список параграфов
        /// </summary>
        void RevreshParagraphList(object sender, List<string> parParagraphsNames)
        {

            ConsoleHelper.ClearArea(_startX + _dx, _startY + 1, _height - 2, _menuWidth); // width-2);

            _paragraphList = parParagraphsNames;

            int i = 0;
            foreach (var item in parParagraphsNames)
            {
                Console.SetCursorPosition(_startX + _dx, _startY + _dy + i);
                Console.Write(i.ToString() + "." + item);
                i++;
            }
            Console.SetCursorPosition(_startX + _dx, _startY + _dy + i);
            Console.Write("F10. Выход");
        }



        /// <summary>
        /// Обновляем текст/описание
        /// </summary>
        void RevreshText(object sender, string parText)
        {
            string[] separator = { Environment.NewLine };
            string[] list = parText.Split(separator, StringSplitOptions.RemoveEmptyEntries);


            ConsoleHelper.ClearArea(_startX + _menuWidth, _startY + 1, _height - 2, _width - _dx - 1 - _menuWidth);

            if (list.Length == 0) return;

            int yIndex = _dy; //координата y, для вывода строки



            for (int i = 0; i < list.Length && yIndex < _height - _dy; i++) //В цикле выводим только строки, которые уместятся на экране
            {

                string strForPrint = list[i];

                do //это цикл нужен для разбивки строки - если текущая строка текста не влазит в окно
                {

                    Console.SetCursorPosition(_startX + _menuWidth, _startY + yIndex);
                    yIndex++;
                    int widthStr = _width - _menuWidth - _dx - _dx;

                    if (strForPrint.Length > widthStr)
                    {
                        Console.Write(strForPrint.Substring(0, widthStr));
                        strForPrint = strForPrint.Remove(0, widthStr);
                    }
                    else
                    {
                        Console.Write(strForPrint);
                        break;
                    }

                } while (true);
            }
        }

        /// <summary>
        ///  Метод события. Используемый для создания события запроса списка параграфов
        /// </summary>
        void OnRecivingParagraphList()
        {
            GettingParagraphList?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод события. Используемый для создания события запроса текста выбранного параграфа
        /// </summary>
        void OnRecivingText(string parParagraphName)
        {
            GettingText?.Invoke(this, parParagraphName);
        }

    }
}
