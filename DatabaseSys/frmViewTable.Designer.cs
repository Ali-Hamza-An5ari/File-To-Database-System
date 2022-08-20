namespace DatabaseSys
{
    partial class frmViewTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewTable));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBackfromView = new System.Windows.Forms.Button();
            this.lblTableName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.ForeColor = System.Drawing.Color.Firebrick;
            this.panel2.Location = new System.Drawing.Point(199, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 69);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(206, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(538, 230);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnBackfromView
            // 
            this.btnBackfromView.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBackfromView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBackfromView.FlatAppearance.BorderColor = System.Drawing.Color.Lavender;
            this.btnBackfromView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackfromView.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBackfromView.Location = new System.Drawing.Point(586, 380);
            this.btnBackfromView.Name = "btnBackfromView";
            this.btnBackfromView.Size = new System.Drawing.Size(163, 46);
            this.btnBackfromView.TabIndex = 21;
            this.btnBackfromView.Text = "Back";
            this.btnBackfromView.UseVisualStyleBackColor = false;
            this.btnBackfromView.Click += new System.EventHandler(this.btnBackfromView_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.ForeColor = System.Drawing.Color.Navy;
            this.lblTableName.Location = new System.Drawing.Point(305, 87);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(27, 20);
            this.lblTableName.TabIndex = 27;
            this.lblTableName.Text = "lbl";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.ForeColor = System.Drawing.Color.Coral;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 456);
            this.panel1.TabIndex = 28;
            // 
            // frmViewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.btnBackfromView);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Name = "frmViewTable";
            this.Text = "frmViewTable";
            this.Load += new System.EventHandler(this.frmViewTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBackfromView;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Panel panel1;
    }
}