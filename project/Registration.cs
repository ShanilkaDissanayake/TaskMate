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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace project
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtpass.Text) || string.IsNullOrWhiteSpace(txtcpass.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("There cannot be any empty fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtpass.Text != txtcpass.Text)
            {
                MessageBox.Show("Password does not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool a = txtemail.Text.Contains("@") && txtemail.Text.Contains(".");
            if (!a)
            {
                MessageBox.Show("Enter valid email", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False");
            con.Open();
            string insertQuery = "INSERT INTO Users VALUES (@name,@email,@username,@password,@cpassword)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@password", txtpass.Text);
            cmd.Parameters.AddWithValue("@cpassword", txtcpass.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registrarion Successfully", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            login l = new login();

            l.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
                txtpass.UseSystemPasswordChar = true;
                txtcpass.UseSystemPasswordChar = true;
            }
            else
            {
               
                txtpass.UseSystemPasswordChar = false;
                txtcpass.UseSystemPasswordChar = false;
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
