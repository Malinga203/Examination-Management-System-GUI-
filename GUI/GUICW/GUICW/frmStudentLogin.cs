using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICW
{
    public partial class frmStudentLogin : Form
    {
        public frmStudentLogin()
        {
            InitializeComponent();
        }

        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);

        private void btnLogin_Click(object sender, EventArgs e)
        {
        
            //Connecting Database
            con.Open();

            string sql = "Select stdId,StdName,username,password from tblStudent where username = @uname";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@uname", this.txtUsername.Text);

            SqlDataReader reader = com.ExecuteReader();

            //Checking if Record is available
            if (reader.Read() == true)
            {
                string pass = reader.GetValue(3).ToString();
                //Checking if Password is Correct
                if (pass == this.txtPassword.Text)
                {
                    string stdName = reader.GetValue(1).ToString();
                    string stdId = reader.GetValue(0).ToString();
                    frmStudentDash frmStd = new frmStudentDash(stdName,stdId);
                    frmStd.Show();
                    this.Hide();
                }
                else
                {
                    //Error to display if password is wrong
                    MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Error to display that username is wrong
                MessageBox.Show("Check Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
