using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Indexer.Core;

namespace Indexer.UI.UserControls
{
    public partial class UCReports : UserControl
    {
        public UCReports()
        {
            InitializeComponent();
        }

        private void UCReports_Load(object sender, EventArgs e)
        {
            
        }

        public void IntializeControls()
        {
            //show index statistics and search reports.
            Report rpt = new Report();

            dgvIndexStatistics.DataSource= rpt.GetIndexStatistics();
            dgvIndexStatistics.Columns[0].Width = 180;
            dgvIndexStatistics.Columns[1].Width = 200;

            dgvSearchReport.DataSource = rpt.GetSearchData();
            dgvSearchReport.Columns[0].Width = 50;
            dgvSearchReport.Columns[1].Width = 150;
            dgvSearchReport.Columns[2].Width = 150;


        }
    }
}
