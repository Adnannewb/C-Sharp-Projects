using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class StaffManagementForm : Form
    {
        private readonly string connectionString;

        public StaffManagementForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;
            LoadDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Staff (Name, Role, Contact, Address) VALUES (@Name, @Role, @Contact, @Address)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Role", txtRole.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Staff added successfully!");
                LoadDataGridView();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffID.Text))
            {
                MessageBox.Show("Please select a staff member to update.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Staff SET Name = @Name, Role = @Role, Contact = @Contact, Address = @Address WHERE StaffID = @StaffID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StaffID", int.Parse(txtStaffID.Text));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Role", txtRole.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Staff updated successfully!");
                LoadDataGridView();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStaffID.Text))
            {
                MessageBox.Show("Please select a staff member to delete.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Staff WHERE StaffID = @StaffID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@StaffID", int.Parse(txtStaffID.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Staff deleted successfully!");
                LoadDataGridView();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Staff";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStaff.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        private void ClearFields()
        {
            txtStaffID.Clear();
            txtName.Clear();
            txtRole.Clear();
            txtContact.Clear();
            txtAddress.Clear();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                txtStaffID.Text = row.Cells["StaffID"].Value?.ToString();
                txtName.Text = row.Cells["Name"].Value?.ToString();
                txtRole.Text = row.Cells["Role"].Value?.ToString();
                txtContact.Text = row.Cells["Contact"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Close();

        }
    }
}
