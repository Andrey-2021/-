using ModelHelper;
using System;
using System.Threading;
using ViewInterfaces;

namespace ViewConsole
{
    /// <summary>
    /// Класс, отвечающий за вывод результата текущей оконченной игры
    /// </summary>
    public class ViewGameOverForm : IViewInterfaceForGameOverController
    {
        /// <summary>
        /// Ширина окна
        /// </summary>
        static readonly int _width = 65;

        /// <summary>
        /// Высота окна
        /// </summary>
        static readonly int _height = 15;

        /// <summary>
        /// Координата Х верхнего левого угла окна
        /// </summary>
        readonly int _startX = (Console.WindowWidth - _width) / 2;

        /// <summary>
        /// Координата Y верхнего левого угла окна
        /// </summary>
        readonly int _startY = (Console.WindowHeight - _height) / 2;
        
        /// <summary>
        /// Флаг, окончание показа окна с результатами игры
        /// </summary>
        bool _isEndShowGameOverWindow = false;
        
        /// <summary>
        /// Координата Х для мерцания символа, показывающего необходимость ввода имени игрока
        /// </summary>
        int _xBlink = 0;
        
        /// <summary>
        /// Координата Y для мерцания символа, показывающего необходимость ввода имени игрока
        /// </summary>
        int _yBlink = 0;
        
        /// <summary>
        /// Флаг, показан/скрыт символ "мерцания"
        /// </summary>
        bool _isBlink = false;

        /// <summary>
        /// Имя игрока
        /// </summary>
        string _userName = "";

        /// <summary>
        /// Симол мерцания
        /// </summary>
        char _blinkChar = ':';

        /// <summary>
        /// Координата Х, для отображения вводимого имени
        /// </summary>
        int _xForName = 0;

        /// <summary>
        /// Координата Y, для отображения вводимого имени
        /// </summary>
        int _yForName = 0;

        /// <summary>
        /// Результат игры
        /// </summary>
        GameRezultDTO _rezultDTO = null;

        public event EventHandler<string> SavingRezult;

        public void ShowView()
        {
            ConsoleHelper.DrawWindow(_startX, _startY, _height, _width);
            ShowInfo();

            do
            {
                Thread.Sleep(100);
                Blink();
                if (_isEndShowGameOverWindow) break;
            } while (true);
        }

        

        /// <summary>
        /// Мерцание символа
        /// </summary>
        void Blink()
        {
            if (_isBlink)
            {
                _isBlink = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(_xBlink, _yBlink);
                Console.Write(_blinkChar);
            }
            else
            {
                _isBlink = true;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(_xBlink, _yBlink);
                Console.Write(_blinkChar);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        


        /// <summary>
        /// Обработка нажатия клавиши пользователя
        /// </summary>
        public void GetUserCommand(object sender, ConsoleKeyInfo parClick)
        {
            //ограничение на вводимую длину имени пользователя
            const int lengthUserName = 10;


            //Если нажата кнопка F1 - сохранить в файл
            if (parClick.Key == ConsoleKey.F1)
            {
                OnSaveRezult(_userName);
                _isEndShowGameOverWindow = true;
                return;
            }

            //Если нажата кнопка F10 - выход
            if (parClick.Key == ConsoleKey.F10)
            {
                _isEndShowGameOverWindow = true;
                return;
            }

            //Если это Backspace или Буква или Цифра
            if (parClick.Key == ConsoleKey.Backspace || Char.IsLetterOrDigit(parClick.KeyChar))
            {
                //Если это Backspace и длина введённого имени больше 0
                if (parClick.Key == ConsoleKey.Backspace && _userName.Length > 0)
                {
                    _userName = _userName.Remove(_userName.Length - 1, 1); //удаляем последний символ в имени

                    //выводим имя игрока
                    Console.SetCursorPosition(_xForName, _yForName);
                    Console.Write(_userName+" ");

                }
                else
                {
                    var ch = parClick.KeyChar;
                    if (Char.IsLetterOrDigit(ch) && _userName.Length <= lengthUserName)
                    { 
                        _userName += ch; //добавляем символ к имени игрока
                        
                        //выводим имя игрока
                        Console.SetCursorPosition(_xForName, _yForName);
                        Console.Write(_userName);
                    }
                    else Console.Beep();
                }
                return;
            }
            Console.Beep();
        }




        /// <summary>
        /// Выводи информации о результатах игры в окно
        /// </summary>
        void ShowInfo()
        {
            string score = "_";
            string date = "_";
            if (_rezultDTO != null)
            {
                score = _rezultDTO.Score.ToString();
                date = _rezultDTO.DateTime.ToString();
            }

            int i = 2;
            int dx = 17;

            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write("Ваш результат: " + score);

            i += 2;
            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write("Дата игры: " + date);

            i += 2;
            Console.ForegroundColor = ConsoleColor.Black;
            string str = "Введите имя";
            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            _xBlink = _startX + dx + str.Length;
            _yBlink = _startY + i;

            _xForName = _startX + dx + str.Length+2;
            _yForName = _startY + i;
            


            i += 2;
            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write("Нажмите:");

            i += 2;
            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write("    F1 - Сохранить результат");

            i += 2;
            Console.SetCursorPosition(_startX + dx, _startY + i);
            Console.Write("    F10 - Выход");

        }


        public void SetModel(IModelRezultsInterface parModel)
        {
            parModel.NewCurrentRezultRecived += RevreshCurrentRezult;
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
        /// Показываем текущий результат
        /// </summary>
        void RevreshCurrentRezult(object sender, GameRezultDTO parRezultDTO)
        {
            this._rezultDTO = parRezultDTO;
        }

        /// <summary>
        /// Сохранить результат в файле
        /// </summary>
        /// <param name="parUserName"></param>
        void OnSaveRezult(string parUserName)
        {
            SavingRezult?.Invoke(this, parUserName);
        }

    }
}
