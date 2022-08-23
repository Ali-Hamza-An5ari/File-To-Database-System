using IronXL;
using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using CsvHelper;
using System.Globalization;


namespace DatabaseSys
{
    public partial class frmTableOptions : Form
    {
        private string[] columnsToWrite;
        public static List<string> finalColumns;
        public static List<int> finalColumnsIndices;
        Dictionary<string, string> columnToTypeMapper;
        Dictionary<string, string> dataTypeMapper;
        string conString = "";
        private int index;
        private SqlCommand cmd2;
        string insrtQuery;
        public frmTableOptions()
        {
            InitializeComponent();
        }

        private void frmTableOptions_Load(object sender, EventArgs e)
        {
            
            columnsToWrite = new string[frmCatForSelect.coulmnNames.Count];
            finalColumns = new List<string>();
            finalColumnsIndices = new List<int>();
            columnToTypeMapper = new Dictionary<string, string>();
            dataTypeMapper = new Dictionary<string, string>();
            string[] dataTypeAliases = { "Short-text", "Long-text",  "Number", "Decimal", "Age","Date", "DateTime", "Time", "Year", "True-False(1/0)","Money" };
            fillMaps();
            this.cbDataType.Items.AddRange(dataTypeAliases);
            this.cbDataType.SelectedIndex = 0;

            for (int i = 0; i < columnsToWrite.Length; i++)
            {
                columnsToWrite[i] = frmCatForSelect.coulmnNames[i];
                //this.columnToTypeMapper.Add(txtSelectedColName.Text, "Short-text");// this.cbDataType.GetItemText(this.cbDataType.SelectedItem));

            }

            string[] arr = { "a", "b" };
            this.checkedListBox1.Items.AddRange(columnsToWrite);
            //this.
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.txtSelectedColName.Text = checkedListBox1.SelectedItem.ToString();
            index = checkedListBox1.SelectedIndex;
            //this.txtSelectedColName.Text = checkedListBox1.Items[index].ToString();
            //this.txtSelectedColName.Text = checkedListBox1.Items[index].ToString();

            //to check if the item returned on indexChanged not null
            if (checkedListBox1.SelectedItem!=null)
            {

                this.txtSelectedColName.Text = checkedListBox1.SelectedItem.ToString();
            }
        }

        private void btnChColN_Click(object sender, EventArgs e)
        {
            //
            this.checkedListBox1.Items.Insert(index, txtSelectedColName.Text);
            this.checkedListBox1.Items.Remove(checkedListBox1.Items[checkedListBox1.Items.IndexOf(txtSelectedColName.Text)+1]);
            if(columnToTypeMapper.ContainsKey(txtSelectedColName.Text))
            {
                columnToTypeMapper[txtSelectedColName.Text] = this.cbDataType.GetItemText(this.cbDataType.SelectedItem);
            }
            else
            {
                this.columnToTypeMapper.Add(txtSelectedColName.Text, this.cbDataType.GetItemText(this.cbDataType.SelectedItem));
            }
        }

        private void btnCrTable_Click(object sender, EventArgs e)
        {
            
            for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
            {
                finalColumns.Add(checkedListBox1.CheckedItems[x].ToString());
                finalColumnsIndices.Add(checkedListBox1.CheckedIndices[x]);

                //MessageBox.Show(checkedListBox1.CheckedIndices[x].ToString() +", "+ columnToTypeMapper[checkedListBox1.CheckedItems[x].ToString()]);

            }
            saveFileDataToDatabase();

        }

        public void saveFileDataToDatabase()
        {
            string tableName = this.txtTableforDb.Text;
            //conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (frmCatForSelect.category).Replace(" ", String.Empty) + ".mdf; Initial Catalog =Senndy" + (frmCatForSelect.category).Replace(" ",String.Empty)+ "; Integrated Security = true; Connection Timeout=30;";
            conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=" + System.IO.Path.GetFullPath("Senndy" + (frmCatForSelect.category).Replace(" Media", String.Empty) + ".mdf") + "; Integrated Security = true; Connection Timeout=30;";
            //conString = "Data Source = (localDB)\\MSSQLLocalDB;  AttachDbFilename=|DataDirectory|\\Senndy" + (frmCatForSelect.category).Replace(" ", String.Empty) + ".mdf; Integrated Security = true; Connection Timeout=30;";
           

            string query = "IF OBJECT_ID('dbo."+tableName+"', 'U') IS NULL ";
            query += "BEGIN ";
            query += "CREATE TABLE [dbo].["+ tableName + "](";
            query += "["+tableName+"Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT pk"+tableName+"Id PRIMARY KEY,";
            foreach(var c in finalColumns)
            {
                query += "["+c.Replace(" ","_")+"] "+ dataTypeMapper[columnToTypeMapper[c]]+" , ";
            }
            query += "[createdAt] DATETIME NOT NULL, ";
            query += "[DataBaseCountry] VARCHAR(50) NOT NULL, ";
            query += "[dataSource] VARCHAR(50)  NOT NULL ";
            query += ")";
            query += " END";

            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //to check whether the Table is already created or not
                    DataTable dTable = con.GetSchema("TABLES", new string[] { null, null, tableName });
                    if(dTable.Rows.Count == 0)
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();


                        con.Open();
                        cmd2 = con.CreateCommand();
                        //preparing insert query

                        insrtQuery = " INSERT INTO "+tableName+" ";
                        insrtQuery += "( ";
                            for (int lcv = 0;  lcv < finalColumns.Count; lcv++)
                            {
                                //insrtQuery += "`"+finalColumns[lcv]+"`, ";
                                insrtQuery += ""+finalColumns[lcv].Replace(" ", "_") + ", ";
                            }
                            insrtQuery += " createdAt, DataBaseCountry, dataSource ) ";
                            insrtQuery += "VALUES ";
                            //insrtQuery += "( ";
                        
                        //for(int lcv = 0; lcv < finalColumns.Count; lcv++)
                        //{
                        //    insrtQuery += "@" + finalColumns[lcv].Replace(" ", "_") + ", ";
                        //}

                        //insrtQuery += " @createdAt, @DataBaseCountry, @dataSource ),(";
                        //insrtQuery += "'" + DateTime.Now + "', '" + frmCatForSelect.country + "', '" + frmCatForSelect.fileSource + "' ),(";

                        //insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
                        //insrtQuery += ";";


                        //Writing records
                        if (frmCatForSelect.selectedFormat.Equals("CSV"))
                        {

                            string currentLine;
                            List<dynamic> records;
                            List<string> myStringColumn = new List<string>();

                            using (var streamReader = new StreamReader(frmCatForSelect.filename))
                            {
                                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                                {
                                    records = csvReader.GetRecords<dynamic>().ToList();
                                }
                            }

                            if (records.Count > 1000)
                            {
                                int colCount = 0;
                                for (colCount = 0; colCount < records.Count; colCount += 800)
                                {
                                    if (colCount + 800 < records.Count)
                                    {
                                        writeCSVToDatabase( colCount, colCount + 800);
                                    }

                                }
                                if (colCount < records.Count - 1)
                                {

                                    writeCSVToDatabase( colCount, records.Count);
                                }
                            }
                            else
                            {
                                writeCSVToDatabase( 0, records.Count);
                            }



                        }
                        else if (frmCatForSelect.selectedFormat.Equals("Excel"))
                        {
                            //writeExcelToDatabase(insrtQuery, 0, 100);

                            MessageBox.Show(frmCatForSelect.selectedFormat+" "+frmCatForSelect.filename);
                            Excel.Application xlApp;
                            Excel.Workbook xlWorkBook;
                            Excel.Worksheet xlWorkSheet;
                            Excel.Range range;

                           
                            int totalRowsInExcel = 0;
                            

                            xlApp = new Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Open(frmCatForSelect.filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            range = xlWorkSheet.UsedRange;
                            totalRowsInExcel = range.Rows.Count+1;
                            
                            xlWorkBook.Close(true, null, null);
                            xlApp.Quit();
                            if (totalRowsInExcel > 1000)
                            {
                                int colCount;
                                for (colCount = 2; colCount < totalRowsInExcel; colCount += 800)
                                {
                                    if (colCount + 800 < totalRowsInExcel)
                                    {
                                        writeExcelToDatabase(insrtQuery, colCount, colCount + 800);
                                    }

                                }
                                if (colCount < totalRowsInExcel - 1)
                                {

                                    writeExcelToDatabase(insrtQuery, colCount, totalRowsInExcel);
                                }
                            }
                            else
                            {
                                writeExcelToDatabase(insrtQuery, 2, totalRowsInExcel);

                            }


                        }
                        else
                        {
                            using (StreamReader file = new StreamReader(frmCatForSelect.filename))
                            {
                                int totalLinesInTxt = File.ReadAllLines(frmCatForSelect.filename).Length;
                                if (totalLinesInTxt > 1000)
                                {
                                    int colCount = 0;
                                    for (colCount = 0; colCount < totalLinesInTxt; colCount += 800)
                                    {
                                        if (colCount + 800 < totalLinesInTxt)
                                        {
                                            writeTXTToDatabase(insrtQuery, colCount, colCount + 800);
                                        }
                                       
                                    }
                                    if (colCount < totalLinesInTxt-1)
                                    {

                                        writeTXTToDatabase(insrtQuery, colCount, totalLinesInTxt);
                                    }
                                }
                                else
                                {
                                    writeTXTToDatabase(insrtQuery, 0, totalLinesInTxt);

                                }
                               
                            }
                        }


                        //insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
                        //insrtQuery += ";";
                        cmd2.CommandText = insrtQuery.Substring(0, insrtQuery.Length - 1)+";";
                        int execQreturn = cmd2.ExecuteNonQuery();
                        con.Close();
                        if (execQreturn == -1)
                        {
                            MessageBox.Show("Table creation failed. Make sure you have given the table names and selected appropriate column types. Or the file may have data in inappropriate form");

                        }
                        else
                        {
                            MessageBox.Show("Table created Successfully with all the records");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The table "+tableName+" already Exists.");
                    }
                }
            }

        }
        private void writeExcelToDatabase(string insrtQuery, int initial, int last)
        {

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

            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;


            using (SqlConnection con = new SqlConnection(conString))
            {

                for (rCnt = initial; rCnt < last; rCnt++)
                {
                    int fColInd = 0;
                   
                    //getting all the columns selected by user. it allows to get records of Only the selected columns like 0 2 8
                    for (int ind = 0; ind < finalColumnsIndices.Count; ind++)
                    {
                        //getting the type of current column from datatypemapper to check if '' is needed if the type is set to non number.
                        string currentColType = dataTypeMapper[columnToTypeMapper[finalColumns[fColInd]]];

                        if (isOfIntType(currentColType))
                        {
                            //MessageBox.Show((range.Cells[rCnt, finalColumnsIndices[ind]] as Excel.Range).Value2.ToString());

                            if (currentColType.Equals("INT"))
                            {
                                if ((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2 == null)
                                {
                                    insrtQuery += 0 + ", ";
                                }
                                else
                                {
                                    int curIntVal = Convert.ToInt32((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2);
                                    insrtQuery += curIntVal + ", ";
                                }

                            }
                            else if (currentColType.Equals("FLOAT"))
                            {
                                if ((range.Cells[rCnt+2, finalColumnsIndices[ind]+1] as Excel.Range).Value2 == null)
                                {
                                    insrtQuery += 0 + ", ";
                                }
                                else
                                {
                                    //MessageBox.Show((range.Cells[rCnt+2, finalColumnsIndices[ind]+1] as Excel.Range).Value2.ToString());
                                    double curIntVal = Convert.ToDouble((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2);
                                    insrtQuery += curIntVal + ", ";
                                }
                            }
                            else if (currentColType.Equals("TINYINT"))
                            {
                                if ((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2 == null)
                                {
                                    insrtQuery += 0 + ", ";
                                }
                                else
                                {
                                    Byte curIntVal = Convert.ToByte((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2);
                                    insrtQuery += curIntVal + ", ";
                                }
                            }
                            else if (currentColType.Equals("BIT"))
                            {
                                if ((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2 == null)
                                {
                                    insrtQuery += 0 + ", ";
                                }
                                else
                                {
                                    Boolean curIntVal = Convert.ToBoolean((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2);
                                    insrtQuery += curIntVal + ", ";
                                }
                            }
                            else //if (currentColType.Equals("SMALLINT"))
                            {
                                if ((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2 == null)
                                {
                                    insrtQuery += 0 + ", ";
                                }
                                else
                                {
                                    int curIntVal = Convert.ToInt16((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2);
                                    insrtQuery += curIntVal + ", ";
                                }
                            }
                        }
                        else
                        {
                            if ((range.Cells[rCnt + 2, finalColumnsIndices[ind] + 1] as Excel.Range).Value2 == null)
                            {

                                insrtQuery += "'', ";
                            }
                            else
                            {
                                string currentColumnValue = (range.Cells[rCnt + 2, finalColumnsIndices[ind]+1] as Excel.Range).Value2.ToString();
                                Regex punctuationCharacters = new Regex(@"[,'`]");

                                //check if punctuation replace needed in the data
                                if (punctuationCharacters.IsMatch(currentColumnValue))
                                {
                                    MatchCollection mCol = punctuationCharacters.Matches(currentColumnValue);
                                    String puncReplaced = "";
                                    foreach (Match mat in mCol)
                                    {
                                        puncReplaced = punctuationCharacters.Replace(currentColumnValue, "\\" + mat.Value);
                                    }
                                    insrtQuery += "'" + puncReplaced + "', ";
                                }
                                else
                                {
                                    insrtQuery += "' " + currentColumnValue + "', ";
                                }
                            }
                        }
                        fColInd++;
                    }
                    insrtQuery += "'" + DateTime.Now + "', '" + frmCatForSelect.country + "', '" + frmCatForSelect.fileSource + "' ),(";

                }


                //for (rCnt = initial; rCnt < last; rCnt++)
                //{
                //    for (cCnt = 1; cCnt <= cl; cCnt++)
                //    {

                //        var v = (range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                //        if (v != null)
                //        {
                //            MessageBox.Show(v.ToString());
                //        }
                //    }
                //}

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
                insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
                insrtQuery += ";";
                SqlCommand cmd2 = new SqlCommand(insrtQuery);
                cmd2.Connection = con;
                con.Open();
                int execQreturn = cmd2.ExecuteNonQuery();
                con.Close();
                if (execQreturn == -1)
                {
                    MessageBox.Show("Table creation failed. Make sure you have given the table names and selected appropriate column types. Or the file may have data in inappropriate form");

                }
                else
                {
                    MessageBox.Show("Table created Successfully with all the records");
                }
            }
        }
        private void writeCSVToDatabase( int initial, int last)
        {

            //var csvFilereader = new DataTable();
            //csvFilereader = ReadExcel();


            //using (SqlConnection con = new SqlConnection(conString))
            //{
                using (var fileReader = File.OpenText(frmCatForSelect.filename))
                {
                    using (var csvResult = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                    {

                        csvResult.Read();

                        object currentValue;
                        //Iterate over rows
                        for (int i = initial; i < last; i++)
                        {
                            int fColInd = 0;
                            if (csvResult != null)
                            {
                                insrtQuery += "( ";

                                for (int lcv = 0; lcv < finalColumns.Count; lcv++)
                                {
                                    insrtQuery += "@" + finalColumns[lcv].Replace(" ", "_") + i+", ";
                                }

                                insrtQuery += " @createdAt"+i+ ", @DataBaseCountry" + i+ ", @dataSource" + i + " ),";
                                //insrtQuery += " @createdAt"+i+ ", @DataBaseCountry" + i+ ", @dataSource" + i + " ),(";
                            //Move one row 
                            csvResult.Read();


                                //getting all the columns selected by user. it allows to get records of Only the selected columns like 0 2 8
                                for (int ind = 0; ind < finalColumnsIndices.Count; ind++)
                                {
                                    //getting the type of current column from datatypemapper to check if '' is needed if the type is set to non number.
                                    string currentColType = dataTypeMapper[columnToTypeMapper[finalColumns[fColInd]]];
                                    string currentColName = finalColumns[fColInd].Replace(" ", "_");
                                    if (frmCatForSelect.isDelimiteredFile)
                                    {
                                        string[] delimiterSplittedValues = csvResult.GetField<string>(0).Split('|');
                                        currentValue = delimiterSplittedValues[finalColumnsIndices[ind]];
                                        
                                    }
                                    else
                                    {
                                        currentValue = csvResult.GetField<string>(finalColumnsIndices[ind]);
                                    }

                                    if (isOfIntType(currentColType))
                                    {
                                        
                                        if (currentColType.Equals("INT"))
                                        {
                                            if (currentValue.ToString() == "")
                                            {
                                            //insrtQuery += 0 + ", ";

                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", 0);
                                            }
                                            else
                                            {
                                                int curIntVal = Convert.ToInt32(currentValue);
                                                
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "",curIntVal);
                                                //cmd2.Paraters.AddWithValue()
                                                //insrtQuery += curIntVal + ", ";
                                            }

                                        }
                                        else if (currentColType.Equals("FLOAT"))
                                        {
                                            if (currentValue.ToString() == "")
                                            {
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", 0);
                                            }
                                            else
                                            {
                                                double curIntVal = Convert.ToDouble(currentValue);
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", curIntVal);
                                            }
                                        }
                                        else if (currentColType.Equals("TINYINT"))
                                        {
                                            if (currentValue.ToString() == "")
                                            {
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", 0);
                                            }
                                        else
                                            {
                                                Byte curIntVal = Convert.ToByte(currentValue);
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", curIntVal);
                                            }
                                        }
                                        else if (currentColType.Equals("BIT"))
                                        {
                                            if (currentValue.ToString() == "")
                                            {
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", 0);
                                            }
                                            else
                                            {
                                                Boolean curIntVal = Convert.ToBoolean(currentValue);
                                                cmd2.Parameters.AddWithValue("@" + currentColName + "", curIntVal);
                                            }
                                        }
                                        else //if (currentColType.Equals("SMALLINT"))
                                        {
                                            if (currentValue.ToString() == "")
                                            {
                                                currentColName = "@" + currentColName;
                                                cmd2.Parameters.AddWithValue( currentColName, 0);
                                            }
                                            else
                                            {
                                                int curIntVal = Convert.ToInt16(currentValue);
                                                currentColName = "@" + currentColName;
                                                cmd2.Parameters.AddWithValue(currentColName, curIntVal);

                                            }
                                        }
                                    }
                                    else
                                    {
                                        string currentColumnValue = currentValue.ToString();
                                    //currentColName = "@" + currentColName;

                                        cmd2.Parameters.Add(new SqlParameter(currentColName + i, currentColumnValue));
                                        //cmd2.Parameters[currentColName].Value =  "tv";
                                        //cmd2.Parameters.AddWithValue(currentColName, "tv");



                                    ////string currentColumnValue = csvResult.GetField<string>(finalColumnsIndices[ind]).ToString();
                                    //Regex punctuationCharacters = new Regex(@"[,'`]");

                                    ////check if punctuation replace needed in the data
                                    //if (punctuationCharacters.IsMatch(currentColumnValue))
                                    //{
                                    //    MatchCollection mCol = punctuationCharacters.Matches(currentColumnValue);
                                    //    String puncReplaced = "";
                                    //    foreach (Match mat in mCol)
                                    //    {

                                    //        puncReplaced = punctuationCharacters.Replace(currentColumnValue, "\\" + mat.Value);
                                    //    }
                                    //    insrtQuery += "'" + puncReplaced + "', ";
                                    //}
                                    //else
                                    //{
                                    //    insrtQuery += "' " + currentColumnValue + "', ";
                                    //}

                                }
                                    fColInd++;
                                    /////////////////////
                                    //    if (currentColType.Equals("INT"))
                                    //    {
                                    //        if (csvResult.GetField<string>(finalColumnsIndices[ind]).ToString() == "")
                                    //        {
                                    //            insrtQuery += 0 + ", ";
                                    //        }
                                    //        else
                                    //        {
                                    //            int curIntVal = Convert.ToInt32(csvResult.GetField<string>(finalColumnsIndices[ind]));
                                    //            insrtQuery += curIntVal + ", ";
                                    //        }

                                    //    }
                                    //    else if (currentColType.Equals("FLOAT"))
                                    //    {
                                    //        if (csvResult.GetField<string>(finalColumnsIndices[ind]).ToString() == "")
                                    //        {
                                    //            insrtQuery += 0 + ", ";
                                    //        }
                                    //        else
                                    //        {
                                    //            double curIntVal = Convert.ToDouble(csvResult.GetField<string>(finalColumnsIndices[ind]));
                                    //            insrtQuery += curIntVal + ", ";
                                    //        }
                                    //    }
                                    //    else if (currentColType.Equals("TINYINT"))
                                    //    {
                                    //        if (csvResult.GetField<string>(finalColumnsIndices[ind]).ToString() == "")
                                    //        {
                                    //            insrtQuery += 0 + ", ";
                                    //        }
                                    //        else
                                    //        {
                                    //            Byte curIntVal = Convert.ToByte(csvResult.GetField<string>(finalColumnsIndices[ind]));
                                    //            insrtQuery += curIntVal + ", ";
                                    //        }
                                    //    }
                                    //    else if (currentColType.Equals("BIT"))
                                    //    {
                                    //        if (csvResult.GetField<string>(finalColumnsIndices[ind]).ToString() == "")
                                    //        {
                                    //            insrtQuery += 0 + ", ";
                                    //        }
                                    //        else
                                    //        {
                                    //            Boolean curIntVal = Convert.ToBoolean(csvResult.GetField<string>(finalColumnsIndices[ind]));
                                    //            insrtQuery += curIntVal + ", ";
                                    //        }
                                    //    }
                                    //    else //if (currentColType.Equals("SMALLINT"))
                                    //    {
                                    //        if (csvResult.GetField<string>(finalColumnsIndices[ind]).ToString() == "")
                                    //        {
                                    //            insrtQuery += 0 + ", ";
                                    //        }
                                    //        else
                                    //        {
                                    //            int curIntVal = Convert.ToInt16(csvResult.GetField<string>(finalColumnsIndices[ind]));
                                    //            insrtQuery += curIntVal + ", ";
                                    //        }
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    string currentColumnValue = csvResult.GetField<string>(finalColumnsIndices[ind]).ToString();
                                    //    Regex punctuationCharacters = new Regex(@"[,'`]");

                                    //    //check if punctuation replace needed in the data
                                    //    if (punctuationCharacters.IsMatch(currentColumnValue))
                                    //    {
                                    //        MatchCollection mCol = punctuationCharacters.Matches(currentColumnValue);
                                    //        String puncReplaced = "";
                                    //        foreach (Match mat in mCol)
                                    //        {

                                    //            puncReplaced = punctuationCharacters.Replace(currentColumnValue, "\\" + mat.Value);
                                    //        }
                                    //        insrtQuery += "'" + puncReplaced + "', ";
                                    //    }
                                    //    else
                                    //    {
                                    //        insrtQuery += "' " + currentColumnValue + "', ";
                                    //    }

                                    //}
                                    //fColInd++;
                                }
                            //insrtQuery += "'" + DateTime.Now + "', '" + frmCatForSelect.country + "', '" + frmCatForSelect.fileSource + "' ),(";
                            //insrtQuery += "'" + DateTime.Now + "', '" + frmCatForSelect.country + "', '" + frmCatForSelect.fileSource + "' ),(";

                            //cmd2.Parameters["@createdAt"].Value = DateTime.Now;
                            //cmd2.Parameters["@DataBaseCountry"].Value = frmCatForSelect.country;
                            //cmd2.Parameters["@dataSource"].Value = frmCatForSelect.fileSource;

                            //cmd2.Parameters.AddWithValue("@createdAt",DateTime.Now);
                            //cmd2.Parameters.AddWithValue("@DataBaseCountry",frmCatForSelect.country);
                            //cmd2.Parameters.AddWithValue("@dataSource",frmCatForSelect.fileSource);

                            cmd2.Parameters.Add(new SqlParameter("createdAt" + i, DateTime.Now));
                            cmd2.Parameters.Add(new SqlParameter("DataBaseCountry" + i, frmCatForSelect.country));
                            cmd2.Parameters.Add(new SqlParameter("dataSource" + i, frmCatForSelect.fileSource));


                            }
                        }

                    //insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
                    //insrtQuery += ";";
                    //MessageBox.Show("count: " + records.Count.ToString());
                    }
                }
            //insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
            //insrtQuery += ";";
            //SqlCommand cmd2 = new SqlCommand(*insrtQuery);
            //cmd2.Connection = con;
            //con.Open();

            //}
        }

        private void writeTXTToDatabase(String insrtQuery, int initial, int last)
        {
            using (StreamReader file = new StreamReader(frmCatForSelect.filename))
            {

                string ln = file.ReadLine();
                char[] whitespace = new char[] { ' ', '\t' };
                using (SqlConnection con = new SqlConnection(conString))
                {
                    for (int i = initial; i < last; i++)
                    {
                        
                        int fColInd = 0;

                        ln = file.ReadLine();
                        if(ln !=null)
                        {
                            string[] values = ln.Split(whitespace);
                            //getting all the columns selected by user. it allows to get records of Only the selected columns like 0 2 8
                            for (int ind = 0; ind < finalColumnsIndices.Count; ind++)
                            {
                                //getting the type of current column from datatypemapper to check if '' is needed if the type is set to non number.

                                string currentColType = dataTypeMapper[columnToTypeMapper[finalColumns[ind]]];

                                if (isOfIntType(currentColType))
                                {

                                    if (currentColType.Equals("INT"))
                                    {
                                        if (values[finalColumnsIndices[i]].ToString() == "")
                                        {
                                            insrtQuery += 0 + ", ";
                                        }
                                        else
                                        {
                                            int curIntVal = Convert.ToInt32(values[finalColumnsIndices[i]]);
                                            insrtQuery += curIntVal + ", ";
                                        }

                                    }
                                    else if (currentColType.Equals("FLOAT"))
                                    {
                                        if (values[finalColumnsIndices[i]].ToString() == "")
                                        {
                                            insrtQuery += 0 + ", ";
                                        }
                                        else
                                        {
                                            double curIntVal = Convert.ToDouble(values[finalColumnsIndices[i]]);
                                            insrtQuery += curIntVal + ", ";
                                        }
                                    }
                                    else if (currentColType.Equals("TINYINT"))
                                    {
                                        if (values[finalColumnsIndices[i]].ToString() == "")
                                        {
                                            insrtQuery += 0 + ", ";
                                        }
                                        else
                                        {
                                            Byte curIntVal = Convert.ToByte(values[finalColumnsIndices[i]]);
                                            insrtQuery += curIntVal + ", ";
                                        }
                                    }
                                    else if (currentColType.Equals("BIT"))
                                    {
                                        if (values[finalColumnsIndices[i]].ToString() == "")
                                        {
                                            insrtQuery += 0 + ", ";
                                        }
                                        else
                                        {
                                            Boolean curIntVal = Convert.ToBoolean(values[finalColumnsIndices[i]]);
                                            insrtQuery += curIntVal + ", ";
                                        }
                                    }
                                    else //if (currentColType.Equals("SMALLINT"))
                                    {
                                        if (values[finalColumnsIndices[i]].ToString() == "")
                                        {
                                            insrtQuery += 0 + ", ";
                                        }
                                        else
                                        {
                                            int curIntVal = Convert.ToInt16(values[finalColumnsIndices[i]]);
                                            insrtQuery += curIntVal + ", ";
                                        }
                                    }

                                }
                                else
                                {
                                    string currentColumnValue = values[finalColumnsIndices[ind]];
                                    Regex punctuationCharacters = new Regex(@"[,'`]");

                                    //check if punctuation replace needed in the data
                                    if (punctuationCharacters.IsMatch(currentColumnValue))
                                    {
                                        MatchCollection mCol = punctuationCharacters.Matches(currentColumnValue);
                                        String puncReplaced = "";
                                        foreach (Match mat in mCol)
                                        {
                                            puncReplaced = punctuationCharacters.Replace(currentColumnValue, "\\" + mat.Value);
                                        }
                                        insrtQuery += "'" + puncReplaced + "', ";
                                    }
                                    else
                                    {
                                        insrtQuery += "' " + currentColumnValue + "', ";
                                    }

                                }
                                fColInd++;
                            }
                            insrtQuery += "'" + DateTime.Now + "', '" + frmCatForSelect.country + "', '" + frmCatForSelect.fileSource + "' ),(";


                        }

                    }
                    insrtQuery = insrtQuery.Remove(insrtQuery.Length - 2);
                    insrtQuery += ";";
                    SqlCommand cmd2 = new SqlCommand(insrtQuery);
                    cmd2.Connection = con;
                    con.Open();
                    int execQreturn = cmd2.ExecuteNonQuery();
                    con.Close();
                    if (execQreturn == -1)
                    {
                        MessageBox.Show("Table creation failed. Make sure you have given the table names and selected appropriate column types. Or the file may have data in inappropriate form");

                    }
                    else
                    {
                        MessageBox.Show("Table created Successfully with all the records");
                    }
                }
                file.Close();
            }
        }
        private DataTable ReadExcel()
        {
            WorkBook workbook = WorkBook.Load(frmCatForSelect.filename);
            WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable(true);
        }
        private void fillMaps()
        {

            
            dataTypeMapper.Add("Short-text", "VARCHAR(100)");
            dataTypeMapper.Add("Long-text", "VARCHAR(230)");
            dataTypeMapper.Add("Number", "INT");
            dataTypeMapper.Add("Decimal", "FLOAT");
            dataTypeMapper.Add("True-False(1/0)", "BIT");
            dataTypeMapper.Add("Age", "TINYINT");
            dataTypeMapper.Add("Year", "SMALLINT");
            dataTypeMapper.Add("Date", "DATE");
            dataTypeMapper.Add("DateTime", "DATETIME");
            dataTypeMapper.Add("Time", "TIME");
            dataTypeMapper.Add("Money", "MONEY");

        }


        //To select data types for all column bby default to "Short-text". Only checked column will get a datatype
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                string itemText = checkedListBox1.GetItemText(checkedListBox1.Items[e.Index]);
                if(!columnToTypeMapper.ContainsKey(itemText))
                {
                    columnToTypeMapper.Add(itemText, "Short-text");
                }
            }
            else
            {
                string itemText = checkedListBox1.GetItemText(checkedListBox1.Items[e.Index]);
                if (columnToTypeMapper.ContainsKey(itemText))
                {
                    columnToTypeMapper.Remove(itemText);
                }
            }
        }

        //If user select a column and want to change then its datatype will be changed by this method. It only change if it already exists in checked items.
        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (columnToTypeMapper.ContainsKey(txtSelectedColName.Text))
            {
                columnToTypeMapper[txtSelectedColName.Text] = this.cbDataType.GetItemText(this.cbDataType.SelectedItem);
            }
        }
        private bool isOfNumericType(object v)
        {
            Regex regexp = new Regex(@"^[1-9]\d*(\.\d+)?$");
            return(regexp.IsMatch(v.ToString()));

            //return ((v.GetType().Name).Equals("Int32");
        }
        private bool isOfIntType(object v)
        {
            return ((v.ToString().Equals("INT")) || (v.ToString().Equals("FLOAT")) || (v.ToString().Equals("TINYINT")) || (v.ToString().Equals("BIT")) || (v.ToString().Equals("SMALLINT")));
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
/*
System.Data.SqlClient.SqlException: 'A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 52 - Unable to locate a Local Database Runtime installation. Verify that SQL Server Express is properly installed and that the Local Database Runtime feature is enabled.)'
*/