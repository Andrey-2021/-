using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsTetris
{

    /// <summary>
    /// Абстрактный класс. Для View Windows-приложения
    /// </summary>
    public abstract class ViewForAll<T> where  T : Form
    {
        /// <summary>
        /// Windows-окно с которым работаем
        /// </summary>
        internal T _window;

        /// <summary>
        /// Показать окно
        /// </summary>
        public virtual void ShowView()
        {
            _window.ShowDialog();
        }

        /// <summary>
        /// Вывести на экран
        /// </summary>
        internal  void ShowWindow(Object obj, EventArgs args)
        {
            ShowView();
        }

    }
}
