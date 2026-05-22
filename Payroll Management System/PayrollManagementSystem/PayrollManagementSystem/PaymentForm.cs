using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PayrollManagementSystem
{
    public partial class PaymentForm : Form
    {
        // Connection string from App.config
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PayrollDBConnectionString"].ConnectionString;

        public PaymentForm()
        {
            InitializeComponent();
            LoadPayments();
            LoadEmployees();
        }

        // Load payments into DataGridView
        private void LoadPayments()
        {
            string query = "SELECT * FROM Payment";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.DataSource = dt; // Assuming you have a DataGridView named dgvPayments
            }
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

        // Save payment logic
        private void btnSavePayment_Click(object sender, EventArgs e)
        {
            try
            {
                double grossPay = Convert.ToDouble(txtGrossPay.Text);
                double deductions = Convert.ToDouble(txtDeductions.Text);
                double netPay = grossPay - deductions;

                string query = "INSERT INTO Payment (EmployeeID, GrossPay, NetPay, Deductions, PaymentDate, OvertimeHours) " +
                               "VALUES (@EmployeeID, @GrossPay, @NetPay, @Deductions, @PaymentDate, @OvertimeHours)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", cmbEmployee.SelectedValue);
                    cmd.Parameters.AddWithValue("@GrossPay", grossPay);
                    cmd.Parameters.AddWithValue("@NetPay", netPay);
                    cmd.Parameters.AddWithValue("@Deductions", deductions);
                    cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                    cmd.Parameters.AddWithValue("@OvertimeHours", Convert.ToDouble(txtOvertimeHours.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment saved successfully!");

                    // Refresh payments in DataGridView
                    LoadPayments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message);
            }
        }

        // Delete selected payment
        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                int paymentID = Convert.ToInt32(dgvPayments.SelectedRows[0].Cells["PaymentID"].Value); // Assuming PaymentID is a column

                string query = "DELETE FROM Payment WHERE PaymentID = @PaymentID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment deleted successfully!");

                    // Refresh payments in DataGridView
                    LoadPayments();
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to delete.");
            }
        }

        // Edit selected payment
        private void btnEditPayment_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                int paymentID = Convert.ToInt32(dgvPayments.SelectedRows[0].Cells["PaymentID"].Value); // Assuming PaymentID is a column

                string query = "UPDATE Payment SET GrossPay = @GrossPay, NetPay = @NetPay, Deductions = @Deductions, " +
                               "PaymentDate = @PaymentDate, OvertimeHours = @OvertimeHours WHERE PaymentID = @PaymentID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PaymentID", paymentID);
                    cmd.Parameters.AddWithValue("@GrossPay", Convert.ToDouble(txtGrossPay.Text));
                    cmd.Parameters.AddWithValue("@NetPay", Convert.ToDouble(txtGrossPay.Text) - Convert.ToDouble(txtDeductions.Text));
                    cmd.Parameters.AddWithValue("@Deductions", Convert.ToDouble(txtDeductions.Text));
                    cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value);
                    cmd.Parameters.AddWithValue("@OvertimeHours", Convert.ToDouble(txtOvertimeHours.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment updated successfully!");

                    // Refresh payments in DataGridView
                    LoadPayments();
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to edit.");
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
