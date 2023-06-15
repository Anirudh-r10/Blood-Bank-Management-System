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
    public partial class DelDonor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        void reset()
        {
            txtage.Text = " ";
            txtname.Text = " ";
            txtcty.Text = " ";
            txtph.Text = " ";
            txtpn.Text = " ";
            cbbg.Text = " ";
            cbgen.Text = " ";

        }
        public DelDonor()
        {
            InitializeComponent();
        }

        private void DelDonor_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Donor", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"Donor");
            guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
            con.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {
    
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];

                lblid.Text = row.Cells["Did"].Value.ToString();
                txtname.Text = row.Cells["Dname"].Value.ToString();
                txtage.Text = row.Cells["Dage"].Value.ToString();
                txtph.Text = row.Cells["Dph"].Value.ToString();
                txtpn.Text = row.Cells["Dpin"].Value.ToString();
                cbbg.Text = row.Cells["Bbg"].Value.ToString();
                txtcty.Text = row.Cells["Dcty"].Value.ToString();
                cbgen.Text= row.Cells["Dgen"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtnme_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string query = "delete from Donor where Did='" + lblid.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Donor deleted successfully!");

            con.Close();
            reset();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Donor", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Donor");
            guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
            con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "update Donor set Dname='" + txtname.Text + "',Dage='" + txtage.Text + "',Bbg='" + cbbg.Text + "',Dgen='" + cbgen.Text + "',Dph='" + txtph.Text + "',Dcty='" + txtcty.Text + "',Dpin='" + txtpn.Text + "'  where Did=" + lblid.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Donor Updated successfully!");
            con.Close();

            reset();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Donor", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Donor");
            guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
            con.Close();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {

                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];

                lblid.Text = row.Cells["Did"].Value.ToString();
                txtname.Text = row.Cells["Dname"].Value.ToString();
                txtage.Text = row.Cells["Dage"].Value.ToString();
                txtph.Text = row.Cells["Dph"].Value.ToString();
                txtpn.Text = row.Cells["Dpin"].Value.ToString();
                cbbg.Text = row.Cells["Bbg"].Value.ToString();
                txtcty.Text = row.Cells["Dcty"].Value.ToString();
                cbgen.Text = row.Cells["Dgen"].Value.ToString();

            }
        }
    }
}
