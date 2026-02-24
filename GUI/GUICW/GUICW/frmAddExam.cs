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
    public partial class frmAddExam : Form
    {
        public frmAddExam()
        {
            InitializeComponent();
        }

        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checking if Any fields are empty
            if (this.txtExamID.Text == "" || this.txtExamName.Text == "")
            {
                this.errorProvider1.SetError(this.btnAdd, "Please Enter all the fields");
            }
            else
            {
                try
                {
                    //Opening the Connection
                    con.Open();

                    //SQl Query
                    string sql = "insert into tblExamination values(@exmID, @exmName, @WEDate, @CWDate)";
                    SqlCommand com = new SqlCommand(sql, con);

                    //Assigning Value for the Parameters
                    com.Parameters.AddWithValue("@exmID", this.txtExamID.Text);
                    com.Parameters.AddWithValue("@exmName", this.txtExamName.Text);
                    com.Parameters.AddWithValue("@WEDate", this.dateTimeWE.Text);
                    com.Parameters.AddWithValue("@CWDate", this.dateTimeCW.Text);

                    //Executing Query
                    int ret = com.ExecuteNonQuery();

                    //Checking if record is available
                    if (ret != 0)
                    {
                        MessageBox.Show("Record Inserted: " + ret, "Information");
                    }
                    else
                    {
                        MessageBox.Show("Unsucessful", "Error");
                    }

                    //Closing the COnnection
                    con.Close();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Unsucessful " + ex, "Error");
                    con.Close();
                }
            }
        }
    }
}
