using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using GameActionsForAll;
using ModelHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsClassLibrary
{

    /// <summary>
    /// Запись отчётов результатов игр в файлы .txt, .html, .doc
    /// </summary>
    class SaveReportToFiles
    {
        /// <summary>
        /// Сохранить отчёты
        /// </summary>
        public static string SaveReports(string parFileName, List<FileFormat> parFilesFotmats, List<GameRezultDTO> parGameRezults)
        {

            var maxRezult = MaxRezult.GetMaxRezult(parGameRezults);

            List<Task<string>> tasks = new List<Task<string>>();

            if (parFilesFotmats.Contains(FileFormat.txt))
            {
              Task<string>  task1 = Task<string>.Run(() => SaveToTxt.Save(parFileName, parGameRezults, maxRezult));
                tasks.Add(task1);
            }

            if (parFilesFotmats.Contains(FileFormat.doc))
            {
                Task<string> task2 = Task<string>.Run(() => SaveToDoc.Save(parFileName, parGameRezults, maxRezult));
                tasks.Add(task2);
                
            }

            if (parFilesFotmats.Contains(FileFormat.html))
            {
                Task<string> task3 = Task<string>.Run(() => SaveToHtml.Save(parFileName, parGameRezults, maxRezult));
                tasks.Add(task3);
            }

            Task.WaitAll(tasks.ToArray());
            string rezult = string.Empty;
            foreach (var item in tasks)
            {

                if (!String.IsNullOrEmpty(item.Result))
                { 
                    rezult += item.Result;
                }
            }
            return rezult;
        }
    }





    /// <summary>
    /// Класс,  отвечающий за сохранение отчёта в .txt - файл
    /// </summary>
    class SaveToTxt
    {
        public static string Save(string parFileName, List<GameRezultDTO> parGameRezults, GameRezultDTO parMaxRezult)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(parFileName + ".txt", false, System.Text.Encoding.Default))
                {


                    sw.WriteLine("\nТетрис.\nРезультаты игр:\n");

                    if (parGameRezults != null && parGameRezults.Count != 0)
                    {
                        var maxLength = parGameRezults.Max(z => z.Name.Length); //Находим длину максимального имени
                                                                             // Чтобы выравнить второй столбец


                        string addSpace = new string(' ', maxLength - "Имя".Length);
                        sw.WriteLine("Имя" + addSpace + "\t" + "Очки\t\t" + "Дата и время игры");

                        foreach (var item in parGameRezults)
                        {
                            addSpace = new string(' ', maxLength - item.Name.Length);
                            sw.WriteLine(item.Name + addSpace + "\t" + item.Score + "\t\t" + item.DateTime);
                        }
                    }
                        sw.WriteLine("");
                        sw.WriteLine("Первый максимальный результат:");
                        sw.WriteLine("Имя: " + parMaxRezult.Name);
                        sw.WriteLine("Очков: " + parMaxRezult.Score);
                        sw.WriteLine("Дата: " + parMaxRezult.DateTime);
                    

                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                return "При записи в txt-фалй произошла ошибка:" + ex.Message;
            }
        }
    }



    /// <summary>
    /// Класс,  отвечающий за сохранение отчёта в .html - файл
    /// </summary>
    class SaveToHtml
    {
        public static string Save(string parFileName, List<GameRezultDTO> parGameRezults, GameRezultDTO parMaxRezult)
        {
            try
            {


                using (StreamWriter sw = new StreamWriter(parFileName + ".html", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("<!DOCTYPE html>\n<html>\n\t<head>\n\t</head>\n\t<body bgcolor='#c0c0c0'>\n\t\t<h1>Тетрис. Результаты игр: </h1>");

                    sw.WriteLine("<table border='1' width='100%' cellpadding='5' bgcolor='aqua'>");
                    sw.WriteLine("<tr><th>Имя</th><th>Очки</th><th>Дата и время игры</th>");
                    foreach (var item in parGameRezults)
                    {
                        sw.WriteLine("<tr><td>" + item.Name + "</td><td>" + item.Score + "</td><td>" + item.DateTime + "</td></tr>");
                    }

                    sw.WriteLine("</table>");

                    sw.WriteLine("<br>");
                    sw.WriteLine("<h3>Первый максимальный результат:</h3>");
                    sw.WriteLine("<p>Имя: " + parMaxRezult.Name + "</p>");
                    sw.WriteLine("<p>Очков: " + parMaxRezult.Score + "</p>");
                    sw.WriteLine("<p>Дата: " + parMaxRezult.DateTime + "</p>");

                    sw.WriteLine("\t</body>\n</html>");
                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                return "При записи в html-фалй произошла ошибка:" + ex.Message;
            }
        }
    }


    /// <summary>
    /// Класс, отвечающий за сохранение отчёта в .docx - файл
    /// </summary>
    /// Статья
    /// Tutorial: как портировать проект с Interop Word API на Open XML SDK
    /// https://habr.com/ru/company/pvs-studio/blog/573866/

    class SaveToDoc
    {
        public static string Save(string parFileName, List<GameRezultDTO> parGameRezults, GameRezultDTO parMaxRezult)
        {
            try
            {

                parFileName += ".docx";
                using (WordprocessingDocument doc = WordprocessingDocument.Create(parFileName,
                                                    WordprocessingDocumentType.Document,
                                                    true))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    AddText(doc, "Тетрис. Результаты игр:");

                    string[,] table = new string[parGameRezults.Count + 1, 3];
                    table[0, 0] = "Имя";
                    table[0, 1] = "Очки";
                    table[0, 2] = "Дата и время игры";

                    for (int i = 1; i <= parGameRezults.Count; i++)
                    {
                        table[i, 0] = parGameRezults[i - 1].Name;
                        table[i, 1] = parGameRezults[i - 1].Score.ToString();
                        table[i, 2] = parGameRezults[i - 1].DateTime.ToString();
                    }
                    InsertWordTable(doc, table);

                    AddText(doc, "");
                    AddText(doc, "Первый максимальный результат:");
                    AddText(doc, "Имя: " + parMaxRezult.Name);
                    AddText(doc, "Очков: " + parMaxRezult.Score);
                    AddText(doc, "Дата: " + parMaxRezult.DateTime);

                }
                return String.Empty;
            }
            catch (Exception ex)
            {
                return "При записи в docx-фалй произошла ошибка:" + ex.Message;
            }

        }

        /// <summary>
        /// Добавить текст
        /// </summary>
        public static void AddText(WordprocessingDocument parDoc, string parText)
        {
            MainDocumentPart mainPart = parDoc.MainDocumentPart;
            Body body = mainPart.Document.Body;
            Paragraph paragraph = body.AppendChild(new Paragraph());
            Run run = paragraph.AppendChild(new Run());
            run.AppendChild(new DocumentFormat.OpenXml.Math.Text(parText));
            run.PrependChild(new RunProperties());
        }

        /// <summary>
        /// Вставка таблицы
        /// </summary>
        public static void InsertWordTable(WordprocessingDocument parDoc,
                                   string[,] parTable)
        {
            DocumentFormat.OpenXml.Wordprocessing.Table dTable =
              new DocumentFormat.OpenXml.Wordprocessing.Table();

            TableProperties props = new TableProperties();

            //рамка
            var borderValues = new EnumValue<BorderValues>(BorderValues.Single);
            var tableBorders = new TableBorders(
                                 new TopBorder { Val = borderValues, Size = 4 },
                                 new BottomBorder { Val = borderValues, Size = 4 },
                                 new LeftBorder { Val = borderValues, Size = 4 },
                                 new RightBorder { Val = borderValues, Size = 4 },
                                 new InsideHorizontalBorder { Val = borderValues, Size = 4 },
                                 new InsideVerticalBorder { Val = borderValues, Size = 4 });

            props.Append(tableBorders);

            //ширина таблицы
            var tableWidth = new TableWidth()
            {
                Width = "5000",
                Type = TableWidthUnitValues.Pct
            };
            props.Append(tableWidth);




            dTable.AppendChild<TableProperties>(props);

            for (int i = 0; i < parTable.GetLength(0); i++)
            {
                var tr = new TableRow();

                for (int j = 0; j < parTable.GetLength(1); j++)
                {
                    var tc = new TableCell();
                    tc.Append(new Paragraph(new Run(new DocumentFormat.OpenXml.Math.Text(parTable[i, j]))));

                    if (i == 0) tc.Append(new TableCellProperties(new Shading { Fill = "EEDDEE" }));
                    else tc.Append(new TableCellProperties(new Shading { Fill = "DDFFDD" }));

                    tr.Append(tc);
                }
                dTable.Append(tr);
            }
            parDoc.MainDocumentPart.Document.Body.Append(dTable);
        }
    }
}
