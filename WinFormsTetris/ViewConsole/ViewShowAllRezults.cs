using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using ViewInterfaces;

namespace ViewConsole
{
    /// <summary>
    /// Класс. Показ результатов игр
    /// </summary>
   public class ViewShowAllRezults: IViewInterfaceForShowAllRezultsController
    {
        /// <summary>
        /// Действия со страницами, содержащими результатами
        /// </summary>
        enum Move
        {
            /// <summary>
            /// Перейти на одну вверх
            /// </summary>
            up,

            /// <summary>
            /// Перейти на одну вниз
            /// </summary>
            down,

            /// <summary>
            /// Перейти на первую страницу
            /// </summary>
            first
        }

        /// <summary>
        /// Ширина окна
        /// </summary>
        static readonly int _width = 80;

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
        /// Флаг, показывает что отчёты сохранены в текущую папку
        /// </summary>
        bool _isReportSavedToFolder = false;

        /// <summary>
        /// Путь к папке в которой сохранены отчёты
        /// </summary>
        string _folder;

        /// <summary>
        /// Ширина выделяемая под меню, содержащее параграфы помощи
        /// </summary>
        const int _menuWidth = 23;

        /// <summary>
        /// Отступ от левого края
        /// </summary>
        const int _dxLeft = 2;

        /// <summary>
        /// Отступ от верхнего края
        /// </summary>
        const int _dyUp = 2;

        /// <summary>
        /// Координата Y, где окончился вывод сообщения о лучшем результате
        /// </summary>
        int _yPozitionBestRezult = 0;

        /// <summary>
        /// Индекс в списке, с которого начинаем выводить результаты. Нужен чтобы выводить только часть результатов, которые влазят на экран
        /// </summary>
        int _indexStartPozitionToShowRezults = 0;

        /// <summary>
        /// Список результатов игр
        /// </summary>
        List<GameRezultDTO> _rezultsDTO = new List<GameRezultDTO>();

        /// <summary>
        /// Список пунктов меню
        /// </summary>
        string[] _commands = { "1.Листать вверх", "2.Листать вниз", "", "F1-Сохранить отчёты", "F10 - Выход" };



        public event EventHandler<List<FileFormat>> SavingRezult;


        /// <summary>
        /// Показать окно
        /// </summary>
        void ShowWindow(Object obj, EventArgs args)
        {
            ShowView();
        }

        public void ShowView()
        {
            ConsoleHelper.DrawWindow(_startX, _startY, _height, _width);
            ShowMenu();
            ShowPartOfRezults(Move.first);
        }


        public void SetModel(IModelRezultsInterface parModel)
        {
            parModel.NewListRezultsRecived += RevreshCurrentRezult;
            parModel.ReportsSaved += ShowMessageReportsSaved;
            parModel.ReportsNotSaved += ShowMessageReportsNotSaved;
            parModel.ShowNewWindow += ShowWindow;
        }

        /// <summary>
        /// Метод выводит сообщения о том, что отчёты о результатах игр сохранены
        /// </summary>
        void ShowMessageReportsSaved(object sender, EventArgs args)
        {
            int i = _yPozitionBestRezult + 2;
            Console.SetCursorPosition(_startX + _dxLeft, _startY +  i);
            Console.Write("Отчёты сохранены.");
            i++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + i);
            Console.Write("F2-открыть папку.");

            _isReportSavedToFolder = true;

            Console.Beep();
        }



        /// <summary>
        /// Метод выводит сообщения о том, что отчёты о результатах игр НЕ сохранены
        /// </summary>
        void ShowMessageReportsNotSaved(object sender, string parErrors)
        {
            int i = _yPozitionBestRezult+2;
            Console.SetCursorPosition(_startX + _dxLeft, _startY +  i);
            Console.Write("Ошибка!"); 
            i++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + i);
            Console.Write("Отчёты не сохранены!");
            i++;
            int stringStartIndex = 0;
            int stringWidth = _menuWidth - _dxLeft - 2;
            string subStr = "";

            bool isAllMessageShow = false; //true,если всё сообщение об ошибке выведено на экран

            do
            {
                Console.SetCursorPosition(_startX + _dxLeft, _startY + i);

                if (stringStartIndex + stringWidth > parErrors.Length)//если длины строки не хватает на полную выводимую строчку на экран 
                {
                    subStr = parErrors.Substring(stringStartIndex, parErrors.Length - stringStartIndex); //берём оставшуюся часть её
                    isAllMessageShow = true;
                }
                else subStr = parErrors.Substring(stringStartIndex, stringWidth); //берём полноценную строчку для вывода на экран

                Console.Write(subStr);
                stringStartIndex += stringWidth;
                i++;
                

            } while (i<_height-3 && stringStartIndex<parErrors.Length);

            if (!isAllMessageShow) //Если не всё сообщение выведено на экран
            {
                Console.SetCursorPosition(_startX + _dxLeft, _startY + i);
                Console.Write(".......");
            }


            _isReportSavedToFolder = false;
            Console.Beep();
        }



        /// <summary>
        /// Получить команду от пользователя
        /// </summary>
        /// <returns></returns>
        public void GetUserCommand(object sender, ConsoleKeyInfo parClick)
        {
            if (parClick.Key == ConsoleKey.F10)
            {
                return;
            }
                if (parClick.Key == ConsoleKey.F1) OnSaveRezult();
                if (parClick.Key == ConsoleKey.F2 && _isReportSavedToFolder) OpenFolderInWinExplorer();

                var ch = parClick.KeyChar;

                if (byte.TryParse(ch.ToString(), out byte n))
                {
                    if (n==1) //листать вверх
                    {
                        ShowPartOfRezults(Move.up);
                    }

                    if (n==2) //листать вниз
                    {
                        ShowPartOfRezults(Move.down);
                    }
                }
        }

        /// <summary>
        /// Сохранить результат
        /// </summary>
        void OnSaveRezult()
        {
            _isReportSavedToFolder = false;

            _folder = Directory.GetCurrentDirectory();
            

            List<FileFormat> list = new List<FileFormat>();

                list.Add(FileFormat.doc);
                list.Add(FileFormat.html);
                list.Add(FileFormat.txt);

            SavingRezult?.Invoke(_folder, list);
        }

        /// <summary>
        /// Открыть папку в которой сохранены отчёты в проводнике
        /// </summary>
        void OpenFolderInWinExplorer()
        {
            Process.Start("explorer.exe", _folder);
        }



        /// <summary>
        /// Показываем Текущий результат
        /// </summary>
        void RevreshCurrentRezult(object sender, List<GameRezultDTO> parRezultsDTO)
        {
            this._rezultsDTO = parRezultsDTO;
            _indexStartPozitionToShowRezults = 0;
        }


        /// <summary>
        /// Вывести часть результатов игр, которая влазит на экран
        /// </summary>
        void ShowPartOfRezults(Move parMove)
        {
            int startIndex=0;                   //индекс в списке результатов, начиная с которого начинаем выводить результаты
            int numberForPrint = _height -2- _dyUp; //Количество строк с результатами , выводимых на экран

            if (parMove == Move.first) startIndex = 0;
            
            if (parMove == Move.up)
            {
                Console.Beep();
                //если выведена первая страница результатов
                if (_indexStartPozitionToShowRezults - numberForPrint <0 ) startIndex = 0;
                else _indexStartPozitionToShowRezults -= numberForPrint;
            }
            
            if (parMove == Move.down)
            {
                Console.Beep();
                //если выведена последняя страница результатов
                if (_indexStartPozitionToShowRezults + numberForPrint > _rezultsDTO.Count) startIndex = _indexStartPozitionToShowRezults;
                else startIndex=_indexStartPozitionToShowRezults += numberForPrint;
            }


            ConsoleHelper.ClearArea(_startX + _menuWidth, _startY + 1, _height - 2, _width - 2 - _menuWidth);

            if (_rezultsDTO.Count == 0) return;

            var maxLength = _rezultsDTO.Max(z => z.Name.Length); //Находим длину максимального имени
                                                                // Чтобы выравнить второй столбец

            int j = _dyUp;
            Console.SetCursorPosition(_startX + _menuWidth, _startY + j);
            string addSpace = new string(' ', maxLength - "Имя".Length);
            Console.WriteLine("Имя" + addSpace + "\t" + "Очки\t\t" + "Дата и время игры");


            j++;
            for (int k = startIndex; k <_rezultsDTO.Count && k< startIndex+ numberForPrint; k++)
            {
                addSpace = new string(' ', maxLength - _rezultsDTO[k].Name.Length);
                Console.SetCursorPosition(_startX + _menuWidth, _startY + j);
                Console.WriteLine(_rezultsDTO[k].Name + addSpace + "\t" + _rezultsDTO[k].Score + "\t\t" + _rezultsDTO[k].DateTime);
                j++;
            }

            
            var maxRecord = MaxRezult.GetMaxRezult(_rezultsDTO);
            j = _dyUp+ _commands.Length;

            j++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j );
            Console.Write("Лучший результат.");
            j++;

            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write("Имя:");
            j++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write(maxRecord.Name);
            j++;
            
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write("Очки:");
            j++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write(maxRecord.Score.ToString());
            
            j++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write("Дата:");
            j++;
            Console.SetCursorPosition(_startX + _dxLeft, _startY + j);
            Console.Write(maxRecord.DateTime.ToString());

            _yPozitionBestRezult = j;
        }

        

        /// <summary>
        /// Вывести меню на экран
        /// </summary>
        void ShowMenu()
        {
            ConsoleHelper.ClearArea(_startX + 1, _startY + 1, _startY + _dyUp + _commands.Length, _menuWidth); 

            int i = _dyUp;
            foreach (var item in _commands)
            {
                Console.SetCursorPosition(_startX + _dxLeft, _startY + i);
                Console.Write(item);
                i++;
            }
        }
    }
}
