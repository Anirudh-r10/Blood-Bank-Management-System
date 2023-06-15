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
    public partial class adMenu : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public adMenu()
        {
            InitializeComponent();
        }

        private void adMenu_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from Donor", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DnrCnt.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter da1 = new SqlDataAdapter("select count(*) from Bag",con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            BagCnt.Text = dt1.Rows[0][0].ToString();


            con.Close();

        }

        private void guna2GradientPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {
           
            
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            donorDetails dt = new donorDetails();
            dt.Show();
            
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2GradientPanel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2GradientPanel2_MouseClick(object sender, MouseEventArgs e)
        {
            searchLocation src = new searchLocation();
            src.Show();

        }

        private void guna2GradientPanel7_MouseClick(object sender, MouseEventArgs e)
        {
            BagDetails bg = new BagDetails();
            bg.Show();
        }

        private void guna2GradientPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            bloodStock bs = new bloodStock();
            bs.Show();
        }

        private void guna2GradientPanel4_MouseClick(object sender, MouseEventArgs e)
        {
            emp1 em = new emp1();
            em.Show();
        }

        private void guna2GradientPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel6_MouseClick(object sender, MouseEventArgs e)
        {

            MonthlyRpt mn = new MonthlyRpt();
            mn.Show();
        }

        private void guna2GradientPanel6_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
