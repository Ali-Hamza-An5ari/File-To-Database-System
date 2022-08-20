using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseSys
{
    public partial class frmViewTable : Form
    {
        private String _searchQuery;
        private String _conString;
        private String _tableName;
        private String _category;
        //string conString; = "Data Source = (localDB)\\MSSQLLocalDB; Initial Catalog =Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + "; Integrated Security = true; Connection Timeout=30;";

        public frmViewTable(String searchQuery, String conString, String tableName, String category)
        {

            _searchQuery = searchQuery;
            _conString = conString;
            _tableName = tableName;
            _category = category;
            InitializeComponent();
        }
        public frmViewTable()
        {
            InitializeComponent();
        }

        private void frmViewTable_Load(object sender, EventArgs e)
        {
            this.lblTableName.Text = "Table: "+_tableName+" | Category: "+_category;
            getTableDataToDataGridView();
        }
        private void getTableDataToDataGridView()
        {
            SqlConnection connection = new SqlConnection(_conString);
            SqlCommand cmd = new SqlCommand(_searchQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];
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
