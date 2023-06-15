using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class searchLocation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public searchLocation()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void searchLocation_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Donor", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Donor");
            guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
            con.Close();

        }

        private void svebtn_Click(object sender, EventArgs e)
        {
           

        }

        private void txtSearchLoc_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchLoc.Text != "")
            {

                con.Open();
                string query = "select * from Donor where Dcty Like '" + txtSearchLoc.Text + " % ' or Dpin Like '" + txtSearchLoc.Text + " % ' ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Donor");
                guna2DataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else if(txtAgeSrch.Text!="")
            {
                

                    con.Open();
                    string query = "select * from Donor where Dage Like '" + txtAgeSrch.Text + " % ' ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Donor");
                    guna2DataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                
                
            }
            else if(txtBgSrch.Text!="")
            {
                con.Open();
                string query = "select * from Donor where Bbg Like '" + txtBg.Text + " % ' ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Donor");
                guna2DataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from Donor", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Donor");
                guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
                con.Close();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}


