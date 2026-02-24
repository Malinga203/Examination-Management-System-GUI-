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
    public partial class frmAddStd : Form
    {
        public frmAddStd()
        {
            InitializeComponent();
        }
        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Checking if required fields are empty
            if (this.txtStdId.Text == "" || this.txtStdName.Text == "")
            {
                this.errorProvider1.SetError(this.btnNext, "Please Enter all the fields");
            }
            else
            {
                try
                {
                    //Opening Connection
                    con.Open();

                    //Sql Query
                    string sql = "Insert into tblStudent (stdId,StdName,StdAge,Gender) values (@stdId,@StdName,@StdAge,@Gender)";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    //Assigning values for the parameters
                    cmd.Parameters.AddWithValue("@stdId", this.txtStdId.Text);
                    cmd.Parameters.AddWithValue("@StdName", this.txtStdName.Text);
                    cmd.Parameters.AddWithValue("@StdAge", this.numAge.Value);

                    //Checking the radio button
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

                    string stdId = this.txtStdId.Text;

                    frmStdloginDet f1 = new frmStdloginDet(stdId);
                    f1.Show();
                    this.Hide();
                    con.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show( "Unsucessful "+ex,"Error");
                    con.Close();
                }
            }
        }
    }
}
