using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace PayrollManagementSystem
{
    public partial class EmployeeForm : Form
    {
        // Retrieve the connection string from App.config
        string connectionString = ConfigurationManager.ConnectionStrings["PayrollDBConnectionString"].ConnectionString;

        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployees();
        }

        // Load employees into the DataGridView
        private void LoadEmployees()
        {
            string query = "SELECT * FROM Employee";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEmployees.DataSource = dt; // Assuming you have a DataGridView named dgvEmployees
            }
        }

        // Add new employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Employee (Name, Address, ContactInfo, EmployeeType, BasicSalary, HourlyRate) VALUES (@Name, @Address, @ContactInfo, @EmployeeType, @BasicSalary, @HourlyRate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);
                cmd.Parameters.AddWithValue("@EmployeeType", txtType.Text);
                cmd.Parameters.AddWithValue("@BasicSalary", Convert.ToDouble(txtSalary.Text));
                cmd.Parameters.AddWithValue("@HourlyRate", Convert.ToDouble(txtHourlyRate.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully!");

                // Refresh DataGridView
                LoadEmployees();
            }
        }

        // Edit selected employee
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                string query = "UPDATE Employee SET Name = @Name, Address = @Address, ContactInfo = @ContactInfo, EmployeeType = @EmployeeType, BasicSalary = @BasicSalary, HourlyRate = @HourlyRate WHERE EmployeeID = @EmployeeID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);
                    cmd.Parameters.AddWithValue("@EmployeeType", txtType.Text);
                    cmd.Parameters.AddWithValue("@BasicSalary", Convert.ToDouble(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@HourlyRate", Convert.ToDouble(txtHourlyRate.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee updated successfully!");

                    // Refresh DataGridView
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit!");
            }
        }

        // Delete selected employee
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully!");

                    // Refresh DataGridView
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete!");
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.Show();
            this.Hide();
                    
            
        }
    }
}
