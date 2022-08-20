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
    public partial class frmFilterUpdate : Form
    {

        private String _selectedTableName;
        private String _selectedDBName;
        private String _selectedCountryName;
        private int _totalColumnsInSelectedTable;
        private Dictionary<String, String> columnsTypeMapper;
        private string targetColumnName;
        private string targetColumnCurrentValue;
        private string targetColumnNewValue;
        DataTable schema;
        public frmFilterUpdate(String selectedTableName, String selectedDBName, String selectedCountryName)
        {
            _selectedTableName = selectedTableName;
            _selectedDBName = selectedDBName;
            _selectedCountryName = selectedCountryName;
            columnsTypeMapper = new Dictionary<string, string>();
            InitializeComponent();
        }
        public frmFilterUpdate()
        {

            //labelTextBoxMappers = new List<LabelTextBoxMapper>();
            columnsTypeMapper = new Dictionary<string, string>();
            InitializeComponent();
        }

        private void frmFilterUpdate_Load(object sender, EventArgs e)
        {
            getColumnsDetails();
            foreach (KeyValuePair<string, string> col in columnsTypeMapper)
            {
                this.cbCol1.Items.Add(col.Key);
            }
            this.lblTableName.Text = _selectedTableName;
        }

        private void btnUpdTable_Click(object sender, EventArgs e)
        {
            targetColumnName = this.cbCol1.GetItemText(this.cbCol1.SelectedItem);
            targetColumnCurrentValue = this.txtCurrentValue.Text;
            targetColumnNewValue = this.txtNewValue.Text;

            //bool isFilteredApplied = false;
            String updateQuery = "UPDATE " + _selectedTableName + " SET ";
           // int i = 0;


                //isFilteredApplied = true;
                if (columnsTypeMapper[targetColumnName].Equals("int"))
                {
                    updateQuery += targetColumnName + " = " + Convert.ToInt32(targetColumnNewValue);
                    updateQuery += " WHERE " + targetColumnName + "= " + Convert.ToInt32(targetColumnCurrentValue);
                }
                else if (columnsTypeMapper[targetColumnName].Equals("tinyint"))
                {
                    updateQuery += targetColumnName + " = " + Convert.ToByte(targetColumnNewValue);
                    updateQuery += " WHERE " + targetColumnName + "= " + Convert.ToByte(targetColumnCurrentValue);
                }
                else if (columnsTypeMapper[targetColumnName].Equals("smallint"))
                {
                    updateQuery += targetColumnName + " = " + Convert.ToInt16(targetColumnNewValue);
                    updateQuery += " WHERE " + targetColumnName + "= " + Convert.ToInt16(targetColumnCurrentValue);

                }
                else if (columnsTypeMapper[targetColumnName].Equals("float"))
                {
                    updateQuery += targetColumnName + " = " + Convert.ToDouble(targetColumnNewValue);
                    updateQuery += " WHERE " + targetColumnName + "= " + Convert.ToDouble(targetColumnCurrentValue);
                }
                else if (columnsTypeMapper[targetColumnName].Equals("bit"))
                {
                    updateQuery += targetColumnName + " = " + Convert.ToBoolean(targetColumnNewValue);
                    updateQuery += " WHERE " + targetColumnName + "= " + Convert.ToBoolean(targetColumnCurrentValue);
                }
                else
                {
                    updateQuery += targetColumnName + " = '" + targetColumnNewValue + "' WHERE " + targetColumnName + "= '"+ targetColumnCurrentValue+"' ";
                }
                updateQuery += ";";

                string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" Media", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
                //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
                //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf; Integrated Security = true; Connection Timeout=30;";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery))
                    {
                        cmd.Connection = con;
                        con.Open();
                        int eQResult = cmd.ExecuteNonQuery();
                        con.Close();
                        if(eQResult > 0)
                        {
                            MessageBox.Show("Table records Updated");
                        }
                    }
                }
          }
                private void getColumnsDetails()
        {

            string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" Media", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf; Integrated Security = true; Connection Timeout=30;";

            using (var con = new SqlConnection(conString))
            {
                using (var schemaCommand = new SqlCommand("SELECT * FROM " + _selectedTableName + " ;", con))
                {
                    con.Open();
                    using (var reader = schemaCommand.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        schema = reader.GetSchemaTable();
                    }
                    con.Close();
                    //Console.WriteLine(schema.Rows[2]);
                }

            }
            foreach (DataRow col in schema.Rows)
            {
                string curColName = col.Field<String>("ColumnName");
                string curDataTypeName = col.Field<string>("DataTypeName");
                if (!(curColName.Equals("dataSource") || curColName.Equals("DataBaseCountry")))
                {
                    columnsTypeMapper.Add(curColName, curDataTypeName);

                }
                //MessageBox.Show(col.Field<String>("ColumnName"));
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChooseTableForUpd fCtU = new frmChooseTableForUpd();
            fCtU.Closed += (s, args) => this.Close();
            fCtU.Show();
        }

        private void cbCol1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
