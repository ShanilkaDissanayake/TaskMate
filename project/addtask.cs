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

namespace project
{
    public partial class addtask : Form
    {
        private int _userId;
        public addtask(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False");
            con.Open();
            string insertQuery = "INSERT INTO Tasks VALUES (@userid,@taskname,@description,@category,@startdate,@duedate,@iscompleted)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@userid", _userId);
            cmd.Parameters.AddWithValue("@taskname", txtname.Text);
            cmd.Parameters.AddWithValue("@description", txtdesc.Text);
            cmd.Parameters.AddWithValue("@category", txtcat.Text);
            cmd.Parameters.AddWithValue("@startdate", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@duedate", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@iscompleted", comboBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Task Successfully Added", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            task tk = new task(_userId);
            tk.Show();  
        }

        private void addtask_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
