using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indexer.UI
{
    public partial class IndexMasterUI : Form
    {
        public IndexMasterUI()
        {
            InitializeComponent();
        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {
            //position indicator panel location with current button
            UpdateIndicatorLocation((Button)sender);

            //hide other controls show current control
            ShowHideControls(ucIndexCreator1);
        }

        private void UpdateIndicatorLocation(Button target)
        {
            this.pnlIndicator.Location = new Point(
                 pnlIndicator.Location.X,
                 target.Location.Y
             );

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UpdateIndicatorLocation((Button)sender);
            groupMain.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateIndicatorLocation((Button)sender);
            ShowHideControls(ucSearchIndex1);
            ucSearchIndex1.FillAutoComplete();
            ucSearchIndex1.InitializeControls();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            UpdateIndicatorLocation((Button)sender);
            ucReports1.IntializeControls();
            ShowHideControls(ucReports1);
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            UpdateIndicatorLocation((Button)sender);
            ShowHideControls(uchtmlExtractor1);
            uchtmlExtractor1.InitializeControls();
        }

        private void IndexMaster_Load(object sender, EventArgs e)
        {
            //change mouse pointor as waiting cursor.
            Application.UseWaitCursor = true;
            groupMain.Visible = false;

            //Deserialize and get index data, if available
            Indexer.Core.Indexer.DeserializeIndex();

            Application.UseWaitCursor = false;
        }

        private void ShowHideControls(UserControl currentControl)
        {
            foreach (Control ctrl in groupMain.Controls)
            {
                if (ctrl is UserControl)
                {
                    ctrl.Visible = false;
                }
            }
            groupMain.Visible = true;
            currentControl.Visible = true;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        //To avoid flickering of screen during hide/show of usercontrols.
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
