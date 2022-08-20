using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using IronXL;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using CsvHelper;

namespace DatabaseSys
{
    public partial class frmCatForSelect : Form
    {
        public static string filename;
        public static List<string> coulmnNames;
        public static string country;
        public static string category;
        public static string fileSource;
        public static string selectedFormat;
        public static bool isDelimiteredFile;
        public frmCatForSelect()
        {
            InitializeComponent();
            
        }

        private void frmCatForSelect_Load(object sender, EventArgs e)
        {
            coulmnNames = new List<string>();

            this.cbCategory.SelectedText = "--select--";
            this.cbCountry.SelectedText = "--select--";
            this.cbDataSource.SelectedText = "--select--";
            this.cbFormat.SelectedText = "--select--";

            string[] categories = { "B2B", "Social Media" };
            string[] dataSource = { "Social Media", "B2B", "Website"};
            string[] fileFormats = { "CSV", "Excel","Txt" };

            cbCountry.Items.Add("Pakistan");
            // cbCountry.Items.AddRange(GetAllCountrysNames());
            BindingSource bs = new BindingSource();
            bs.DataSource = GetAllCountrysNames();

            cbCountry.DataSource = bs;
            this.cbCountry.SelectedItem = null;
            this.cbCountry.SelectedText = "--select--";
            cbCategory.Items.AddRange(categories);
            cbDataSource.Items.AddRange(dataSource);
            cbFormat.Items.AddRange(fileFormats);
        }
        public static List<string> GetAllCountrysNames()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            
            return cultures
                    .Select(cult => (new RegionInfo(cult.LCID)).DisplayName)
                    .Distinct()
                    .OrderBy(q => q)
                    .ToList();
        }

        private void btnUpFile_Click(object sender, EventArgs e)
        {
            filename = "";
            selectedFormat = this.cbFormat.GetItemText(this.cbFormat.SelectedItem);
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                //Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                // DefaultExt = "txt",
                //Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if(selectedFormat.Equals("Excel"))
            {
                openFileDialog1.Title = "Browse Xlsx Files";
                openFileDialog1.DefaultExt = "xlsx";
                openFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    Excel.Range range;

                    string str;
                    int rCnt;
                    int cCnt;
                    int rw = 0;
                    int cl = 0;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(frmCatForSelect.filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    if(xlWorkSheet != null)
                    {
                        range = xlWorkSheet.UsedRange;
                        rw = range.Rows.Count;
                        cl = range.Columns.Count;

                        for (int o = 1; o < rw; o++)
                        {
                            var va = (range.Cells[o, 1] as Excel.Range).Value2;
                            if (va != null)
                            {
                                for (int p = 1; p <= cl; p++)
                                {
                                    coulmnNames.Add((range.Cells[o, p] as Excel.Range).Value2.ToString());
                                }
                                break;
                            }

                        }

                    }

                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();

                    this.btnNext.BackColor = Color.RoyalBlue;
                    this.btnNext.Enabled = true;
                }
            }
            else if (selectedFormat.Equals("CSV"))
            {
                openFileDialog1.Title = "Browse csv Files";
                openFileDialog1.DefaultExt = "csv";
                openFileDialog1.Filter = "csv files (*.csv)|*.csv";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    using (var fileReader = File.OpenText(frmCatForSelect.filename))
                    {
                        using (var csvResult = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                        {
                            string arr;
                            while (csvResult.Read() == null)
                            {

                            }
                            csvResult.ReadHeader();
                            if (csvResult.HeaderRecord[0].Contains("|"))
                            {
                                isDelimiteredFile = true;
                                coulmnNames.AddRange(csvResult.HeaderRecord[0].Split('|'));
                            }
                            else
                            {
                                coulmnNames.AddRange(csvResult.HeaderRecord);
                            }
                            //MessageBox.Show(csvResult.HeaderRecord[5] + " = " + csvResult.ColumnCount + " " + csvResult.HeaderRecord.Length);
                            
                            

                        }
                    }

                            this.btnNext.BackColor = Color.RoyalBlue;
                        this.btnNext.Enabled = true;

                }
            }
            else if (selectedFormat.Equals("Txt"))
            {
                openFileDialog1.Title = "Browse txt Files";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                // openFileDialog1.ShowDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string firstLine = "";
                    filename = openFileDialog1.FileName;

                    if (File.Exists(filename))
                    {
                        using (StreamReader file = new StreamReader(filename))
                        {
                            firstLine = file.ReadLine();
                        }
                        coulmnNames.AddRange(firstLine.Split(' '));
                    }
                        this.btnNext.BackColor = Color.RoyalBlue;
                        this.btnNext.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("Please Select a valid format.");
            }

            openFileDialog1.FilterIndex = 2;
            if (!filename.Equals(""))
            {

                MessageBox.Show("File uploaded. click Next to continue");
            }
            //MessageBox.Show(filename);
        }

       
        //public void ReadCSVData()
        //{
        //    var csvFilereader = new DataTable();
        //    csvFilereader = ReadExcel();
        //}
        public void setColumnNames(DataColumnCollection col)
        {
            foreach (var c in col)
            {
                coulmnNames.Add(c.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            category = cbCategory.GetItemText(this.cbCategory.SelectedItem);
            country = cbCountry.GetItemText(this.cbCountry.SelectedItem);
            fileSource = cbDataSource.GetItemText(this.cbDataSource.SelectedItem);
            //CloseAllForm();
            this.Hide();

            frmTableOptions fTO = new frmTableOptions();
            fTO.Closed += (s, args) => this.Close();
            fTO.Show();
        }
        private bool isAllFieldSelected()
        {
            category = this.cbCategory.GetItemText(this.cbCategory.SelectedItem);
            country = this.cbCountry.GetItemText(this.cbCountry.SelectedItem);
            fileSource = this.cbDataSource.GetItemText(this.cbDataSource.SelectedItem);
            MessageBox.Show(category + " " + country + " " + fileSource);

            if (!(category.Equals("")) && !(country.Equals("")) && !(fileSource.Equals("")))
            {
                return true;
                //this.lblWarning.Text = "*Please make sure you have selected category, country and data source";
            }
            else
            {
                return false;
            }
        }
        void CloseAllForm()
        {

            for (int x = 0; x < Application.OpenForms.Count; x++)
            {
                if (Application.OpenForms[x] != this)
                    Application.OpenForms[x].Close();
            }
        }

        private void btnBackfromView_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmDBMS fMain = new frmDBMS();
            fMain.Closed += (s, args) => this.Close();
            fMain.Show();
        }
    }
}
