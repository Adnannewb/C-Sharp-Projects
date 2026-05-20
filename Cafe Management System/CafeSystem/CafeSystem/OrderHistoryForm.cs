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
    public partial class OrderHistoryForm : Form
    {
        public OrderHistoryForm()
        {
            InitializeComponent();
            LoadOrderHistory(); // Load all orders initially
        }

        private void LoadOrderHistory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = @"
            SELECT o.order_id, u.username, o.order_date, o.total_price, o.payment_method
            FROM Orders o
            INNER JOIN Users u ON o.user_id = u.user_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOrders.DataSource = table; // Bind data to DataGridView
                }
            }
        }

        private void btnFilterOrders_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;
            string query = @"
            SELECT o.order_id, u.username, o.order_date, o.total_price, o.payment_method
            FROM Orders o
            INNER JOIN Users u ON o.user_id = u.user_id
            WHERE o.order_date BETWEEN @startDate AND @endDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvOrders.DataSource = table; // Update DataGridView with filtered data
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard Form = new AdminDashboard();
            Form.Show();
            this.Close();

        }
    }
}
