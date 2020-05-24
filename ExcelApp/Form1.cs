using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ExcelApp
{
    public partial class mainForm : Form
    {
        public class Winners
        {
            public string Name { get; set; }
            public int Number { get; set; }
        }
        public mainForm()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable(); // Глобальная таблица, хранит данные из Excel-файла
        int txtResult; // Хранит число из строки с мин. баллом
        private void openFile_Click(object sender, EventArgs e)
        {
            // Фильтр от лишних форматов, только xlsx.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel workbook (.xlsx)|*.xlsx";
            ofd.Title = "Выберите таблицу Excel";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Очистка таблицы от старых значений
                dt.Rows.Clear();
                dt.Columns.Clear();

                // Сохранение пути выбранного файла в filePath.
                // Создание новой книги Excel, внутри нее лист с содержимым из filePath.
                string filePath = ofd.FileName;
                var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);

                // Если столбец есть в книге, добавляем его в таблицу программы
                // После добавляем остальные строки
                bool firstRow = true;
                foreach (IXLRow row in worksheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                            dt.Columns.Add(cell.Value.ToString());
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                }
                dtGrid.DataSource = dt;
            }
        }
        private void safeFile_Click(object sender, EventArgs e)
        {
            // Фильтр от лишних форматов, только xlsx.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel workbook (.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Заполнение пустых ячеек нулями
                if (dtGrid.DataSource != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        for (int j = 2; j < dtGrid.Rows[i].Cells.Count; j++)
                        {
                            if (Convert.ToString(dtGrid.Rows[i].Cells[j].Value) == "")
                            {
                                dtGrid.Rows[i].Cells[j].Value = 0;
                            }
                        }
                    }
                }
                // Создание новой XLSX-книги, сохранение таблицы на новом листе
                // Сохранение книги в выбранное место на ПК
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt, "Участники");
                string filePath = sfd.FileName;
                wb.SaveAs(filePath);
                MessageBox.Show("Изменения сохранены!");

                // Перезапуск приложения после сохранения
                Application.Restart();
            }
        }

        private void randTime_Click(object sender, EventArgs e)
        {
            // Проверка на наличие данных в dtGrid и столбцов в dt
            if (dtGrid.DataSource != null)
            {
                if (!dt.Columns.Contains("Номер сдачи"))
                {
                    dt.Columns.Add("Номер сдачи", typeof(Int32));
                    dt.Columns.Add("1 тур", typeof(Int32));
                    dt.Columns.Add("2 тур", typeof(Int32));
                    dt.Columns.Add("3 тур", typeof(Int32));
                    dt.Columns.Add("Баллы", typeof(Int32));
                }
                // Устанавливаются рандомные места участникам
                foreach (DataColumn col in dt.Columns)
                    col.ReadOnly = false;
                Random rnd = new Random();
                foreach (DataRow row in dt.Rows)
                    row["Номер сдачи"] = rnd.Next(1, dt.Rows.Count);

                // Запоминаются места
                DataView dv = dt.DefaultView;
                dv.Sort = "Номер сдачи";
                dt = dv.ToTable();

                // Сортировка участников по возрастанию
                int a = 1;
                dtGrid.DataSource = dt;
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    for (int j = 1; j < dtGrid.Rows[i].Cells.Count - 4; j++)
                    {
                        dtGrid.Rows[i].Cells[j].Value = a;
                        a++;
                    }
                }
            }
        }
        private void winners_Click(object sender, EventArgs e)
        {
            // Хранятся фио участников и сумма всех баллов
            List<Winners> wins = new List<Winners>();
            string score = "";

            // Если пустой грид, то ждём пока станет не пустым
            if (dtGrid.DataSource != null)
            {
                // Перебор всех строк грида
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    // Счётчик суммы и строка под каждое ФИО участника
                    int sum = 0;
                    string name = "";

                    // Перебор ячеек 1-3 тур
                    for (int j = 2; j < dtGrid.Rows[i].Cells.Count-1; j++)
                    {
                        // Проверка данных в ячейках
                        int intValue;
                        bool success = Int32.TryParse(Convert.ToString(dtGrid.Rows[i].Cells[j].Value), out intValue);

                        // Если всё ок, считаем и добавляем сумму в ячейки столбца Баллы
                        if (success)
                        {
                            name = Convert.ToString(dtGrid.Rows[i].Cells[0].Value);
                            int row = Convert.ToInt32(dtGrid.Rows[i].Cells[j].Value);
                            sum = sum + row;
                            dtGrid.Rows[i].Cells[dtGrid.Rows[i].Cells.Count - 1].Value = sum;
                        }
                    }

                    // Добавление фио и баллов в коллекцию
                    wins.Add(new Winners() { Name = name, Number = sum });
                }
            }
            // Вывод 3-х победителей олимпиады
            if (txtRes.Text != "")
            {
                foreach (var num in wins.OrderByDescending(n => n.Number).Take(3))
                {
                    // Запись победителей в строку
                    if (num.Number >= txtResult)
                        score += "Победитель: " + num.Name + ", кол-во баллов: " + num.Number + "\n";
                }
            }
            // Вывод окна победителей если они есть
            if (score != "")
                MessageBox.Show(score, "Поздравляем победителей!");
        }
        private void txtRes_TextChanged(object sender, EventArgs e)
        {
            // Проверка на вводимые данные, вывод предупреждения
            int intValue;
            if(txtRes.Text != "")
            {
                if (Int32.TryParse(txtRes.Text, out intValue)) 
                { 
                    txtResult = Convert.ToInt32(txtRes.Text);
                    if (txtResult <= 0)
                    {
                        MessageBox.Show("Минимальный балл не может быть равен 0.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRes.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Введенное число не является целым, либо\nслишком большое!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRes.Clear();
                }
            }
        }
        private void dtGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // При неверном вводе данных в ячейки таблицы
            MessageBox.Show("Вы ввели не число, проверьте введенные данные!","Предупреждение!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
