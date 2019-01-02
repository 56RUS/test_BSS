using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace bss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        
        // Сохранение данных из xml-файла в БД
        // !!! В БД будут сохранены данные из файлов, соответствующих формату.
        // !!! Данные из файлов, не соответствующих формату, сохранены в БД не будут
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            // Путь к папке  программой
            string pathToExe = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string[] xmlFiles = { };
            // Работа с БД
            linqClass linq = new linqClass();
            XmlSerializer formatter = null;
            List<OwnerData> owners = null;
            bool resultSave = false;


            // Выбор папки с xml-файлами
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = false;
            // Начальная папка для поиска - папка с программой
            folderBrowser.SelectedPath = pathToExe;
            DialogResult result = folderBrowser.ShowDialog();
            // Если нажата кнопка OK
            if (result == DialogResult.OK)
            {
                // Если папка выбрана
                if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    // Получаю список xml-файлов
                    xmlFiles = Directory.GetFiles(folderBrowser.SelectedPath, "*.xml");
                    formatter = new XmlSerializer(typeof(List<OwnerData>), new XmlRootAttribute("OwnersData"));

                    // Если в выбранной папке есть xml-файлы
                    if (xmlFiles.Length > 0)
                    {
                        // Обрабатываю каждый файл
                        foreach (string path in xmlFiles)
                        {
                            try
                            {
                                // Открываю файл для чтения
                                using (FileStream fs = new FileStream(path, FileMode.Open))
                                {
                                    // Получаю данные в файле в список
                                    owners = (List<OwnerData>)formatter.Deserialize(fs);
                                    // Перебираю полученные данные
                                    for (int cntOwn = 0; cntOwn < owners.Count();)
                                    {
                                        // У каждого OwnerData перебираю список CalcsData
                                        for (int cntCalc = 0; cntCalc < owners[cntOwn].CalcsData.Count();)
                                        {
                                            // Если (Param1 + Param2) не равен CheckSum, то удаляю эти данные из списка
                                            // Если равны, то перехожу к следующему элементу
                                            if ((owners[cntOwn].CalcsData[cntCalc].Param1 + owners[cntOwn].CalcsData[cntCalc].Param2) != owners[cntOwn].CalcsData[cntCalc].CheckSum)
                                                owners[cntOwn].CalcsData.RemoveAt(cntCalc);
                                            else
                                                cntCalc++;
                                        }

                                        // Если у OwnerData список CalcsData пустой, то удаляю этот OwnerData
                                        // Если CalcsData не пустой, то перехожу к следующему элементу
                                        if (owners[cntOwn].CalcsData.Count == 0)
                                            owners.RemoveAt(cntOwn);
                                        else
                                            cntOwn++;
                                    }

                                    // В списке owners останутся только те данные, у которых есть CalcsData с валидными данными
                                    // Сохраняю валидные данные из xml-файла в БД
                                    resultSave = linq.addNewData(owners);
                                    if (!resultSave)
                                        break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Файл " + path + " имеет неправильный формат данных!", "Ошибка!", MessageBoxButtons.OK);
                            }
                        }

                        if (resultSave)
                            MessageBox.Show("Данные из xml-файлов успешно сохранены в БД!", "Успех!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Что-то пошло не так... Данные не были сохранены в БД!", "Ошибка!", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("В выбранной папке нет xml-файлов!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
        }


        // Сохранение данных из БД в xml-файл
        private void btnSaveInXml_Click(object sender, EventArgs e)
        {
            string fileName = "";
            // Работа с БД
            linqClass linq = new linqClass();
            List<OwnerData> owners = null;
            XmlSerializer formatter = null;


            // Выбор файла для сохранения данных
            SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.Filter = "XML-File | *.xml";
            DialogResult result = fileSave.ShowDialog();
            // Если нажата кнопка OK
            if (result == DialogResult.OK)
            {
                try
                {
                    // Получаю путь к выбранному файлу
                    fileName = fileSave.FileName;

                    // Получаю данные из БД
                    owners = linq.getData();

                    if (owners != null)
                    {
                        formatter = new XmlSerializer(typeof(List<OwnerData>), new XmlRootAttribute("OwnersData"));

                        // Открываю файл для записи
                        using (FileStream fs = new FileStream(fileName, FileMode.Create))
                        {
                            // Записываю данные в файл
                            formatter.Serialize(fs, owners);
                            MessageBox.Show("Данные из БД успешно сохранены в файл " + fileName + " !", "Успех!", MessageBoxButtons.OK);
                        }
                    }
                    else
                        MessageBox.Show("Что-то пошло не так... Данные не были сохранены в файл!", "Ошибка!", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Данные из БД не сохранены в файл!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
        }
    }

}
