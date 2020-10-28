using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Indexer.Core;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;

namespace Indexer.UI.UserControls
{
    public partial class UCSearchIndex : UserControl
    {
        public UCSearchIndex()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtIndex.Text.Trim()=="")
            {
                MessageBox.Show("Please enter text");
                return;
            }
            //Get search data
            GetSearchResult();
        }

        private void GetSearchResult()
        {
            try
            {
                Report rpt = new Report();
                rpt.SaveIndexSearch(txtIndex.Text.Trim());

                SearchIndex objSearch = new SearchIndex(txtIndex.Text.Trim());
                List<SearchResult> searchResult = objSearch.SearchIndexProcess();


                if (searchResult != null)
                {
                    dgvSearchResult.DataSource = searchResult;
                    dgvSearchResult.Columns[0].Width = 40;
                    dgvSearchResult.Columns[1].Width = 230;
                    dgvSearchResult.Columns[2].Width = 90;

                }
                else
                    MessageBox.Show("No data found !.");
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
           
        }

        public void InitializeControls()
        {
            txtIndex.Text = "";
            dgvSearchResult.DataSource = null;
        }

        public void FillAutoComplete()
        {
            txtIndex.AutoCompleteCustomSource.Clear();
            if (Indexer.Core.Indexer.WordList != null)
            {
                txtIndex.AutoCompleteCustomSource.AddRange(Indexer.Core.Indexer.WordList.ToArray());
                txtIndex.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtIndex.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void dgvSearchResult_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string notepadPlusInstallLocation = ConfigurationManager.AppSettings.Get("NotepadPlusInstallLocation");
                var fileName = this.dgvSearchResult.CurrentRow.Cells[1].Value;
                var lineNumber = this.dgvSearchResult.CurrentRow.Cells[2].Value;

                var nppExePath = Path.Combine(notepadPlusInstallLocation, "Notepad++.exe");

                var sb = new StringBuilder();
                sb.AppendFormat("\"{0}\" -n{1}", fileName, lineNumber);
                Process.Start(nppExePath, sb.ToString());
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }

        }

        private void UCSearchIndex_Load(object sender, EventArgs e)
        {
          
        }

        private void txtIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                GetSearchResult();
            }
        }
    }
}
