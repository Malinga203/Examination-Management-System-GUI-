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
    public partial class frmAddMarks : Form
    {
        public frmAddMarks()
        {
            InitializeComponent();
        }
        //Initializing Database Connection
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Checking if any fields are empty
            if (this.txtCWmarks.Text == "" || this.txtWEMarks.Text == "" || this.txtExmId.Text == "" || this.txtStdID.Text == "")
            {
                //Error message using error provider
                this.errorProvider1.SetError(this.btnAdd, "Please Enter all the fields");
            }
            else
            {
                //Variables
                double WEmarks, CWmarks, TotalMarks;
                WEmarks = Convert.ToDouble(this.txtWEMarks.Text);
                CWmarks = Convert.ToDouble(this.txtCWmarks.Text);
                string WEgrade, CWgrade, FinalGrade;
                string passFail;

                //Checking if marks are valid
                if (WEmarks > 100 || WEmarks < 0)
                {
                    this.errorProvider1.SetError(this.txtWEMarks, "Please Enter a Valid Marks");
                }
                else if (CWmarks > 100 || CWmarks < 0)
                {
                    this.errorProvider1.SetError(this.txtCWmarks, "Please Enter a Valid Marks");
                }
                else
                {
                    try
                    {
                        //Opening Connection
                        con.Open();


                        //Calculting Total Marks
                        TotalMarks = (WEmarks + CWmarks) / 2;
                        this.txtTotalMarks.Text = TotalMarks.ToString();

                        //Sql Insert Query
                        string sql = "Insert into tblStudentMarks values(@stdID, @exmID, @WEMarks, @CWMarks, @TotalMarks)";
                        SqlCommand com = new SqlCommand(sql, con);
                        com.Parameters.AddWithValue("@stdID", this.txtStdID.Text);
                        com.Parameters.AddWithValue("@exmID", this.txtExmId.Text);
                        com.Parameters.AddWithValue("@WEMarks", WEmarks);
                        com.Parameters.AddWithValue("@CWMarks", CWmarks);
                        com.Parameters.AddWithValue("@TotalMarks", TotalMarks);

                        int ret = com.ExecuteNonQuery();
                        if (ret != 0)
                        {
                            MessageBox.Show("Inserted Records" + ret, "Information");
                        }
                        else
                        {
                            MessageBox.Show("Unsuccessfull", "Error");
                        }
                        con.Close();

                        //Calculating and inserting the Grade to the database
                        //Calculating CWGrade
                        if (CWmarks >= 90.0)
                        {
                            CWgrade = "A+";

                        }
                        else if (CWmarks >= 75.0)
                        {
                            CWgrade = "A";

                        }
                        else if (CWmarks >= 60.0)
                        {
                            CWgrade = "B+";

                        }
                        else if (CWmarks >= 50.0)
                        {
                            CWgrade = "B";

                        }
                        else if (CWmarks >= 40.0)
                        {
                            CWgrade = "C+";

                        }
                        else if (CWmarks >= 35.0)
                        {
                            CWgrade = "C";

                        }
                        else
                        {
                            CWgrade = "E";

                        }

                        //Calculating WEGrade
                        if (WEmarks >= 90.0)
                        {
                            WEgrade = "A+";

                        }
                        else if (WEmarks >= 75.0)
                        {
                            WEgrade = "A";

                        }
                        else if (WEmarks >= 60.0)
                        {
                            WEgrade = "B+";

                        }
                        else if (WEmarks >= 50.0)
                        {
                            WEgrade = "B";

                        }
                        else if (WEmarks >= 40.0)
                        {
                            WEgrade = "C+";

                        }
                        else if (WEmarks >= 35.0)
                        {
                            WEgrade = "C";

                        }
                        else
                        {
                            WEgrade = "E";

                        }

                        //Calculating FinalGrade
                        if (TotalMarks >= 90.0)
                        {
                            FinalGrade = "A+";

                        }
                        else if (TotalMarks >= 75.0)
                        {
                            FinalGrade = "A";

                        }
                        else if (TotalMarks >= 60.0)
                        {
                            FinalGrade = "B+";

                        }
                        else if (TotalMarks >= 50.0)
                        {
                            FinalGrade = "B";

                        }
                        else if (TotalMarks >= 40.0)
                        {
                            FinalGrade = "C+";

                        }
                        else if (TotalMarks >= 35.0)
                        {
                            FinalGrade = "C";

                        }
                        else
                        {
                            FinalGrade = "E";

                        }

                        //Calulating pass or fail
                        if (TotalMarks >= 60)
                        {
                            passFail = "Pass";
                        }
                        else
                        {
                            passFail = "Fail";
                        }


                        //Saving to Database
                        //Opening Connection to save the Grades
                        con.Open();

                        //Sql Query
                        string sqlGrade = "insert into tblStudentGrade values (@stdID1, @exmID1, @WEGrade, @CWGrade, @FinalGrade,@pf)";
                        SqlCommand com2 = new SqlCommand(sqlGrade, con);

                        //Assigning value for parameters
                        com2.Parameters.AddWithValue("@stdID1", this.txtStdID.Text);
                        com2.Parameters.AddWithValue("@exmID1", this.txtExmId.Text);
                        com2.Parameters.AddWithValue("@WEGrade", WEgrade);
                        com2.Parameters.AddWithValue("@CWGrade", CWgrade);
                        com2.Parameters.AddWithValue("@FinalGrade", FinalGrade);
                        com2.Parameters.AddWithValue("@pf", passFail);
                        int ret1 = com2.ExecuteNonQuery();

                        if (ret1 != 0)
                        {
                            MessageBox.Show("Grade Entered " + ret1, "Information");
                        }
                        else
                        {
                            MessageBox.Show("Grade Entered " + ret1, "Information");
                        }
                        //closing Connection
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

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
