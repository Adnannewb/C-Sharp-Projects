using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class MealManagementForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;

        public MealManagementForm()
        {
            InitializeComponent();
            LoadMeals(); // Load meals into DataGridView on form load
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Meal (MealName, MealTime, Price) VALUES (@MealName, @MealTime, @Price)", con);
                    cmd.Parameters.AddWithValue("@MealName", txtMealName.Text);
                    cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.SelectedItem?.ToString() ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Meal added successfully!");
                ClearFields();
                LoadMeals(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMealID.Text))
            {
                MessageBox.Show("Please select a meal to update.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Meal SET MealName = @MealName, MealTime = @MealTime, Price = @Price WHERE MealID = @MealID", con);
                    cmd.Parameters.AddWithValue("@MealID", int.Parse(txtMealID.Text));
                    cmd.Parameters.AddWithValue("@MealName", txtMealName.Text);
                    cmd.Parameters.AddWithValue("@MealTime", cmbMealTime.SelectedItem?.ToString() ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Meal updated successfully!");
                ClearFields();
                LoadMeals(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMealID.Text))
            {
                MessageBox.Show("Please select a meal to delete.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Meal WHERE MealID = @MealID", con);
                    cmd.Parameters.AddWithValue("@MealID", int.Parse(txtMealID.Text));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Meal deleted successfully!");
                ClearFields();
                LoadMeals(); // Refresh DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadMeals(); // Load all meals into DataGridView
        }

        private void LoadMeals()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Meal", con);
                    DataTable mealTable = new DataTable();
                    adapter.Fill(mealTable);
                    dgvMeals.DataSource = mealTable; // Bind DataTable to DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvMeals_SelectionChanged(object sender, EventArgs e)
        {
            // Populate selected meal details into text fields
            if (dgvMeals.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMeals.SelectedRows[0];
                txtMealID.Text = selectedRow.Cells["MealID"].Value?.ToString();
                txtMealName.Text = selectedRow.Cells["MealName"].Value?.ToString();
                cmbMealTime.SelectedItem = selectedRow.Cells["MealTime"].Value?.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value?.ToString();
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Close();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtMealID.Clear();
            txtMealName.Clear();
            txtPrice.Clear();
            cmbMealTime.SelectedIndex = -1;
            dgvMeals.ClearSelection();
        }
    }
}
