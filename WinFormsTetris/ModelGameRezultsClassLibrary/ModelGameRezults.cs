

using GameActionsForAll;
using ModelHelper;
using ModelsClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace ModelGameRezultsClassLibrary
{
    /// <summary>
    /// Класс, представляем Model для результатов игры
    /// </summary>
    public class ModelGameRezults : IModelRezultsInterface
    {
        /// <summary>
        /// Текущий результат
        /// </summary>
        GameRezultDTO _currentGameRezult = null;

        /// <summary>
        /// Имя файла, в котором хранятся результаты игр
        /// </summary>
        const string fName = "GamesRezults.xml";

        public event EventHandler<GameRezultDTO> NewCurrentRezultRecived;
        public event EventHandler<List<GameRezultDTO>> NewListRezultsRecived;
        public event EventHandler ReportsSaved;
        public event EventHandler<string> ReportsNotSaved;
        public event EventHandler ShowNewWindow;


        public void SetCurrentRezult(int parScore, DateTime parDate)
        {
            _currentGameRezult = new GameRezultDTO()
            {
                Score = parScore,
                DateTime = parDate
            };
            NewCurrentRezultRecived?.Invoke(this, _currentGameRezult);
        }


        public void SaveCurrentRezultToDb(string parFio)
        {
            _currentGameRezult.Name = parFio;

            XDocument xdoc;
            XElement root;

            try
            {
                bool fileExist = File.Exists(fName);
                if (!fileExist)
                {
                    xdoc = new XDocument();
                    // создаем корневой элемент
                    root = new XElement("rezults");
                }
                else
                {
                    xdoc = XDocument.Load(fName);
                    root = xdoc.Element("rezults");
                }


                // создаем новый элемент
                XElement record = new XElement("rezult");
                // создаём вложенные элементы
                XElement name = new XElement("name", _currentGameRezult.Name);
                XElement score = new XElement("score", _currentGameRezult.Score.ToString());
                XElement date = new XElement("date", _currentGameRezult.DateTime.ToString());

                record.Add(name);
                record.Add(score);
                record.Add(date);

                // добавляем в корневой элемент
                root.Add(record);

                // добавляем корневой элемент в документ
                if (!fileExist) xdoc.Add(root);

                //сохраняем документ
                xdoc.Save(fName);
            }
            catch (Exception ex)
            {
                DelFile(fName);
            }
        }


        public void ReadRezultsFromDb()
        {
            var rezults = ReadRezultsFromXML();
            NewListRezultsRecived?.Invoke(this, rezults);
        }

        
        /// <summary>
        /// Прочитать результаты игр из XML-файлы
        /// </summary>
        /// <returns>Список результатов игр</returns>
        public List<GameRezultDTO> ReadRezultsFromXML()
        {
            List<GameRezultDTO> rezultsList = new List<GameRezultDTO>();

            if (!File.Exists(fName)) return rezultsList;

            try
            {

                XDocument xdoc = XDocument.Load(fName);

                foreach (XElement rezultElement in xdoc.Element("rezults").Elements("rezult"))
                {
                    XElement name = rezultElement.Element("name");
                    XElement score = rezultElement.Element("score");
                    XElement date = rezultElement.Element("date");

                    if (name != null && score != null && date != null)
                    {
                        var record = new GameRezultDTO()
                        {
                            Name = name.Value,
                            Score = Convert.ToInt32(score.Value),
                            DateTime = Convert.ToDateTime(date.Value)
                        };
                        rezultsList.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                DelFile(fName);
            }

            return rezultsList;
        }

        /// <summary>
        /// Удалить файл с результатами
        /// </summary>
        /// <param name="parFileName">Имя файла</param>
        void DelFile(string parFileName)
        {
            //Если при работе с данными из фаила произошла ошибка,
            //Копируем файл в новый файл с прибавленным окончанием
            //Удаляем файл с результатами
            File.Copy(fName, fName + ".oldRezults-"
                + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString());
            File.Delete(fName);
        }


        
        public void SaveRezultsReports(List<FileFormat> parFilesFotmats, string parFolder)
        {
            string fileNameForReport = "report";

            if (!String.IsNullOrEmpty(parFolder) && parFolder[parFolder.Length - 1] != '\\') parFolder = parFolder + "\\";
                fileNameForReport = parFolder + fileNameForReport;

            string rezult= SaveReportToFiles.SaveReports(fileNameForReport, parFilesFotmats, ReadRezultsFromXML());
            if (String.IsNullOrEmpty(rezult)) ReportsSaved?.Invoke(this, EventArgs.Empty);
            else ReportsNotSaved?.Invoke(this, rezult);
    }

        
        public void ShowWindow()
        {
            ShowNewWindow?.Invoke(this, EventArgs.Empty);
        }
    }
}
