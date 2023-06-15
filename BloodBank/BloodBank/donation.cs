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
    public partial class donation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public donation()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void reset()
        {
            txtDonName.Text= " ";
            txtDonBg.Text = " ";


        }

        private void donation_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            String query = "select max(Did) from Donor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            count = count + 1;
            DidDonLbl.Text = (count).ToString();
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select Did,Bbg,Dname,Dph from Donor", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Donor");
                guna2DataGridView1.DataSource = ds.Tables["Donor"].DefaultView;
                con.Close();
            }
            else 
            {
                guna2DataGridView1.DataSource = -1;
            }

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {

                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];

                DidDonLbl.Text = row.Cells["Did"].Value.ToString();
                txtDonName.Text = row.Cells["Dname"].Value.ToString();
                txtDonBg.Text = row.Cells["Bbg"].Value.ToString();
                txtDonPh.Text = row.Cells["Dph"].Value.ToString();


            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            3if (txtDonName.Text == "" || txtDonPh.Text == "")
            {
                MessageBox.Show("Information missing!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtDonName.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters!");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtDonPh.Text, "^[0-9]{10}"))
            {
                MessageBox.Show("Please enter 10 digits!");
            }
            else
            {
                if (guna2CustomCheckBox1.Checked)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into Bag(Did,BBg,Bdate) values('" + DidDonLbl.Text + "','" + txtDonBg.Text + "','" + dateTimePicker1.Text + "')", con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Blood Bag Issued");
                    con.Close();
                }
                else
                {
                    con.Open();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("insert into Donor(Did,Dname,Bbg,Dph) values('" + DidDonLbl.Text + "','" + txtDonName.Text + "','" + txtDonBg.Text + "','" + txtDonPh.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand("insert into Bag(Did,BBg,Bdate) values('" + DidDonLbl.Text + "','" + txtDonBg.Text + "','" + dateTimePicker1.Text + "')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Blood Bag Issued");

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    con.Close();
                }


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            donation_Load(this, null);
            txtDonBg.Text = " ";
            txtDonName.Text = " ";
            txtDonPh.Text = " ";
        }
    }
}
