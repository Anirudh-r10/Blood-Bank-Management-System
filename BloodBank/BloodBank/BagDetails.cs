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

namespace BloodBank
{
    public partial class BagDetails : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public BagDetails()
        {
            InitializeComponent();
        }

        private void BagDetails_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Bag", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Bag");
            guna2DataGridView1.DataSource = ds.Tables["Bag"].DefaultView;
            con.Close();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
