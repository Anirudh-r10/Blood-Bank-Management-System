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
    public partial class MonthlyRpt : Form
    {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        public MonthlyRpt()
        {
            InitializeComponent();
        }

        
        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adMenu ad = new adMenu();
            ad.Show();
        }

        private void MonthlyRpt_Load(object sender, EventArgs e)
        {
            //con.Open();
             //string mdate = dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Year;
            // SqlDataAdapter sda = new SqlDataAdapter("select * from SalaryTbl where SalPeriod ='" + Periodd + "' ", Con);
            /*SqlDataAdapter da = new SqlDataAdapter("select count(*) from Bag where Bdate='"+mdate+"'", con);
            DataSet dt = new DataSet();
            da.Fill(dt);
            int mdate1 =Convert.ToInt32( dt.Tables[0].Rows[0][0].ToString());
            BagCnt.Text = mdate.ToString();

            SqlDataAdapter da1 = new SqlDataAdapter("select count(*) from Bag where BillDate='"+mdate+"'", con);
            DataSet dt1 = new DataSet();
            da1.Fill(dt1);
            label1.Text = dt1.Tables[0].Rows[0][0].ToString();*/

            //string Periodd = AttDate.Value.Month + "-" + AttDate.Value.Year;



        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            //string mdate =dateTimePicker1.Value.Day+"-"+dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Year;
            //string ndate = dateTimePicker2.Value.Day + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Year;
            string query = "select Did,Bid,BBg,Bdate,BillDate from Bag where Bdate between '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and '"+dateTimePicker2.Value.ToString("yyyy/MM/dd")+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataSet dt = new DataSet();
            sda.Fill(dt,"Bag");
            guna2DataGridView1.DataSource = dt.Tables["Bag"];

            //BagCnt.Text = dt.Rows[0][0].ToString();
            con.Close();
           int count= guna2DataGridView1.Rows.Count-1;
            BagCnt.Text = count.ToString();

            /*con.Open();
            string query1 = "select count(*) from Bag where Bdate between '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' and '" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "' and Bbil=1";
            SqlDataAdapter sda1 = new SqlDataAdapter(query, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt);
            int count1 = Convert.ToInt32(dt1.Tables[0].Rows[0][0].ToString());
            label1.Text = (count1).ToString();
            con.Close();*/
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BagCnt_Click(object sender, EventArgs e)
        {

        }
    }
}
