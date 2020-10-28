namespace Indexer.UI
{
    partial class IndexMasterUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexMasterUI));
            Indexer.Core.FileWatcher fileWatcher1 = new Indexer.Core.FileWatcher();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.ucReports1 = new Indexer.UI.UserControls.UCReports();
            this.ucSearchIndex1 = new Indexer.UI.UserControls.UCSearchIndex();
            this.uchtmlExtractor1 = new Indexer.UI.UserControls.UCHTMLExtractor();
            this.ucIndexCreator1 = new Indexer.UI.UserControls.UCIndexCreator();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblVer = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlBlock = new System.Windows.Forms.Panel();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateIndex = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            this.groupMain.SuspendLayout();
            this.pnlBlock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.groupMain);
            this.pnlMain.Controls.Add(this.pnlIndicator);
            this.pnlMain.Controls.Add(this.lblMinimize);
            this.pnlMain.Controls.Add(this.lblClose);
            this.pnlMain.Controls.Add(this.lblVer);
            this.pnlMain.Controls.Add(this.lblAppName);
            this.pnlMain.Controls.Add(this.pnlBlock);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(850, 550);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // groupMain
            // 
            this.groupMain.BackColor = System.Drawing.Color.Transparent;
            this.groupMain.Controls.Add(this.ucReports1);
            this.groupMain.Controls.Add(this.ucSearchIndex1);
            this.groupMain.Controls.Add(this.uchtmlExtractor1);
            this.groupMain.Controls.Add(this.ucIndexCreator1);
            this.groupMain.Location = new System.Drawing.Point(302, 140);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(467, 386);
            this.groupMain.TabIndex = 14;
            this.groupMain.TabStop = false;
            // 
            // ucReports1
            // 
            this.ucReports1.Location = new System.Drawing.Point(8, 26);
            this.ucReports1.Name = "ucReports1";
            this.ucReports1.Size = new System.Drawing.Size(450, 350);
            this.ucReports1.TabIndex = 1;
            // 
            // ucSearchIndex1
            // 
            this.ucSearchIndex1.Location = new System.Drawing.Point(9, 22);
            this.ucSearchIndex1.Name = "ucSearchIndex1";
            this.ucSearchIndex1.Size = new System.Drawing.Size(450, 350);
            this.ucSearchIndex1.TabIndex = 16;
            // 
            // uchtmlExtractor1
            // 
            this.uchtmlExtractor1.Location = new System.Drawing.Point(10, 21);
            this.uchtmlExtractor1.Name = "uchtmlExtractor1";
            this.uchtmlExtractor1.Size = new System.Drawing.Size(450, 350);
            this.uchtmlExtractor1.TabIndex = 1;
            // 
            // ucIndexCreator1
            // 
            this.ucIndexCreator1.Location = new System.Drawing.Point(9, 19);
            this.ucIndexCreator1.Name = "ucIndexCreator1";
            this.ucIndexCreator1.Size = new System.Drawing.Size(450, 361);
            this.ucIndexCreator1.TabIndex = 15;
            fileWatcher1.FolderList = null;
            fileWatcher1.Interval = 500;
            this.ucIndexCreator1.TheWatcher = fileWatcher1;
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlIndicator.Location = new System.Drawing.Point(90, 140);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(10, 42);
            this.pnlIndicator.TabIndex = 5;
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.White;
            this.lblMinimize.Location = new System.Drawing.Point(811, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(15, 16);
            this.lblMinimize.TabIndex = 4;
            this.lblMinimize.Text = "_";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(829, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(17, 16);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.Location = new System.Drawing.Point(316, 88);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(76, 17);
            this.lblVer.TabIndex = 3;
            this.lblVer.Text = "Version 1.0";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(310, 51);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(145, 42);
            this.lblAppName.TabIndex = 2;
            this.lblAppName.Text = "Indexer";
            // 
            // pnlBlock
            // 
            this.pnlBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(32)))), ((int)(((byte)(118)))));
            this.pnlBlock.Controls.Add(this.btnExtract);
            this.pnlBlock.Controls.Add(this.btnReports);
            this.pnlBlock.Controls.Add(this.btnSearch);
            this.pnlBlock.Controls.Add(this.btnCreateIndex);
            this.pnlBlock.Controls.Add(this.btnHome);
            this.pnlBlock.Controls.Add(this.pictureBox1);
            this.pnlBlock.Location = new System.Drawing.Point(90, 0);
            this.pnlBlock.Name = "pnlBlock";
            this.pnlBlock.Size = new System.Drawing.Size(190, 550);
            this.pnlBlock.TabIndex = 0;
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.Transparent;
            this.btnExtract.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExtract.FlatAppearance.BorderSize = 0;
            this.btnExtract.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btnExtract.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtract.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract.ForeColor = System.Drawing.Color.White;
            this.btnExtract.Location = new System.Drawing.Point(0, 308);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(190, 42);
            this.btnExtract.TabIndex = 13;
            this.btnExtract.Text = "Extract URL";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.Transparent;
            this.btnReports.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 266);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(190, 42);
            this.btnReports.TabIndex = 11;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(0, 224);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(190, 42);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search Index";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateIndex
            // 
            this.btnCreateIndex.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateIndex.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCreateIndex.FlatAppearance.BorderSize = 0;
            this.btnCreateIndex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btnCreateIndex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnCreateIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateIndex.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateIndex.ForeColor = System.Drawing.Color.White;
            this.btnCreateIndex.Location = new System.Drawing.Point(0, 182);
            this.btnCreateIndex.Name = "btnCreateIndex";
            this.btnCreateIndex.Size = new System.Drawing.Size(190, 42);
            this.btnCreateIndex.TabIndex = 9;
            this.btnCreateIndex.Text = "Create Index";
            this.btnCreateIndex.UseVisualStyleBackColor = false;
            this.btnCreateIndex.Click += new System.EventHandler(this.btnCreateIndex_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepPink;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 140);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(190, 42);
            this.btnHome.TabIndex = 8;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 65);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // IndexMasterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IndexMasterUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IndexMaster";
            this.Load += new System.EventHandler(this.IndexMaster_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupMain.ResumeLayout(false);
            this.pnlBlock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBlock;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCreateIndex;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.GroupBox groupMain;
        private UserControls.UCIndexCreator ucIndexCreator1;
        private UserControls.UCHTMLExtractor uchtmlExtractor1;
        private UserControls.UCSearchIndex ucSearchIndex1;
        private UserControls.UCReports ucReports1;
    }
}