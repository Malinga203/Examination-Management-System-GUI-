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
    public partial class frmStdloginDet : Form
    {
        string stdId;
        public frmStdloginDet()
        {
            InitializeComponent();
        }
        public frmStdloginDet(string id)
        {
            InitializeComponent();
            stdId = id;
        }

        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checking if any fields are empty
            if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
            {
                this.errorProvider1.SetError(this.btnAdd, "Please enter all the fields");
            }
            else
            {
                try
                {

                    //Getting Connection
                    con.Open();
                    string sql = "Update tblStudent Set Username = @uname, Password= @pwd Where stdId = @id";
                    SqlCommand com = new SqlCommand(sql, con);
                    //Setting values for paramters
                    com.Parameters.AddWithValue("@uname", this.txtUsername.Text);
                    com.Parameters.AddWithValue("@pwd", this.txtPassword.Text);
                    com.Parameters.AddWithValue("@id", stdId);

                    int ret = com.ExecuteNonQuery();
                    if (ret != 0)
                    {
                        MessageBox.Show("Successfully Added Password", "Information");
                    }
                    else
                    {
                        MessageBox.Show("Unsucessful", "Error");
                    }
                    //Closin Connection
                    con.Close();
                }

                catch (SqlException ex)
                {
                    this.errorProvider1.SetError(this.txtUsername, "Username Already in use");
                    con.Close();
                }
            }
        }

        private void frmStdloginDet_Load(object sender, EventArgs e)
        {
              this.txtUserId.Text = this.stdId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
