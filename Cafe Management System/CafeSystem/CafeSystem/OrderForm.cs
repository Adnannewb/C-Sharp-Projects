using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class OrderForm : Form
    {
        private int userId;
        private decimal totalPrice = 0;

        public OrderForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadCategories();
            LoadMenuItems();
            SetupDataGridView();
        }

        // Set up the columns for dgvMenuItems and dgvCart
        private void SetupDataGridView()
        {
            // Setup columns for dgvCart (Item Name, Quantity, Price)
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("ItemName", "Item Name");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("Price", "Price");
        }

        private void LoadCategories()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = "SELECT DISTINCT item_category FROM Items";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbCategories.Items.Clear();
                    while (reader.Read())
                    {
                        cmbCategories.Items.Add(reader["item_category"].ToString());
                    }
                }
            }
        }

        // Load items into DataGridView, optionally filtering by category
        private void LoadMenuItems(string category = null)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = category == null
                ? "SELECT item_id, item_name, item_price FROM Items"
                : "SELECT item_id, item_name, item_price FROM Items WHERE item_category = @category";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (category != null)
                {
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMenuItems.DataSource = dt;
            }
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
        }

        // When category is selected, reload the menu items for that category
        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedItem != null)
            {
                string selectedCategory = cmbCategories.SelectedItem.ToString();
                LoadMenuItems(selectedCategory);
            }
            else
            {
                LoadMenuItems(); // Show all items if no category is selected
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please select a valid item and quantity.");
                return;
            }

            // Get the selected item details from the dgvMenuItems
            DataGridViewRow selectedRow = dgvMenuItems.SelectedRows[0];
            int itemId = Convert.ToInt32(selectedRow.Cells[0].Value); // item_id
            string itemName = selectedRow.Cells[1].Value.ToString();
            decimal itemPrice = Convert.ToDecimal(selectedRow.Cells[2].Value);

            decimal totalItemPrice = itemPrice * quantity;

            // Add to cart grid view
            dgvCart.Rows.Add(itemName, quantity, itemPrice); // Removed "Total" column
            totalPrice += totalItemPrice;
            lblTotalPrice.Text = $"Total Price: {totalPrice:C}";
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0 || cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please add items to the cart and select a payment method.");
                return;
            }

            string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert into Orders table
                string insertOrderQuery = "INSERT INTO Orders (user_id, total_price, payment_method) OUTPUT INSERTED.order_id VALUES (@userId, @totalPrice, @paymentMethod)";
                int orderId;
                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    orderId = (int)cmd.ExecuteScalar();
                }

                // Insert into OrderDetails table using item_name to fetch item_id
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (row.Cells["ItemName"].Value != null)
                    {
                        string itemName = row.Cells["ItemName"].Value.ToString();
                        int itemId = 0;

                        // Fetch item_id from Items table using item_name
                        string fetchItemIdQuery = "SELECT item_id FROM Items WHERE item_name = @itemName";
                        using (SqlCommand fetchCmd = new SqlCommand(fetchItemIdQuery, conn))
                        {
                            fetchCmd.Parameters.AddWithValue("@itemName", itemName);
                            object result = fetchCmd.ExecuteScalar();
                            if (result != null)
                            {
                                itemId = Convert.ToInt32(result);
                            }
                            else
                            {
                                MessageBox.Show("Item not found: " + itemName);
                                return;
                            }
                        }

                        // Insert into OrderDetails with fetched item_id
                        string insertOrderDetailsQuery = "INSERT INTO OrderDetails (order_id, item_id, quantity, price) VALUES (@orderId, @itemId, @quantity, @price)";
                        using (SqlCommand cmd = new SqlCommand(insertOrderDetailsQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@orderId", orderId);
                            cmd.Parameters.AddWithValue("@itemId", itemId); // Use fetched item_id
                            cmd.Parameters.AddWithValue("@quantity", row.Cells["Quantity"].Value); // Quantity
                            cmd.Parameters.AddWithValue("@price", row.Cells["Price"].Value); // Price
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Show success message and reset the form
            MessageBox.Show("Order placed successfully!");
            dgvCart.Rows.Clear();
            lblTotalPrice.Text = "Total Price: $0.00";
            totalPrice = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            loginform Form = new loginform();
            Form.Show();
            this.Close();

        }
    }
}
