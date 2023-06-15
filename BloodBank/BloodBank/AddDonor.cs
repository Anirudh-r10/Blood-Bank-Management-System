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
    public partial class AddDonor : Form
    {
        public AddDonor()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        void reset()
        {
            txtage.Text = " ";
            txtnme.Text = " ";
            txtcty.Text = " ";
            txtph.Text = " ";
            txtpn.Text = " ";

            cbgen.SelectedIndex = -1;
            cbbg.SelectedIndex = -1;


        }
        private void label3_Click(object sender, EventArgs e)
        {



        }

        private void AddDonor_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            String query = "select max(Did) from Donor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            count = count + 1;

            lblid.Text = (count).ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        private void label10_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtage.Text == "" || txtnme.Text == "" || txtcty.Text == "" || txtph.Text == "" || txtpn.Text == "" || cbbg.Text == " " || cbgen.Text == "")
            {
                MessageBox.Show("Information missing!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtnme.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters!");
            }

            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtph.Text, "^[0-9]{10}"))
            {
                MessageBox.Show("Please enter 10 digits!");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Donor (Did,Dname,Dage,Dph,Dcty,Bbg,Dgen,Dpin) values('" + lblid.Text + "','" + txtnme.Text + "', '" + txtage.Text + "', '" + txtph.Text + "','" + txtcty.Text + "','" + cbbg.Text + "','" + cbgen.Text + "','" + txtpn.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Registered.");
                    con.Close();
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            AddDonor_Load(this, null);
        }

        private void txtph_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtnme_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtph_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void txtnme_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }
    }
}
