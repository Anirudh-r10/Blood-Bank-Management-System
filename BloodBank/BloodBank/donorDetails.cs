using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BloodBank
{
    public partial class donorDetails : Form

    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public donorDetails()
        {
            InitializeComponent();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void donorDetails_Load(object sender, EventArgs e)
        {
            con.Open();
            DataGridViewTextBoxColumn indexColumn = new DataGridViewTextBoxColumn();
           

            string query = "select Did,Dname,Bbg from Donor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Donor");
            guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
            con.Close();

            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                guna2DataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            guna2DataGridView1.RowHeadersVisible = true;

        }
    }
    
}
