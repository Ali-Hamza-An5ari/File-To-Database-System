using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseSys
{
    public partial class frmDBMS : Form
    {
        public frmDBMS()
        {
            InitializeComponent();
        }

        private void frmDBMS_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            //this.Close();
            this.Hide();
            frmCatForSelect fCfS = new frmCatForSelect();

            fCfS.Closed += (s, args) => this.Close();
            fCfS.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSeachTable fSeachTable = new frmSeachTable();
            fSeachTable.Closed += (s, args) => this.Close();
            fSeachTable.ShowDialog();
        }

        private void btnUpd1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChooseTableForUpd fctU = new frmChooseTableForUpd();

            fctU.Closed += (s, args) => this.Close();
            fctU.ShowDialog();
        }
    }
}
