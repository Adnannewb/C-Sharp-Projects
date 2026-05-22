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
using System.Configuration;

namespace PayrollManagementSystem
{
    public partial class PayrollForm : Form
    {
        // Retrieve the connection string from App.config
        string connectionString = ConfigurationManager.ConnectionStrings["PayrollDBConnectionString"].ConnectionString;

        public PayrollForm()
        {
            InitializeComponent();
            LoadEmployees();
            LoadPayrolls();
        }

        // Load employees into ComboBox
        private void LoadEmployees()
        {
            string query = "SELECT EmployeeID, Name FROM Employee";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbEmployee.DataSource = dt; // Assuming you have a ComboBox named cmbEmployee
                cmbEmployee.DisplayMember = "Name";
                cmbEmployee.ValueMember = "EmployeeID";
            }
        }

        // Load payrolls into DataGridView
        private void LoadPayrolls()
        {
            string query = "SELECT * FROM Payroll";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayrolls.DataSource = dt; // Assuming you have a DataGridView named dgvPayrolls
            }
        }

        // Process payroll
        private void btnProcessPayroll_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee!");
                return;
            }

            string query = "INSERT INTO Payroll (EmployeeID, PayrollDate) VALUES (@EmployeeID, @PayrollDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@PayrollDate", dtpPayrollDate.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payroll processed successfully!");

                // Refresh DataGridView
                LoadPayrolls();
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
