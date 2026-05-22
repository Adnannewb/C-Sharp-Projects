using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollManagementSystem
{
    public partial class ReportsForm : Form
    {
        // Connection string from App.config
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PayrollDBConnectionString"].ConnectionString;

        public ReportsForm()
        {
            InitializeComponent();
            LoadReports();
        }

        // Load all reports into DataGridView
        private void LoadReports()
        {
            string query = "SELECT * FROM Payment";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReports.DataSource = dt; // Assuming you have a DataGridView named dgvReports
            }
        }

        // View reports based on filters (e.g., by date)
        private void btnFilterReports_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Payment WHERE PaymentDate BETWEEN @StartDate AND @EndDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReports.DataSource = dt; // Update DataGridView with filtered data
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
