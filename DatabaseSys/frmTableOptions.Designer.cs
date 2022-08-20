namespace DatabaseSys
{
    partial class frmTableOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableOptions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableforDb = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrTable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectedColName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChColN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 518);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.ForeColor = System.Drawing.Color.Firebrick;
            this.panel2.Location = new System.Drawing.Point(199, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 100);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(288, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Table name for Database";
            // 
            // txtTableforDb
            // 
            this.txtTableforDb.Location = new System.Drawing.Point(518, 123);
            this.txtTableforDb.Name = "txtTableforDb";
            this.txtTableforDb.Size = new System.Drawing.Size(150, 20);
            this.txtTableforDb.TabIndex = 5;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(332, 202);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(345, 169);
            this.checkedListBox1.TabIndex = 6;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(437, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Columns";
            // 
            // btnCrTable
            // 
            this.btnCrTable.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCrTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCrTable.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnCrTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrTable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrTable.Location = new System.Drawing.Point(384, 465);
            this.btnCrTable.Name = "btnCrTable";
            this.btnCrTable.Size = new System.Drawing.Size(192, 46);
            this.btnCrTable.TabIndex = 17;
            this.btnCrTable.Text = "Create Table";
            this.btnCrTable.UseVisualStyleBackColor = false;
            this.btnCrTable.Click += new System.EventHandler(this.btnCrTable_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(266, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Select a Column to change its name: ";
            // 
            // txtSelectedColName
            // 
            this.txtSelectedColName.Location = new System.Drawing.Point(518, 374);
            this.txtSelectedColName.Name = "txtSelectedColName";
            this.txtSelectedColName.Size = new System.Drawing.Size(150, 20);
            this.txtSelectedColName.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(251, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(487, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "____________________________________________________________";
            // 
            // btnChColN
            // 
            this.btnChColN.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnChColN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChColN.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnChColN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChColN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChColN.Location = new System.Drawing.Point(413, 430);
            this.btnChColN.Name = "btnChColN";
            this.btnChColN.Size = new System.Drawing.Size(157, 33);
            this.btnChColN.TabIndex = 22;
            this.btnChColN.Text = "Change Column Name";
            this.btnChColN.UseVisualStyleBackColor = false;
            this.btnChColN.Click += new System.EventHandler(this.btnChColN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(266, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Select the value type for the column: ";
            // 
            // cbDataType
            // 
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Location = new System.Drawing.Point(532, 398);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(136, 21);
            this.cbDataType.TabIndex = 24;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(582, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 46);
            this.button1.TabIndex = 35;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTableOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbDataType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChColN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSelectedColName);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCrTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTableforDb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTableOptions";
            this.Text = "frmTableOptions";
            this.Load += new System.EventHandler(this.frmTableOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableforDb;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectedColName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChColN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Button button1;
    }
}