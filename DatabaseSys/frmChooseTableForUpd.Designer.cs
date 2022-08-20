namespace DatabaseSys
{
    partial class frmChooseTableForUpd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseTableForUpd));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTableNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchTableU = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackfromView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.ForeColor = System.Drawing.Color.Firebrick;
            this.panel2.Location = new System.Drawing.Point(198, -10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 100);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(-1, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 471);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(338, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "*You must choose a Category before selecting a table";
            // 
            // cbTableNames
            // 
            this.cbTableNames.FormattingEnabled = true;
            this.cbTableNames.Location = new System.Drawing.Point(543, 233);
            this.cbTableNames.Name = "cbTableNames";
            this.cbTableNames.Size = new System.Drawing.Size(121, 21);
            this.cbTableNames.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(348, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Select Table Name";
            // 
            // btnSearchTableU
            // 
            this.btnSearchTableU.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSearchTableU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchTableU.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnSearchTableU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTableU.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchTableU.Location = new System.Drawing.Point(379, 362);
            this.btnSearchTableU.Name = "btnSearchTableU";
            this.btnSearchTableU.Size = new System.Drawing.Size(192, 46);
            this.btnSearchTableU.TabIndex = 28;
            this.btnSearchTableU.Text = "Search Table";
            this.btnSearchTableU.UseVisualStyleBackColor = false;
            this.btnSearchTableU.Click += new System.EventHandler(this.btnSearchTableU_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(419, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 27;
            this.label3.Text = "Update Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(349, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Country";
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(544, 282);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 25;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(544, 183);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 24;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(349, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Choose a Category  ";
            // 
            // btnBackfromView
            // 
            this.btnBackfromView.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBackfromView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBackfromView.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnBackfromView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackfromView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBackfromView.Location = new System.Drawing.Point(577, 362);
            this.btnBackfromView.Name = "btnBackfromView";
            this.btnBackfromView.Size = new System.Drawing.Size(100, 46);
            this.btnBackfromView.TabIndex = 32;
            this.btnBackfromView.Text = "Back";
            this.btnBackfromView.UseVisualStyleBackColor = false;
            this.btnBackfromView.Click += new System.EventHandler(this.btnBackfromView_Click);
            // 
            // frmChooseTableForUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 450);
            this.Controls.Add(this.btnBackfromView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTableNames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSearchTableU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmChooseTableForUpd";
            this.Text = "frmChooseTableForUpd";
            this.Load += new System.EventHandler(this.frmChooseTableForUpd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTableNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearchTableU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackfromView;
    }
}