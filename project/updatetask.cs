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
    public partial class updatetask : Form
    {
        private int _userid;
        public updatetask(int userid)
        {
            InitializeComponent();
            _userid = userid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
         

            
            string updatedTaskName = txtname.Text;
            string updatedTaskDescription = txtdesc.Text;
            string updatedTaskCategory = txtcat.Text;
            string updatedTaskSdate = dateTimePicker1.Text;
            string updatedTaskDdate = dateTimePicker2.Text;
            string updatedTaskcompleted = comboBox1.Text;

          
            string connectionString = "Data Source=Inoflux;Initial Catalog=TaskMan;Integrated Security=True;Encrypt=False";
            string query = "UPDATE Tasks SET taskname = @TaskName, taskdescription = @TaskDescription, category = @category, startdate = @startdate,duedate=@Duedate,iscompleted=@iscompleted WHERE taskid = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskName", updatedTaskName);
                command.Parameters.AddWithValue("@TaskDescription", updatedTaskDescription);
                command.Parameters.AddWithValue("@category", updatedTaskCategory);
                command.Parameters.AddWithValue("@startdate", updatedTaskSdate);
                command.Parameters.AddWithValue("@duedate", updatedTaskDdate);
                command.Parameters.AddWithValue("@iscompleted", updatedTaskcompleted);
                command.Parameters.AddWithValue("@ID", _userid);

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Updated Successfully!");
            }
        }

        private void updatetask_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            task tk = new task(_userid);
            tk.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
