namespace Indexer.UI.UserControls
{
    partial class UCReports
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.dgvIndexStatistics = new System.Windows.Forms.DataGridView();
            this.tabsearchReport = new System.Windows.Forms.TabPage();
            this.dgvSearchReport = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexStatistics)).BeginInit();
            this.tabsearchReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Index Reports";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStatistics);
            this.tabControl1.Controls.Add(this.tabsearchReport);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 323);
            this.tabControl1.TabIndex = 1;
            // 
            // tabStatistics
            // 
            this.tabStatistics.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabStatistics.Controls.Add(this.dgvIndexStatistics);
            this.tabStatistics.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStatistics.Location = new System.Drawing.Point(4, 26);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(426, 293);
            this.tabStatistics.TabIndex = 0;
            this.tabStatistics.Text = "Index Statistics";
            // 
            // dgvIndexStatistics
            // 
            this.dgvIndexStatistics.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvIndexStatistics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvIndexStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndexStatistics.Location = new System.Drawing.Point(3, 0);
            this.dgvIndexStatistics.Name = "dgvIndexStatistics";
            this.dgvIndexStatistics.Size = new System.Drawing.Size(423, 293);
            this.dgvIndexStatistics.TabIndex = 0;
            // 
            // tabsearchReport
            // 
            this.tabsearchReport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabsearchReport.Controls.Add(this.dgvSearchReport);
            this.tabsearchReport.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabsearchReport.Location = new System.Drawing.Point(4, 26);
            this.tabsearchReport.Name = "tabsearchReport";
            this.tabsearchReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabsearchReport.Size = new System.Drawing.Size(426, 293);
            this.tabsearchReport.TabIndex = 1;
            this.tabsearchReport.Text = "Index Search Report";
            // 
            // dgvSearchReport
            // 
            this.dgvSearchReport.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSearchReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSearchReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchReport.Location = new System.Drawing.Point(0, 0);
            this.dgvSearchReport.Name = "dgvSearchReport";
            this.dgvSearchReport.Size = new System.Drawing.Size(426, 293);
            this.dgvSearchReport.TabIndex = 0;
            // 
            // UCReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "UCReports";
            this.Size = new System.Drawing.Size(450, 350);
            this.Load += new System.EventHandler(this.UCReports_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndexStatistics)).EndInit();
            this.tabsearchReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.TabPage tabsearchReport;
        private System.Windows.Forms.DataGridView dgvIndexStatistics;
        private System.Windows.Forms.DataGridView dgvSearchReport;
    }
}
