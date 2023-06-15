using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lg = new BloodBank.Login();
            lg.Show();
            this.Close();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDonor add = new AddDonor();
            add.Show();
           
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            donation dd = new donation();
            dd.Show();
            
        }

        private void displayAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            displayall dal = new displayall();
            dal.Show();

        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            searchLocation sl = new searchLocation();
            sl.Show();
        }

        private void bloodStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bloodStock bs = new bloodStock();
            bs.Show();
            
        }

        private void testResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tests ts = new tests();
            ts.Show();
            
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            billing bl = new billing();
            bl.Show();
        }

        private void donorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
