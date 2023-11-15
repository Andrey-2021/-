using ModelHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ModelsClassLibrary
{
    /// <summary>
    /// класс Model для окна Помощи
    /// </summary>
    public class ModelHelp: IModelHelpInterface
    {
        /// <summary>
        /// Данные прочитанные из файла
        /// </summary>
        List<HelpDTO> _helpList = null;

        public event EventHandler<List<string>> NewParagraphsRecived;
        public event EventHandler<string> NewTextRecived;
        public event EventHandler ShowNewWindow;


        

        /// <summary>
        /// Конструктор
        /// </summary>
        public ModelHelp()
        {
            LoadHelpFromXML();
        }

        public void GetParagraphList()
        {
            var paragraphsList= ReadParagraphListFromDb();
            NewParagraphsRecived?.Invoke(this, paragraphsList);
        }

        public void GetText(string parParagraphName)
        {
            string text = GetTextFromDb(parParagraphName);
            NewTextRecived?.Invoke(this,text);
        }


        
        /// <summary>
        /// Читаем данные из XML файла
        /// </summary>
        void LoadHelpFromXML()
        {
            _helpList = new List<HelpDTO>();

            const string fName= "Help.xml";
            if (!File.Exists(fName)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(fName);

            foreach (XmlNode node in doc.DocumentElement)
            {
                var record = new HelpDTO();
                record.Name= node.Attributes[0].Value;
                record.Text = node.InnerText;
                _helpList.Add(record);
            }
        }


        /// <summary>
        /// Получить список параграфов из хранилища
        /// </summary>
        /// <returns></returns>
        List<string> ReadParagraphListFromDb()
        {
            List<string> paragraphsNames = new List<string>();
            foreach (var item in _helpList)
            {
                paragraphsNames.Add(item.Name);
            }
            return paragraphsNames;
        }


        /// <summary>
        /// Получить текст параграфа
        /// </summary>
        string GetTextFromDb(string parParagraphName)
        {
            return _helpList.Find(x => x.Name == parParagraphName).Text;
        }


        /// <summary>
        /// Показать окно
        /// </summary>
        public void ShowWindow()
        {
            ShowNewWindow?.Invoke(this, EventArgs.Empty);
        }
    }
}
