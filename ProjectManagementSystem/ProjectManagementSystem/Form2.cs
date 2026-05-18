using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using System.Windows.Forms.VisualStyles;

namespace ProjectManagementSystem
{
    public partial class Form2 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementDB"].ConnectionString;

        public Form2()
        {
            InitializeComponent();
            LoadProjects();
            InitializeStatusComboBox();
        }

        
        private void LoadProjects()
        {
            string query = "SELECT * FROM Projects";
            DataTable projectsTable = ExecuteQuery(query);
            dataGridViewProjects.DataSource = projectsTable;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string projectName = txtProjectName.Text;
            DateTime startDate = dateTimePickerStartDate.Value;
            DateTime endDate = dateTimePickerEndDate.Value;
            string status = cmbStatus.SelectedItem.ToString();

            string query = $"INSERT INTO Projects (ProjectName, StartDate, EndDate, Status) VALUES ('{projectName}', '{startDate}', '{endDate}', '{status}')";
            ExecuteNonQuery(query);

            LoadProjects();  
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewProjects.CurrentCell.RowIndex;
            int projectId = Convert.ToInt32(dataGridViewProjects.Rows[selectedRow].Cells[0].Value);  

            string projectName = txtProjectName.Text;
            DateTime startDate = dateTimePickerStartDate.Value;
            DateTime endDate = dateTimePickerEndDate.Value;
            string status = cmbStatus.SelectedItem.ToString();

            string query = $"UPDATE Projects SET ProjectName = '{projectName}', StartDate = '{startDate}', EndDate = '{endDate}', Status = '{status}' WHERE ProjectID = {projectId}";
            ExecuteNonQuery(query);

            LoadProjects(); 
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewProjects.CurrentCell.RowIndex;
            int projectId = Convert.ToInt32(dataGridViewProjects.Rows[selectedRow].Cells[0].Value);  

            string query = $"DELETE FROM Projects WHERE ProjectID = {projectId}";
            ExecuteNonQuery(query);

            LoadProjects();  
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



        private void Form2_Load(object sender, EventArgs e)
        {
            
            LoadProjects();
        }
        private void InitializeStatusComboBox()
        {
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("On Hold");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;  
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
