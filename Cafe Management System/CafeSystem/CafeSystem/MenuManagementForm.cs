using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeSystem
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using System.Configuration;

    public partial class MenuManagementForm : Form
    {
        public MenuManagementForm()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "SELECT * FROM Items";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvMenu.DataSource = table;
                }
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text) || string.IsNullOrEmpty(txtItemPrice.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string itemName = txtItemName.Text;
            string category = cmbCategory.SelectedItem.ToString();
            if (!decimal.TryParse(txtItemPrice.Text, out decimal price))
            {
                MessageBox.Show("Enter a valid price.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "INSERT INTO Items (item_name, item_category, item_price) VALUES (@name, @category, @price)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", itemName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
            }

           
            MessageBox.Show("Item added successfully.");
            LoadMenuItems();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item to update.");
                return;
            }

            DataGridViewRow selectedRow = dgvMenu.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells["item_id"].Value);
            string itemName = txtItemName.Text;
            string category = cmbCategory.SelectedItem.ToString();
            if (!decimal.TryParse(txtItemPrice.Text, out decimal price))
            {
                MessageBox.Show("Enter a valid price.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "UPDATE Items SET item_name = @name, item_category = @category, item_price = @price WHERE item_id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", itemName);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", itemId);
                    cmd.ExecuteNonQuery();
                }
            }

           
            MessageBox.Show("Item updated successfully.");
            LoadMenuItems();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item to delete.");
                return;
            }

            DataGridViewRow selectedRow = dgvMenu.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells["item_id"].Value);

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "DELETE FROM Items WHERE item_id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", itemId);
                    cmd.ExecuteNonQuery();
                }
            }

           
            MessageBox.Show("Item deleted successfully.");
            LoadMenuItems();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard Form = new AdminDashboard();
            Form.Show();
            this.Close();

        }
    }

}
