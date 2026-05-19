using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  // For ConfigurationManager
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            LoadData();
        }

        // Method to load data into DataGridView
        private void LoadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT UserID, Name, Phone, Username, Role FROM Users", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        // Add button click event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Name, Phone, Username, Password, Role) VALUES (@Name, @Phone, @Username, @Password, @Role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);  // Ensure you hash the password in a real app
                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());  // Role from ComboBox

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        // Edit button click event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);  // Get selected UserID
            string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Name = @Name, Phone = @Phone, Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);  // Ensure you hash the password in a real app
                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());  // Role from ComboBox

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        // Delete button click event
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);  // Get selected UserID
            string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        // Back button click event (e.g., closes the form)
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        // DataGridView row selection event (to fill textboxes with selected user's data)
        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                txtName.Text = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();
                txtPhone.Text = dgvUsers.SelectedRows[0].Cells[2].Value.ToString();
                txtUsername.Text = dgvUsers.SelectedRows[0].Cells[3].Value.ToString();
                cmbRole.SelectedItem = dgvUsers.SelectedRows[0].Cells[4].Value.ToString();  // Set selected role
            }
        }

        // Form load event to populate DataGridView on form load
        
    }
}
