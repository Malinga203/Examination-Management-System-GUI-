using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICW
{
    public partial class frmGradeReport : Form
    {
        public frmGradeReport()
        {
            InitializeComponent();
        }

        private void frmGradeReport_Load(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ReportSource = "C:\\Users\\nazee\\source\\repos\\GUICW\\GUICW\\CRGradeReport.rpt";

        }
    }
}
