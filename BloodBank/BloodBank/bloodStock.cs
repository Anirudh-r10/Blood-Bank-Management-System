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
    public partial class bloodStock : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public bloodStock()
        {
            InitializeComponent();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bloodStock_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT BBg,COUNT(*) FROM Bag  where Bbil=0 and Bdis=1 and Btest=1 group by BBg";
            //select Bbg, count(*) from Bag group by BBg having Bbil=0
            //SELECT COUNT(Bbg),Bbg FROM Bag  Having Bbil<1 group by Bbg
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Bag");
            guna2DataGridView1.DataSource = ds.Tables["Bag"].DefaultView;
            con.Close();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            bloodStock_Load(this, null);
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
