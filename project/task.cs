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
using System.Xml.Linq;

namespace project
{
    public partial class task : Form
    {
        private int _userId;

        public task(int userId)
        {
            InitializeComponent();
            _userId = userId;

        }
        private void task_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtuser.Text) || string.IsNullOrWhiteSpace(txtpass.Text) || string.IsNullOrWhiteSpace(txtcpass.Text) || string.IsNullOrWhiteSpace(txtemail.Text))
            //{
            //    MessageBox.Show("There cannot be any empty fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False");
            con.Open();

            string query = "SELECT taskid,taskname,taskdescription,category,startdate,duedate,iscompleted FROM Tasks WHERE userid = '" + _userId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userid", _userId);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["taskid"].Value);

                
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteRecord(id);

                }
            }
        }
        private void DeleteRecord(int id)
        {
            // Replace with your actual connection string
            string connectionString = "Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False";
            string query = "DELETE FROM Tasks WHERE taskid = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            addtask atk = new addtask(_userId);
            atk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["taskid"].Value);
                label1.Text = id.ToString();
                int id1 = Convert.ToInt32(label1.Text);

                this.Hide();
                updatetask up = new updatetask(id1);
                up.Show();
            }
            else
            {
                MessageBox.Show("Please select a task to update.", "No Task Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataTable dt1;
        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False";
            string query = "SELECT taskid,taskname,taskdescription,category,startdate,duedate,iscompleted FROM Tasks WHERE userid = '" + _userId + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dt1 = new DataTable();
                dataAdapter.Fill(dt1);
                dataGridView1.DataSource = dt1;
            }


            string searchValue = txtsave.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(searchValue))
            {
                DataView dv = dt1.DefaultView;
                dv.RowFilter = string.Format("taskname LIKE '%{0}%' OR category LIKE '%{0}%'", searchValue);
                dataGridView1.DataSource = dv.ToTable();
            }
            else
            {
                dataGridView1.DataSource = dt1;
            }
        }
    }
    }
  

