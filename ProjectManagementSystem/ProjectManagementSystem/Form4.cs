using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjectManagementSystem
{
    public partial class Form4 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementDB"].ConnectionString;

        public Form4()
        {
            InitializeComponent();
            LoadEmployees();
        }

        
        private void LoadEmployees()
        {
            string query = "SELECT * FROM Employees"; 
            DataTable employeesTable = ExecuteQuery(query);
            dataGridViewEmployees.DataSource = employeesTable;
        }

        // Add Employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            string position = txtPosition.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;

            string query = $"INSERT INTO Employees (Name, Position, Contact, Email) VALUES ('{employeeName}', '{position}', '{contact}', '{email}')";
            ExecuteNonQuery(query);

            LoadEmployees();  
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewEmployees.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dataGridViewEmployees.Rows[selectedRow].Cells[0].Value);  // Assuming ID is the first column

            string employeeName = txtEmployeeName.Text;
            string position = txtPosition.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;

            string query = $"UPDATE Employees SET Name = '{employeeName}', Position = '{position}', Contact = '{contact}', Email = '{email}' WHERE EmployeeID = {employeeId}";
            ExecuteNonQuery(query);

            LoadEmployees();  
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewEmployees.CurrentCell.RowIndex;
            int employeeId = Convert.ToInt32(dataGridViewEmployees.Rows[selectedRow].Cells[0].Value);  // Assuming ID is the first column

            string query = $"DELETE FROM Employees WHERE EmployeeID = {employeeId}";
            ExecuteNonQuery(query);

            LoadEmployees();  
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

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadEmployees();  
        }
    }
}
