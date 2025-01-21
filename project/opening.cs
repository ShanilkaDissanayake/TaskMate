using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class opening : Form
    {
        public opening()
        {
            InitializeComponent();
            timer1.Start();
        }

       

        private void opening_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 2;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                login l = new login();
                l.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
