using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ViewInterfaces;

namespace WinFormsTetris
{
    /// <summary>
    /// Класс, представляющий окно с результатами игр
    /// </summary>
    public partial class ViewShowAllRezults : ViewForAll<ViewShowAllRezultsWindow>, IViewInterfaceForShowAllRezultsController
    {
        public event EventHandler<List<FileFormat>> SavingRezult;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ViewShowAllRezults()
        {
            _window = new ViewShowAllRezultsWindow();
            _window.buttonCancel.Click += ButtonClick;
            _window.buttonSave.Click += ButtonSaveClick;
        }
        
        public void SetModel(IModelRezultsInterface parModel)
        {
            parModel.NewListRezultsRecived += RevreshCurrentRezult;
            parModel.ReportsSaved += ShowMessageReportsSaved;
            parModel.ReportsNotSaved += ShowMessageReportsNotSaved;
            parModel.ShowNewWindow += ShowWindow;
        }

        /// <summary>
        /// Метод, выводит сообщения о том, что отчёты о результатах игр сохранены
        /// </summary>
        void ShowMessageReportsSaved(object sender, EventArgs args)
        {
            MessageBox.Show("Отчёты сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Метод выводит сообщения о том, что отчёты о результатах игр НЕ сохранены
        /// </summary>
        void ShowMessageReportsNotSaved(object sender, string errors)
        {
            MessageBox.Show("Ошибка! Отчёты не сохранены!\n" + errors, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Показываем Текущий результат
        /// </summary>
        void RevreshCurrentRezult(object sender, List<GameRezultDTO> parRezultsDTO)
        {
            _window.dataGridViewRezults.DataSource = parRezultsDTO;
            _window.dataGridViewRezults.Columns[0].HeaderText = "Имя игрока";
            _window.dataGridViewRezults.Columns[1].HeaderText = "Набранные очки";
            _window.dataGridViewRezults.Columns[2].HeaderText = "Дата игры";

            var maxRecord = MaxRezult.GetMaxRezult(parRezultsDTO);

            _window.textBoxName.Text = maxRecord.Name;
            _window.textBoxScore.Text = maxRecord.Score.ToString();
            _window.textBoxDate.Text = maxRecord.DateTime.ToString();
        }


        /// <summary>
        /// Сохранить результат
        /// </summary>
        /// <param name="parFolder"></param>
        void OnSaveRezult(string parFolder)
        {
            List<FileFormat> list = new List<FileFormat>();

            if (_window.checkBoxDoc.Checked) list.Add(FileFormat.doc);
            if (_window.checkBoxHtml.Checked) list.Add(FileFormat.html);
            if (_window.checkBoxTxt.Checked) list.Add(FileFormat.txt);

            SavingRezult?.Invoke(parFolder, list); //проинформировать подписчиков, что надо сохранить результат
            
        }


        /// <summary>
        /// Метод, обрабатывает событие "Нажатие кнопки Закрыть окно"
        /// </summary>
        private void ButtonClick(object sender, EventArgs e)
        {
            _window.Close();
        }

        /// <summary>
        /// Метод, обрабатывает событие "Нажатие кнопки Сохранить"
        /// </summary>
        private void ButtonSaveClick(object sender, EventArgs e)
        {
            if (_window.checkBoxTxt.Checked == false 
                && _window.checkBoxDoc.Checked == false 
                && _window.checkBoxHtml.Checked == false)
            {
                MessageBox.Show("Не выбран формат файла для отчёта!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string folder = SelectFolder();
            if (String.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Не выбрана папка в которую должены быть сохранены отчёты!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OnSaveRezult(folder);
        }

        /// <summary>
        /// Метод возвращает выбранную пользователем папку, в которую будут сохранены отчёты о результатах игр
        /// </summary>
        string SelectFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            return null;
        }
    }
}
