namespace Indexer.UI.UserControls
{
    partial class UCHTMLExtractor
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
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHTMLData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHTMLData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtURL
            // 
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtURL.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(70, 8);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(275, 16);
            this.txtURL.TabIndex = 0;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtURL_KeyDown);
            // 
            // btnExtract
            // 
            this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtract.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract.Location = new System.Drawing.Point(350, 5);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(93, 23);
            this.btnExtract.TabIndex = 1;
            this.btnExtract.Text = "Extract URL";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter URL:";
            // 
            // dgvHTMLData
            // 
            this.dgvHTMLData.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvHTMLData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHTMLData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHTMLData.Location = new System.Drawing.Point(6, 44);
            this.dgvHTMLData.Name = "dgvHTMLData";
            this.dgvHTMLData.Size = new System.Drawing.Size(437, 303);
            this.dgvHTMLData.TabIndex = 3;
            // 
            // UCHTMLExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.dgvHTMLData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExtract);
            this.Name = "UCHTMLExtractor";
            this.Size = new System.Drawing.Size(450, 350);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHTMLData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHTMLData;
    }
}
