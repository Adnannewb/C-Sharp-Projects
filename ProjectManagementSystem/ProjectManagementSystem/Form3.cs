using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectManagementSystem
{
    public partial class Form3 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementDB"].ConnectionString;

        public Form3()
        {
            InitializeComponent();
            LoadTasks();
            InitializeStatusComboBox();
            LoadProjects();
        }

        private void LoadTasks()
        {
            string query = "SELECT * FROM Tasks";
            DataTable tasksTable = ExecuteQuery(query);
            dataGridViewTasks.DataSource = tasksTable;
        }

        private void LoadProjects()
        {
            string query = "SELECT ProjectID, ProjectName FROM Projects"; 
            DataTable projectsTable = ExecuteQuery(query);

            cmbProjectName.DataSource = projectsTable;
            cmbProjectName.DisplayMember = "ProjectName"; 
            cmbProjectName.ValueMember = "ProjectID"; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string taskName = txtTaskName.Text;
            DateTime dueDate = dateTimePickerDueDate.Value;
            string status = cmbStatus.SelectedItem.ToString();
            int projectID = Convert.ToInt32(cmbProjectName.SelectedValue); 

            string query = $"INSERT INTO Tasks (TaskName, DueDate, Status, ProjectID) VALUES ('{taskName}', '{dueDate}', '{status}', {projectID})";
            ExecuteNonQuery(query);

            LoadTasks();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewTasks.CurrentCell.RowIndex;
            int taskId = Convert.ToInt32(dataGridViewTasks.Rows[selectedRow].Cells[0].Value);

            string taskName = txtTaskName.Text;
            DateTime dueDate = dateTimePickerDueDate.Value;
            string status = cmbStatus.SelectedItem.ToString();
            int projectID = Convert.ToInt32(cmbProjectName.SelectedValue);

            string query = $"UPDATE Tasks SET TaskName = '{taskName}', DueDate = '{dueDate}', Status = '{status}', ProjectID = {projectID} WHERE TaskID = {taskId}";
            ExecuteNonQuery(query);

            LoadTasks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewTasks.CurrentCell.RowIndex;
            int taskId = Convert.ToInt32(dataGridViewTasks.Rows[selectedRow].Cells[0].Value);

            string query = $"DELETE FROM Tasks WHERE TaskID = {taskId}";
            ExecuteNonQuery(query);

            LoadTasks();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void InitializeStatusComboBox()
        {
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("On Hold");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;
        }
    }
}
