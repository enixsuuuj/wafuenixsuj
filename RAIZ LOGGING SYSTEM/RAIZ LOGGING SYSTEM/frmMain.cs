using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAIZ_LOGGING_SYSTEM
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmsurveyInformation();
            f.ShowDialog();
        }

        private void filterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmSurveyFilterData();
            f.ShowDialog();
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmsurveyInformation();
            f.ShowDialog();
        }

        private void filterDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new frmSurveyFilterData();
            f.ShowDialog();
        }
    }
}
