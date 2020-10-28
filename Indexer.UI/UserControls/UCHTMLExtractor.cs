using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using URLExtraction.Core;
using System.Net;
using Indexer.Core;

namespace Indexer.UI.UserControls
{
    public partial class UCHTMLExtractor : UserControl
    {
        public UCHTMLExtractor()
        {
            InitializeComponent();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
             ExtractData();
        }
        public void InitializeControls()
        {
            //clear controls
            txtURL.Text = "";
            dgvHTMLData.DataSource = null;
        }
        private void ExtractData()
        {
            try
            {
                Application.UseWaitCursor = true;

                if (txtURL.Text.Trim() != "")

                {
                    HTMLExtract htmlEx = new HTMLExtract(txtURL.Text.Trim());
                    htmlEx.ExtractHTMLContent();
                    htmlEx.OnExtracted += htmlEx_OnExtracted;
                }
                else
                {
                    MessageBox.Show("Please enter a valid URL");
                    Application.UseWaitCursor = false;

                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
            
        }

        private void htmlEx_OnExtracted(object sender, object e)
        {
            //populate gridview with data
            List<HTMLContent> htmlCollection = (List<HTMLContent>)e;
            dgvHTMLData.DataSource = htmlCollection;
            dgvHTMLData.Columns[0].Width = 40;
            dgvHTMLData.Columns[1].Width = 230;
            dgvHTMLData.Columns[2].Width = 90;

            // Set cursor as default arrow
            Application.UseWaitCursor = false;
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                ExtractData();
            }
        }
    }
}
