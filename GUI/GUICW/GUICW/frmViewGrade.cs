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
    public partial class frmViewGrade : Form
    {
        public frmViewGrade()
        {
            InitializeComponent();
        }
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Conncetion Opening
            con.Open();

            string sql = "select * from tblStudentGrade where stdId = @stdid";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@stdid", this.txtSearch.Text);
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void frmViewGrade_Load(object sender, EventArgs e)
        {
            //Connection Opening
            con.Open();

            string sql = "select * from tblStudentGrade";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
