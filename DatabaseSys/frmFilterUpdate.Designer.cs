namespace DatabaseSys
{
    partial class frmFilterUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCol1 = new System.Windows.Forms.ComboBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.btnUpdTable = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(277, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Choose a column to filter ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.ForeColor = System.Drawing.Color.Firebrick;
            this.panel2.Location = new System.Drawing.Point(198, -10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 100);
            this.panel2.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(-1, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 471);
            this.panel1.TabIndex = 16;
            // 
            // cbCol1
            // 
            this.cbCol1.FormattingEnabled = true;
            this.cbCol1.Location = new System.Drawing.Point(518, 151);
            this.cbCol1.Name = "cbCol1";
            this.cbCol1.Size = new System.Drawing.Size(121, 21);
            this.cbCol1.TabIndex = 25;
            this.cbCol1.SelectedIndexChanged += new System.EventHandler(this.cbCol1_SelectedIndexChanged);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.Color.Navy;
            this.lblTableName.Location = new System.Drawing.Point(412, 107);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(27, 20);
            this.lblTableName.TabIndex = 26;
            this.lblTableName.Text = "lbl";
            // 
            // txtCurrentValue
            // 
            this.txtCurrentValue.Location = new System.Drawing.Point(472, 219);
            this.txtCurrentValue.Name = "txtCurrentValue";
            this.txtCurrentValue.Size = new System.Drawing.Size(167, 20);
            this.txtCurrentValue.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(309, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Current Value: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(309, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "New Value: ";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(472, 258);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(167, 20);
            this.txtNewValue.TabIndex = 31;
            // 
            // btnUpdTable
            // 
            this.btnUpdTable.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUpdTable.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnUpdTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdTable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdTable.Location = new System.Drawing.Point(349, 335);
            this.btnUpdTable.Name = "btnUpdTable";
            this.btnUpdTable.Size = new System.Drawing.Size(192, 46);
            this.btnUpdTable.TabIndex = 33;
            this.btnUpdTable.Text = "Update Table";
            this.btnUpdTable.UseVisualStyleBackColor = false;
            this.btnUpdTable.Click += new System.EventHandler(this.btnUpdTable_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(547, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 46);
            this.button1.TabIndex = 34;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmFilterUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCurrentValue);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.cbCol1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmFilterUpdate";
            this.Text = "frmFilterUpdate";
            this.Load += new System.EventHandler(this.frmFilterUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbCol1;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtCurrentValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Button btnUpdTable;
        private System.Windows.Forms.Button button1;
    }
}