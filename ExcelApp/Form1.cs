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
            public override string ToString()
            {
                return "Участник: " + Name + "   Баллов: " + Number;
            }
        }

        public mainForm()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        DataTable sortedDT = new DataTable();
        int txtResult;
        private void openFile_Click(object sender, EventArgs e)
        {
            // Фильтр от лишних форматов, только xlsx.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel workbook (.xlsx)|*.xlsx";
            ofd.Title = "Выберите таблицу Excel";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Сохранение пути выбранного файла в filePath.
                // Создание новой книги Excel, внутри нее лист с содержимым из filePath.
                string filePath = ofd.FileName;
                var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheet(1);

                // Если столбец есть в книге, добавляем в таблицу программы
                // Иначе добавляем остальные строки
                bool firstRow = true;
                foreach (IXLRow row in worksheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
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
            }
            // ЗНачение таблицы dt в dtGrid
            dtGrid.DataSource = dt;
        }

        private void safeFile_Click(object sender, EventArgs e)
        {
            // Фильтр от лишних форматов, только xlsx.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel workbook (.xlsx)|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Создание новой XLSX-книги, созданение листа Участники со значением таблицы sortedDT
                // Сохранение книги в выбранное место на ПК
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(sortedDT, "Участники");
                string filePath = sfd.FileName;
                wb.SaveAs(filePath);
            }
            MessageBox.Show("Изменения сохранены!");
        }

        private void randTime_Click(object sender, EventArgs e)
        {

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
                foreach (DataColumn col in dt.Columns)
                    col.ReadOnly = false;
                Random rnd = new Random();
                foreach (DataRow row in dt.Rows)
                    row["Номер сдачи"] = rnd.Next(0, dt.Rows.Count);

                DataView dv = dt.DefaultView;
                dv.Sort = "Номер сдачи";
                sortedDT = dv.ToTable();

                int a = 1;
                dtGrid.DataSource = sortedDT;

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
            // Хранятся сумма всех баллов и 3-х максимальных
            List<Winners> wins = new List<Winners>();

            // Если пустой грид, то ждём пока станет не пустым
            if (!dtGrid.Rows.Equals(""))
            {
                // Перебор всех строк грида
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    
                    // Счётчик суммы
                    int sum = 0;
                    string name = "";
                    // Перебор ячеек 1-3 тур
                    for (int j = 2; j < dtGrid.Rows[i].Cells.Count - 1; j++)
                    {
                        name = Convert.ToString(dtGrid.Rows[i].Cells[0].Value);
                        // роверка данных в ячейках
                        int intValue;
                        bool success = Int32.TryParse(Convert.ToString(dtGrid.Rows[i].Cells[j].Value), out intValue);
                        // сли всё ок, считаем и добавляем сумму в ячейку Баллы
                        if (success)
                        {
                            int row = Convert.ToInt32(dtGrid.Rows[i].Cells[j].Value);
                            sum = sum + row;
                            dtGrid.Rows[i].Cells[dtGrid.Rows[i].Cells.Count - 1].Value = sum;
                        }
                    }
                    // Добавление фио и баллов в коллекцию
                    wins.Add(new Winners() { Name = name, Number = sum });
                }


                // Вывод 3-х победителей олимпиады
                foreach (var num in wins.OrderByDescending(n => n.Number).Take(3))
                {
                   
                    if (num.Number == txtResult)
                    {
                        MessageBox.Show(num.ToString());
                    }
                }
            }
        }
        private void score_Click(object sender, EventArgs e)
        {
            txtResult = Convert.ToInt32(txtRes.Text);
        }

        private void txtRes_TextChanged(object sender, EventArgs e)
        {
            int intValue;
            //bool res = Int32.TryParse(txtRes.Text, out intValue);
            if(txtRes.Text != "")
            {
                if (Int32.TryParse(txtRes.Text, out intValue))
                {
                    txtResult = Convert.ToInt32(txtRes.Text);
                }
                else
                {
                    MessageBox.Show("Введенное число не является целым, либо\nслишком большое!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRes.Clear();
                }
            }
           
        }
    }
}
