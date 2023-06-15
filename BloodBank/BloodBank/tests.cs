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
    public partial class tests : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public tests()
        {
            InitializeComponent();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tests_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Did,Bid,BBg from Bag where Btest=0", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Bag");
            guna2DataGridView1.DataSource = ds.Tables["Bag"].DefaultView;
            con.Close();
          
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {

                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];

                DidTestLbl.Text = row.Cells["Bid"].Value.ToString();
                
                bunifuMaterialTextbox2.Text = row.Cells["BBg"].Value.ToString();
                

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "" || guna2ComboBox2.Text == "" || guna2ComboBox3.Text == "" || guna2ComboBox4.Text == "" || guna2ComboBox5.Text == "" || guna2ComboBox6.Text == "" || guna2ComboBox7.Text == "")
            {
                MessageBox.Show("Enter test result.");
            }
            else
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Bag set hepB='" + guna2ComboBox1.Text + "',hepA='" + guna2ComboBox2.Text + "' ,hiv1='" + guna2ComboBox3.Text + "',hiv2='" + guna2ComboBox4.Text + "', htlv='" + guna2ComboBox5.Text + "', syph='" + guna2ComboBox6.Text + "', wnv='" + guna2ComboBox7.Text + "', Btest=1 where Bid=" + DidTestLbl.Text + " ", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Result Updated");
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

                if (guna2ComboBox1.Text == "Negetive" || guna2ComboBox2.Text == "Negetive" || guna2ComboBox3.Text == "Negetive" || guna2ComboBox4.Text == "Negetive" || guna2ComboBox5.Text == "Negetive" || guna2ComboBox6.Text == "Negetive" || guna2ComboBox7.Text == "Negetive")
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Bag set Bdis=1 where Bid=" + DidTestLbl.Text + " ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                }
                
                guna2ComboBox1.SelectedIndex = -1;
                guna2ComboBox2.SelectedIndex = -1;
                guna2ComboBox3.SelectedIndex = -1;
                guna2ComboBox4.SelectedIndex = -1;
                guna2ComboBox5.SelectedIndex = -1;
                guna2ComboBox6.SelectedIndex = -1;
                guna2ComboBox7.SelectedIndex = -1;

            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            guna2ComboBox6.SelectedIndex = -1;
            guna2ComboBox7.SelectedIndex = -1;
        }
    }
}
