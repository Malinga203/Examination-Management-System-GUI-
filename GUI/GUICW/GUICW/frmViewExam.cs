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
    public partial class frmViewExam : Form
    {
        public frmViewExam()
        {
            InitializeComponent();
        }
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void frmViewExam_Load(object sender, EventArgs e)
        {
            //connection opening 
            con.Open();

            string sql = "SELECT * FROM tblExamination";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Conncetion Opening
            con.Open();

            string sql = "select * from tblExamination where exmId = @exmId";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@exmId", this.txtSearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
