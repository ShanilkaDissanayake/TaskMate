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
using System.Data.SqlClient;

namespace project
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text;
            string password = txtpass.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection("Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False");
                con.Open();
                string query = "SELECT * FROM Users WHERE username = '" + txtuser.Text +"' AND password = '"+txtpass.Text+"'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                var userId = cmd.ExecuteScalar();

                if (userId != null)
                {
                    // Store the UserID for later use
                    int loggedInUserId = Convert.ToInt32(userId);
                    MessageBox.Show("Login successful!");
                    this.Hide();

                    task tk = new task(loggedInUserId);
                    tk.Show();


                }

                else
                {
                    MessageBox.Show("Invalid username or password.");
                }

            }
            catch (SqlException ex)
               {

                  MessageBox.Show("Error: " + ex.Message);
               }

                }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                txtpass.UseSystemPasswordChar = true;
               
            }
            else
            {

                txtpass.UseSystemPasswordChar = false;
            
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
   
