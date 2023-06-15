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
    public partial class emp : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        void reset()
        {
            enameTb.Text = " ";
            epassTb.Text = " ";
            EphTxt.Text = " ";
            Eadrtxt.Text = " ";
            Edb.Text = string.Empty ;
        }
        public emp()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void emp_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            EmpDGV.DataSource = ds.Tables["Employee"].DefaultView;
            con.Close();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (epassTb.Text == "" || enameTb.Text == "")
            {
                MessageBox.Show("Missing Information !!!");

            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employee(Ename,Epass,Eph,Eadr,Edob)values(@AUL,@APL,@ANL,@AML,@AKL)", con);
                    cmd.Parameters.AddWithValue("@AUL", enameTb.Text);
                    cmd.Parameters.AddWithValue("@APL", epassTb.Text);
                    cmd.Parameters.AddWithValue("@ANL", EphTxt.Text);
                    cmd.Parameters.AddWithValue("@AML", Eadrtxt.Text);
                    cmd.Parameters.AddWithValue("@AKL", Edb.Value.ToString("yyyy/MM/dd"));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Data Inserted!");
                    con.Close();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Employee");
                    EmpDGV.DataSource = ds.Tables["Employee"].DefaultView;
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "delete from Employee where Eid='" + label1.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee deleted successfully!");
            con.Close();
            reset();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            EmpDGV.DataSource = ds.Tables["Employee"].DefaultView;
            con.Close();
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {

                DataGridViewRow row = this.EmpDGV.Rows[e.RowIndex];

                label1.Text = row.Cells["Eid"].Value.ToString();
                enameTb.Text = row.Cells["Ename"].Value.ToString();
                epassTb.Text = row.Cells["Epass"].Value.ToString();
                EphTxt.Text = row.Cells["Eph"].Value.ToString();
                Eadrtxt.Text= row.Cells["Eadr"].Value.ToString();
                Edb.Text=  row.Cells["Edob"].Value.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update Employee set Ename='" + enameTb.Text + "',Epass='" + epassTb.Text + "',Eph='"+EphTxt.Text+"',Eadr='"+Eadrtxt.Text+"',Edob='"+Edb.Value.ToString()+"' where Eid=" + label1.Text + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Updated successfully!");
            con.Close();
            reset();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            EmpDGV.DataSource = ds.Tables["Employee"].DefaultView;
            con.Close();
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
