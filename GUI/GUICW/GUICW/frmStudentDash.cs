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
    public partial class frmStudentDash : Form
    {
        string name,StdID;
        public frmStudentDash()
        {
            InitializeComponent();
        }
        public frmStudentDash(string name,string id)
        {
            InitializeComponent();
            this.name = name;
            this.StdID = id;
        }


        private void frmStudentDash_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome " + this.name;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentLogin f1 = new frmStudentLogin();
            f1.Show();
            this.Close();
        }

        private void examinationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewExam f1 = new frmViewExam();
            f1.MdiParent = this;
            f1.Show();
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStdViewGrade f1 = new frmStdViewGrade(StdID);
            f1.MdiParent = this;
            f1.Show();
        }
    }
}
