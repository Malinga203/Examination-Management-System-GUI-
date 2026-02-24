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
    public partial class frmAddLec : Form
    {
        public frmAddLec()
        {
            InitializeComponent();
        }
        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Checking if any of the fields are empty
            if (this.txtLecId.Text == "" || this.txtLecName.Text == "")
            {
                //error message
                this.errorProvider1.SetError(this.btnNext, "Please Enter all the fields");
            }
            else
            {
                try
                {
                    //Opening the connection
                    con.Open();

                    //Sql Query
                    string sql = "Insert into tblLecturer (lecId,lecName,lecAge,Gender) values (@lecId,@LecName, @LecAge, @Gender)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    //Assigning value for the parameters
                    cmd.Parameters.AddWithValue("@lecId", this.txtLecId.Text);
                    cmd.Parameters.AddWithValue("@lecName", this.txtLecName.Text);
                    cmd.Parameters.AddWithValue("@lecAge", this.numAge.Value);

                    //Checking the selected radio button
                    if (this.rbMale.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "Male");
                    }
                    else if (this.rbFemale.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Gender", "Female");
                    }


                    //Execute Insert
                    int ret = cmd.ExecuteNonQuery();
                    MessageBox.Show("Records Inserted" + ret, "Information");
                    con.Close();
                    string lecID = this.txtLecId.Text;

                    //Opening next page
                    frmLecLoginDet f1 = new frmLecLoginDet(lecID);
                    f1.Show();
                    this.Hide();
                }


                catch (SqlException ex)
                {
                    MessageBox.Show("Unsucessful " + ex, "Error");
                    con.Close();
                }
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
