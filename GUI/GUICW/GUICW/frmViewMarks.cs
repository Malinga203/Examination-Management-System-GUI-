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
    public partial class frmViewMarks : Form
    {
        public frmViewMarks()
        {
            InitializeComponent();
        }
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Conncetion Opening
            con.Open();

            string sql = "select * from tblStudentMarks where stdId = @stdid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@stdid", this.txtSearch.Text);
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void frmViewMarks_Load(object sender, EventArgs e)
        {
            //Connection Opening
            con.Open();

            string sql = "select * from tblStudentMarks";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
