namespace StockTrade
{
    partial class Form1
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
            this.chkAutoRefreshLastPx = new System.Windows.Forms.CheckBox();
            this.dataGridView_US = new System.Windows.Forms.DataGridView();
            this.cmbUpdInterval = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_HK = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView_UK = new System.Windows.Forms.DataGridView();
            this.chkUpdHK = new System.Windows.Forms.CheckBox();
            this.chkUpdUS = new System.Windows.Forms.CheckBox();
            this.chkUpdUK = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radUpdUS = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radUpdUK = new System.Windows.Forms.RadioButton();
            this.radUpdHK = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_US)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HK)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoRefreshLastPx
            // 
            this.chkAutoRefreshLastPx.AutoSize = true;
            this.chkAutoRefreshLastPx.Checked = true;
            this.chkAutoRefreshLastPx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefreshLastPx.Location = new System.Drawing.Point(9, 15);
            this.chkAutoRefreshLastPx.Margin = new System.Windows.Forms.Padding(4);
            this.chkAutoRefreshLastPx.Name = "chkAutoRefreshLastPx";
            this.chkAutoRefreshLastPx.Size = new System.Drawing.Size(194, 21);
            this.chkAutoRefreshLastPx.TabIndex = 9;
            this.chkAutoRefreshLastPx.Text = "Update time interval (Sec)";
            this.chkAutoRefreshLastPx.UseVisualStyleBackColor = true;
            this.chkAutoRefreshLastPx.CheckedChanged += new System.EventHandler(this.chkAutoRefreshLastPx_CheckedChanged);
            // 
            // dataGridView_US
            // 
            this.dataGridView_US.AllowUserToAddRows = false;
            this.dataGridView_US.AllowUserToDeleteRows = false;
            this.dataGridView_US.AllowUserToResizeColumns = false;
            this.dataGridView_US.AllowUserToResizeRows = false;
            this.dataGridView_US.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_US.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_US.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_US.Location = new System.Drawing.Point(4, 4);
            this.dataGridView_US.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_US.Name = "dataGridView_US";
            this.dataGridView_US.ReadOnly = true;
            this.dataGridView_US.Size = new System.Drawing.Size(676, 729);
            this.dataGridView_US.TabIndex = 10;
            this.dataGridView_US.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.datagridview_DataError);
            this.dataGridView_US.SelectionChanged += new System.EventHandler(this.datagridview_SelectionChanged);
            // 
            // cmbUpdInterval
            // 
            this.cmbUpdInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdInterval.FormattingEnabled = true;
            this.cmbUpdInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "30",
            "60"});
            this.cmbUpdInterval.Location = new System.Drawing.Point(200, 12);
            this.cmbUpdInterval.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUpdInterval.Name = "cmbUpdInterval";
            this.cmbUpdInterval.Size = new System.Drawing.Size(81, 24);
            this.cmbUpdInterval.TabIndex = 11;
            this.cmbUpdInterval.SelectedIndexChanged += new System.EventHandler(this.cmbUpdInterval_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 46);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 764);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView_US);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(683, 735);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "US";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_HK);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(683, 735);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HK";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_HK
            // 
            this.dataGridView_HK.AllowUserToAddRows = false;
            this.dataGridView_HK.AllowUserToDeleteRows = false;
            this.dataGridView_HK.AllowUserToResizeColumns = false;
            this.dataGridView_HK.AllowUserToResizeRows = false;
            this.dataGridView_HK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_HK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_HK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HK.Location = new System.Drawing.Point(4, 4);
            this.dataGridView_HK.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_HK.Name = "dataGridView_HK";
            this.dataGridView_HK.ReadOnly = true;
            this.dataGridView_HK.Size = new System.Drawing.Size(676, 729);
            this.dataGridView_HK.TabIndex = 11;
            this.dataGridView_HK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.datagridview_DataError);
            this.dataGridView_HK.SelectionChanged += new System.EventHandler(this.datagridview_SelectionChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView_UK);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(683, 735);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "UK";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView_UK
            // 
            this.dataGridView_UK.AllowUserToAddRows = false;
            this.dataGridView_UK.AllowUserToDeleteRows = false;
            this.dataGridView_UK.AllowUserToResizeColumns = false;
            this.dataGridView_UK.AllowUserToResizeRows = false;
            this.dataGridView_UK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_UK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_UK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UK.Location = new System.Drawing.Point(4, 4);
            this.dataGridView_UK.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_UK.Name = "dataGridView_UK";
            this.dataGridView_UK.ReadOnly = true;
            this.dataGridView_UK.Size = new System.Drawing.Size(676, 729);
            this.dataGridView_UK.TabIndex = 11;
            this.dataGridView_UK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.datagridview_DataError);
            this.dataGridView_UK.SelectionChanged += new System.EventHandler(this.datagridview_SelectionChanged);
            // 
            // chkUpdHK
            // 
            this.chkUpdHK.AutoSize = true;
            this.chkUpdHK.Checked = true;
            this.chkUpdHK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdHK.Location = new System.Drawing.Point(69, 23);
            this.chkUpdHK.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdHK.Name = "chkUpdHK";
            this.chkUpdHK.Size = new System.Drawing.Size(49, 21);
            this.chkUpdHK.TabIndex = 14;
            this.chkUpdHK.Text = "HK";
            this.chkUpdHK.UseVisualStyleBackColor = true;
            // 
            // chkUpdUS
            // 
            this.chkUpdUS.AutoSize = true;
            this.chkUpdUS.Checked = true;
            this.chkUpdUS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdUS.Location = new System.Drawing.Point(7, 23);
            this.chkUpdUS.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdUS.Name = "chkUpdUS";
            this.chkUpdUS.Size = new System.Drawing.Size(49, 21);
            this.chkUpdUS.TabIndex = 15;
            this.chkUpdUS.Text = "US";
            this.chkUpdUS.UseVisualStyleBackColor = true;
            // 
            // chkUpdUK
            // 
            this.chkUpdUK.AutoSize = true;
            this.chkUpdUK.Checked = true;
            this.chkUpdUK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdUK.Location = new System.Drawing.Point(132, 23);
            this.chkUpdUK.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpdUK.Name = "chkUpdUK";
            this.chkUpdUK.Size = new System.Drawing.Size(49, 21);
            this.chkUpdUK.TabIndex = 16;
            this.chkUpdUK.Text = "UK";
            this.chkUpdUK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkUpdUS);
            this.groupBox1.Controls.Add(this.chkUpdUK);
            this.groupBox1.Controls.Add(this.chkUpdHK);
            this.groupBox1.Location = new System.Drawing.Point(493, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(193, 53);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Refresh by Ram";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radUpdUS
            // 
            this.radUpdUS.AutoSize = true;
            this.radUpdUS.Checked = true;
            this.radUpdUS.Location = new System.Drawing.Point(8, 22);
            this.radUpdUS.Margin = new System.Windows.Forms.Padding(4);
            this.radUpdUS.Name = "radUpdUS";
            this.radUpdUS.Size = new System.Drawing.Size(48, 21);
            this.radUpdUS.TabIndex = 18;
            this.radUpdUS.TabStop = true;
            this.radUpdUS.Text = "US";
            this.radUpdUS.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radUpdUK);
            this.groupBox2.Controls.Add(this.radUpdHK);
            this.groupBox2.Controls.Add(this.radUpdUS);
            this.groupBox2.Location = new System.Drawing.Point(291, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(201, 53);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Refresh region by Ram";
            // 
            // radUpdUK
            // 
            this.radUpdUK.AutoSize = true;
            this.radUpdUK.Location = new System.Drawing.Point(131, 22);
            this.radUpdUK.Margin = new System.Windows.Forms.Padding(4);
            this.radUpdUK.Name = "radUpdUK";
            this.radUpdUK.Size = new System.Drawing.Size(48, 21);
            this.radUpdUK.TabIndex = 20;
            this.radUpdUK.Text = "UK";
            this.radUpdUK.UseVisualStyleBackColor = true;
            // 
            // radUpdHK
            // 
            this.radUpdHK.AutoSize = true;
            this.radUpdHK.Location = new System.Drawing.Point(69, 22);
            this.radUpdHK.Margin = new System.Windows.Forms.Padding(4);
            this.radUpdHK.Name = "radUpdHK";
            this.radUpdHK.Size = new System.Drawing.Size(48, 21);
            this.radUpdHK.TabIndex = 19;
            this.radUpdHK.Text = "HK";
            this.radUpdHK.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 809);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmbUpdInterval);
            this.Controls.Add(this.chkAutoRefreshLastPx);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Hello";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_US)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HK)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoRefreshLastPx;
        private System.Windows.Forms.DataGridView dataGridView_US;
        private System.Windows.Forms.ComboBox cmbUpdInterval;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_HK;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView_UK;
        private System.Windows.Forms.CheckBox chkUpdHK;
        private System.Windows.Forms.CheckBox chkUpdUS;
        private System.Windows.Forms.CheckBox chkUpdUK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radUpdUS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radUpdUK;
        private System.Windows.Forms.RadioButton radUpdHK;
    }
}

