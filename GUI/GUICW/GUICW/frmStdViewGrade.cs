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
    public partial class frmStdViewGrade : Form
    {
        public frmStdViewGrade()
        {
            InitializeComponent();
        }
        public frmStdViewGrade(string id)
        {
            InitializeComponent();
            this.stdId = id;
        }

        string stdId;
        static string cs = "Data Source= Nazeef; Initial Catalog=ExaminationManagement ; Integrated Security = True";
        SqlConnection con = new SqlConnection(cs);
        private void frmStdViewGrade_Load(object sender, EventArgs e)
        {
            //Creating Connection
            con.Open();
            string sql = "Select * from tblStudentGrade where StdId = @stdId";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@stdId", stdId);
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
    }
}
