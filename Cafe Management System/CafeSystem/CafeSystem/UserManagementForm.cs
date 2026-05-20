using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class UserManagementForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            string query = "SELECT user_id, username, role, created_at FROM Users";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvUsers.DataSource = table;
                }
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text; // Hash passwords in production
            string role = cmbRole.SelectedItem.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "INSERT INTO Users (username, password, role) VALUES (@username, @password, @role)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User added successfully.");
            LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to update.");
                return;
            }

            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["user_id"].Value);
            string username = txtUsername.Text;
            string password = txtPassword.Text; // Hash passwords in production
            string role = cmbRole.SelectedItem.ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "UPDATE Users SET username = @username, password = @password, role = @role WHERE user_id = @userId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User updated successfully.");
            LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete.");
                return;
            }

            DataGridViewRow selectedRow = dgvUsers.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["user_id"].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "DELETE FROM Users WHERE user_id = @userId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User deleted successfully.");
            LoadUsers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard Form = new AdminDashboard();
            Form.Show();
            this.Close();

        }

    }
}
