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
    public partial class frmLecLogin : Form
    {
        public frmLecLogin()
        {
            InitializeComponent();
        }

        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Checking if any fields are empty
            if (txtPassword.Text == "" || this.txtUsername.Text == "")
            {
                this.errorProvider1.SetError(this.btnLogin, "Please enter all the fields");
            }
            else
            {
                //Connecting Database
                con.Open();

                string sql = "Select Lecname,username,password from tblLecturer where username = @uname";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@uname", this.txtUsername.Text);

                SqlDataReader reader = com.ExecuteReader();


                //Checking if Record is available
                if (reader.Read() == true)
                {
                    string pass = reader.GetValue(2).ToString();
                    //Checking if Password is Correct
                    if (pass == this.txtPassword.Text)
                    {
                        string Lecname = reader.GetValue(0).ToString();
                        frmLecturerDash frmLect = new frmLecturerDash(Lecname);
                        frmLect.Show();
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

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            this.Close();
        }
    }
}
