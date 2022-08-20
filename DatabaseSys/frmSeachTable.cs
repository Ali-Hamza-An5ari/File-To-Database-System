using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseSys
{
    public partial class frmSeachTable : Form
    {
        private List<string> tableNames;
        public frmSeachTable()
        {
            InitializeComponent();
        }

        private void frmSeachTable_Load(object sender, EventArgs e)
        {
            
            string[] categories = { "B2B", "Social Media" };

            this.cbCategory.Items.AddRange(categories);


            this.cbCategory.SelectedText = "--select--";
            this.cbTableNames.SelectedText = "--select--";

            this.cbCategory.SelectedItem = null;
            this.cbTableNames.SelectedItem = null;

            BindingSource bs = new BindingSource();
            bs.DataSource = GetAllCountrysNames();
            cbCountry.DataSource = bs;

            this.cbCountry.SelectedItem = null;
            this.cbCountry.SelectedText = "--select--";

        }

        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            string dbName = this.cbCategory.GetItemText(this.cbCategory.SelectedItem);
            string tableName = this.cbTableNames.GetItemText(this.cbTableNames.SelectedItem);
            string countryName = this.cbCountry.GetItemText(this.cbCountry.SelectedItem);
            //int numberOfCols = tableNames.Count;
            //MessageBox.Show(numberOfCols+"");
            this.Hide();
            frmFilterSearchedTable fst = new frmFilterSearchedTable(selectedTableName: tableName, selectedDBName: dbName,selectedCountryName:countryName);
            fst.Show();
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
        private List<String> getTableNames(String dbName)
        {
            List<String> Tablenames = new List<String>();
            string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (dbName).Replace(" Media", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (dbName).Replace(" ", String.Empty) + ".mdf; Integrated Security = true; Connection Timeout=30;";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                //string query = "show tables ";
                //string query = "show tables from "+ (dbName).Replace(" ", String.Empty);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tablenames.Add(reader.GetString(0));
                    }
                }
                connection.Close();
            }
            return Tablenames;
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cbCategory.SelectedItem != "")
            {
                
                tableNames = getTableNames(this.cbCategory.GetItemText(this.cbCategory.SelectedItem));
                this.cbTableNames.Items.Clear();
                //this.cbTableNames.SelectedText = "--select--";
                this.cbTableNames.SelectedItem = null;
                this.cbTableNames.Items.AddRange(tableNames.ToArray());

            }
        }

        private void cbTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmDBMS fMain = new frmDBMS();
            fMain.Closed += (s, args) => this.Close();
            fMain.Show();

        }
    }
}
