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
    public partial class frmAdminDash : Form
    {
        public frmAdminDash()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdminLogin frmLogin = new frmAdminLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStd Std = new frmAddStd();
            Std.MdiParent = this;
            Std.Show();
           
        }

        private void lecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLec f1 = new frmAddLec();
            f1.MdiParent = this;
            f1.Show();

        }
    }
}
