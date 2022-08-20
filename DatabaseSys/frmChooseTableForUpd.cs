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
    public partial class frmChooseTableForUpd : Form
    {
        private List<string> tableNames;
        public frmChooseTableForUpd()
        {
            InitializeComponent();
        }

        private void btnSearchTableU_Click(object sender, EventArgs e)
        {

            string dbName = this.cbCategory.GetItemText(this.cbCategory.SelectedItem);
            string tableName = this.cbTableNames.GetItemText(this.cbTableNames.SelectedItem);
            string countryName = this.cbCountry.GetItemText(this.cbCountry.SelectedItem); ;
            //CloseAllForm();
            this.Hide();
            frmFilterUpdate fst = new frmFilterUpdate(selectedTableName: tableName, selectedDBName: dbName, selectedCountryName: countryName);
            fst.Closed += (s, args) => this.Close();
            fst.Show();
        }

        private void frmChooseTableForUpd_Load(object sender, EventArgs e)
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
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Senndy" + (dbName).Replace(" ", String.Empty) + ".mdf; Integrated Security = true;cc Connection Timeout=30; ";
            string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename="+System.IO.Path.GetFullPath("Senndy"+ (dbName).Replace(" Media", String.Empty)+ ".mdf")+"; Integrated Security = true; Connection Timeout=30; ";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Senndy" + (dbName).Replace(" ", String.Empty) +".mdf; Initial Catalog =Senndy" + (dbName).Replace(" ", String.Empty) + "; Integrated Security = true; Connection Timeout=30;";

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
            if (this.cbCategory.SelectedItem != "")
            {

                tableNames = getTableNames(this.cbCategory.GetItemText(this.cbCategory.SelectedItem));
                this.cbTableNames.Items.Clear();
                //this.cbTableNames.SelectedText = "--select--";
                this.cbTableNames.SelectedItem = null;
                this.cbTableNames.Items.AddRange(tableNames.ToArray());

            }
        }

        private void cbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cbCategory.SelectedItem != "")
            {

                tableNames = getTableNames(this.cbCategory.GetItemText(this.cbCategory.SelectedItem));
                this.cbTableNames.Items.Clear();
                this.cbTableNames.SelectedItem = null;
                this.cbTableNames.Items.AddRange(tableNames.ToArray());

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
