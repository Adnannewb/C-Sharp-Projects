using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollManagementSystem
{
    public partial class LoginForm : Form
    {
        // Retrieve the connection string from App.config
        string connectionString = ConfigurationManager.ConnectionStrings["PayrollDBConnectionString"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Query to validate the user
            string query = "SELECT COUNT(*) FROM Admin WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                    // Open connection
                    conn.Open();

                    // Execute the query
                    int count = (int)cmd.ExecuteScalar();

                    // Check if credentials are valid
                    if (count == 1)
                    {
                        MessageBox.Show("Login successful!");
                        this.Hide();

                        // Open Admin Dashboard
                        AdminDashboard dashboard = new AdminDashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message in case of an exception
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
