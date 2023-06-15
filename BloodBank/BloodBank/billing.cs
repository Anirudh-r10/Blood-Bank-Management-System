using DGVPrinterHelper;
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
    public partial class billing : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dell\\OneDrive\\Documents\\BB.mdf;Integrated Security=True;Connect Timeout=30");

        int count = 0;
        public billing()
        {
            InitializeComponent();
        }

        private void billing_Load(object sender, EventArgs e)
        {
            
            
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbbg_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Bid,BBg from Bag where BBg='"+cbbg.Text+"' and Bbil=0 and Bdis=1 and Btest=1", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            
           
            foreach (DataRow item in dt.Rows)
            {
                int n = guna2DataGridView3.Rows.Add();
                guna2DataGridView3.Rows[n].Cells[0].Value = item["Bid"].ToString();
                guna2DataGridView3.Rows[n].Cells[1].Value = item["BBg"].ToString();
                guna2DataGridView3.Rows[n].Cells[2].Value = false;
            }
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void noftxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in guna2DataGridView3.Rows)
            { 
                if ((bool)item.Cells[2].Value == true)

                {
                    

                    int n = guna2DataGridView2.Rows.Add();
                    guna2DataGridView2.Rows[n].Cells[0].Value = item.Cells[0].Value.ToString();
                    guna2DataGridView2.Rows[n].Cells[1].Value = item.Cells[1].Value.ToString();
                    count += 1;
                    totAmt.Text = (count * 650).ToString();

                }
                
        }

            

        }
           

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtTAmt_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView3_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)guna2DataGridView3.SelectedRows[0].Cells[2].Value == false)
                
            {
                guna2DataGridView3.SelectedRows[0].Cells[2].Value = true;
            }
           else
            {
                guna2DataGridView3.SelectedRows[0].Cells[2].Value = false;
            }
            
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
             guna2DataGridView2.Rows.Clear();
             guna2DataGridView3.Rows.Clear();
             cbbg.SelectedIndex = -1;
             totAmt.Text = " ";
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

            DGVPrinter print = new DGVPrinter();
            print.Title = "Blood Bank Bill";
            print.SubTitle = String.Format("Date:-{0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true; 
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount:" + totAmt.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView2);
            

            
            /*int[] arr = new int[20];
            for(int i = 1; i <= guna2DataGridView2.Rows.Count; i++)
            {

                 arr[i] =Convert.ToInt32( guna2DataGridView2.SelectedRows[i].Cells[0].Value);
                con.Open();
                string query = "update Bag set Bbil=1  where Bid='" + arr[i]+ "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }*/


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Bid,BBg from Bag where BBg='" + cbbg.Text + "' and Bbil=0", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int[] arr = new int[20];
            for (int i = 0; i <guna2DataGridView2.Rows.Count; i++)
            {
                arr[i] =Convert.ToInt32 (dt.Rows[i][0]); 
            }
            con.Close();

            con.Open();
            for (int i = 0; i <= guna2DataGridView2.Rows.Count; i++)
            {
                string query = "update Bag set Bbil=1,BillDate='"+dateTimePicker1.Text+"' where Bid='" + arr[i] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();

            guna2DataGridView3.DataSource = 0;
            cbbg.SelectedIndex = -1;
            totAmt.Text = " ";
            guna2DataGridView2.DataSource = 0;


        }

        private void guna2DataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           /* int sum = 0;
            sum = sum + 650;
            totAmt.Text = sum.ToString();*/
        }
    }

    }
