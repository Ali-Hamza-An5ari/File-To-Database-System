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
    public partial class frmFilterSearchedTable : Form
    {
        //private Dictionary<Label, TextBox> _columnPairs;
        List<LabelTextBoxMapper> labelTextBoxMappers;

        private String _selectedTableName;
        private String _selectedDBName;
        private String _selectedCountryName;
        private int _totalColumnsInSelectedTable;
        
        private Dictionary<String, String> columnsTypeMapper;
        DataTable schema;

        public frmFilterSearchedTable(String selectedTableName, String selectedDBName, String selectedCountryName)
        {
            
            _selectedTableName = selectedTableName;
            _selectedDBName = selectedDBName;
            _selectedCountryName = selectedCountryName;
            //_totalColumnsInSelectedTable = totalColumnsInSelectedTable;
            labelTextBoxMappers = new List<LabelTextBoxMapper>();
            columnsTypeMapper = new Dictionary<string, string>();
            InitializeComponent();
        }
        public frmFilterSearchedTable()
        {

            labelTextBoxMappers = new List<LabelTextBoxMapper>();
            columnsTypeMapper = new Dictionary<string, string>();
            InitializeComponent();
        }

        private void frmFilterSearchedTable_Load(object sender, EventArgs e)
        {

            
            //labelTextBoxMappers = new List<LabelTextBoxMapper>();

            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl1, TextBox = this.tb1 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl2, TextBox = this.tb2 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl3, TextBox = this.tb3 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl4, TextBox = this.tb4 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl5, TextBox = this.tb5 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl6, TextBox = this.tb6 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl7, TextBox = this.tb7 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl8, TextBox = this.tb8 });
            labelTextBoxMappers.Add(new LabelTextBoxMapper { Label = this.lbl9, TextBox = this.tb9 });

            _totalColumnsInSelectedTable = getTotalColumns();

            //schema = schema.Rows.RemoveAt(schema.Rows.Count - 1);
            int i = 0;
            //foreach (string col in columnNamesInSelectedTable)
            foreach(KeyValuePair<string,string> col in columnsTypeMapper)
            {
                //string curColName = col.Field<String>("ColumnName");
                //if(!curColName.Equals("dataSource") && !curColName.Equals("DataBaseCountry"))
                //{
                    //for (int i = 0; i < _totalColumnsInSelectedTable; i++)
                    //{
                    labelTextBoxMappers[i].Label.Visible = true;
                    labelTextBoxMappers[i].TextBox.Visible = true;
                    labelTextBoxMappers[i].Label.Text = col.Key + " : ";

                    // }
                    i++;
                //}
                
            }
        }
        private int getTotalColumns()
        {
            string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" Media", String.Empty) + ".mdf") + ";   Integrated Security = true; Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf;   Integrated Security = true; Connection Timeout=30;";

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
            return (columnsTypeMapper.Count>9)?(9):(columnsTypeMapper.Count);
            //return (schema.Rows.Count>8) ? (8):(schema.Rows.Count);
        }
        class LabelTextBoxMapper
        {
            public Label Label { set; get; }
            public TextBox TextBox { set; get; }
        }

        private void btnSearchWithoutF_Click(object sender, EventArgs e)
        {
            
            String searchQuery = "SELECT * FROM " + _selectedTableName;

            string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" Media", String.Empty) + ".mdf") + ";  Integrated Security = true;  Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf;  Integrated Security = true;  Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf; Initial Catalog =Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + "; Integrated Security = true;  Connection Timeout=30;";
            this.Hide();
            frmViewTable fvt = new frmViewTable(searchQuery, conString,_selectedTableName,_selectedDBName);
            fvt.Closed += (s, args) => this.Close();
            fvt.Show();
        }

        private void btnSearchWithFilters_Click(object sender, EventArgs e)
        {
            bool isFilteredApplied = false;
            String searchQuery = "SELECT * FROM " + _selectedTableName+" WHERE ";
            int i = 0;
            foreach (KeyValuePair<string, string> col in columnsTypeMapper)
            {
                
                if (labelTextBoxMappers[i].TextBox.Text != "")
                {
                    isFilteredApplied = true;
                    if (col.Value.Equals("int")) 
                    {
                        searchQuery += col.Key + " = " + Convert.ToInt32(labelTextBoxMappers[i].TextBox.Text);
                    }
                    else if(col.Value.Equals("tinyint"))
                    {
                        searchQuery += col.Key + " = " + Convert.ToByte(labelTextBoxMappers[i].TextBox.Text);

                    }
                    else if(col.Value.Equals("smallint"))
                    {
                        searchQuery += col.Key + " = " + Convert.ToInt16(labelTextBoxMappers[i].TextBox.Text);

                    }
                    else if(col.Value.Equals("float"))
                    {
                        searchQuery += col.Key + " = " + Convert.ToDouble(labelTextBoxMappers[i].TextBox.Text);
                    }
                    else if(col.Value.Equals("bit"))
                    {
                        searchQuery += col.Key + " = " + Convert.ToBoolean(labelTextBoxMappers[i].TextBox.Text);
                    }
                    else
                    {
                        searchQuery += col.Key + " = '" + labelTextBoxMappers[i].TextBox.Text+"' ";
                    }
                    searchQuery += " AND" ;
                }
                i++;
            }
            if(_selectedCountryName != "")
            {

                searchQuery += " country = '" + _selectedCountryName + "' ";
            }
            else
            {
                searchQuery = searchQuery.Remove(searchQuery.Length - 3);
            }
            //searchQuery += " DataBaseCountry = '" + _selectedCountryName+"' ";
            //searchQuery = searchQuery.Remove(searchQuery.Length - 3);
            if (!isFilteredApplied)
            {
                searchQuery = searchQuery.Replace("WHERE ",String.Empty); //searchQuery.Remove(searchQuery.Length - 6);
            }
            MessageBox.Show(searchQuery);
            searchQuery += ";";

            string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (this._selectedDBName).Replace(" Media", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
            //string conString = "Data Source = (localDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\Senndy" + (this._selectedDBName).Replace(" ", String.Empty) + ".mdf; Integrated Security = true; Connection Timeout=30;";
            this.Hide();
            frmViewTable fvt = new frmViewTable(searchQuery, conString, _selectedTableName, _selectedDBName);
            fvt.Closed += (s, args) => this.Close();
            fvt.Show();

        }
    }
}
