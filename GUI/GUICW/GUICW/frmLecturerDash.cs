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
    public partial class frmLecturerDash : Form
    {
        public frmLecturerDash()
        {
            InitializeComponent();
        }
        string name;
        public frmLecturerDash(string Lecname)
        {
            InitializeComponent();
            this.name = Lecname;
        }

        private void frmLecturerDash_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome "+name;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLecLogin frmLogin = new frmLecLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddExam f1 = new frmAddExam();
            f1.MdiParent = this;
            f1.Show();
            
        }

        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddMarks f1 = new frmAddMarks();
            f1.MdiParent = this;
            f1.Show();

        }

        private void studentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmStdReport f1 = new frmStdReport();
            f1.MdiParent = this;
            f1.Show();
        }

        private void studentGradeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmGradeReport f1 = new frmGradeReport();
            f1.MdiParent = this;
            f1.Show();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewStudent f1 = new frmViewStudent();
            f1.MdiParent = this;
            f1.Show();
        }

        private void examinationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmViewExam f1 = new frmViewExam();
            f1.MdiParent = this;
            f1.Show();
        }

        private void studentMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewMarks f1 = new frmViewMarks();
            f1.MdiParent = this;
            f1.Show();
        }

        private void studentGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewGrade f1 = new frmViewGrade();
            f1.MdiParent = this;
            f1.Show();
        }

        private void courseworkDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeCWDate f1 = new frmChangeCWDate();
            f1.MdiParent = this;
            f1.Show();
        }

        private void writtenExamDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeWEDate f1 = new frmChangeWEDate();
            f1.MdiParent = this;
            f1.Show();
        }

        private void examinationToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}
