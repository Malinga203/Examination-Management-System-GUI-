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
    public partial class frmChangeWEDate : Form
    {
        public frmChangeWEDate()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void btnChange_Click(object sender, EventArgs e)
        {
            //Checking if the text field is Empty
            if (this.txtExmID.Text == "")
            {
                this.errorProvider1.SetError(this.txtExmID, "Please enter this fields");
            }
            else
            {
                //Opening connection
                con.Open();

                string sql = "Update tblExamination set WEdate = @WEDate where exmId = @exmId";
                SqlCommand com = new SqlCommand(sql, con);

                //Assigning values for parameters
                com.Parameters.AddWithValue("WEDate", this.dateTimePicker1.Text);
                com.Parameters.AddWithValue("@exmId", this.txtExmID.Text);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("Updated Successfully " + ret, "Information");
                }
                else
                {
                    MessageBox.Show("Update Unsuccessfull", "Error");
                }
                con.Close();
            }
        }
    }
}
