using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class TransactionManagementForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;

        public TransactionManagementForm()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadDataGridView();
        }

        private void LoadComboBoxData()
        {
            // Load Students
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT StudentID, Name FROM Student", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var studentList = new List<dynamic>();
                    while (reader.Read())
                    {
                        studentList.Add(new { Text = reader["Name"].ToString(), Value = reader["StudentID"] });
                    }
                    cmbStudentID.DataSource = studentList;
                    cmbStudentID.DisplayMember = "Text";
                    cmbStudentID.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading student data: " + ex.Message);
                }
            }

            // Load Tokens
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT TokenID FROM Token", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var tokenList = new List<string>();
                    while (reader.Read())
                    {
                        tokenList.Add(reader["TokenID"].ToString());
                    }
                    cmbTokenID.DataSource = tokenList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading token data: " + ex.Message);
                }
            }

            // Load Meals
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MealID, MealName FROM Meal", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var mealList = new List<dynamic>();
                    while (reader.Read())
                    {
                        mealList.Add(new { Text = reader["MealName"].ToString(), Value = reader["MealID"] });
                    }
                    cmbMealID.DataSource = mealList;
                    cmbMealID.DisplayMember = "Text";
                    cmbMealID.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading meal data: " + ex.Message);
                }
            }
        }

        private void LoadDataGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Transactions", con); // Corrected table name
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvTransactions.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading transaction data: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbStudentID.SelectedItem == null || cmbTokenID.SelectedItem == null || cmbMealID.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Transactions (StudentID, TokenID, MealID, TransactionDate) VALUES (@StudentID, @TokenID, @MealID, @TransactionDate)", // Corrected table name
                        con
                    );
                    cmd.Parameters.AddWithValue("@StudentID", (cmbStudentID.SelectedItem as dynamic).Value);
                    cmd.Parameters.AddWithValue("@TokenID", cmbTokenID.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MealID", (cmbMealID.SelectedItem as dynamic).Value);
                    cmd.Parameters.AddWithValue("@TransactionDate", dtpTransactionDate.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction added successfully!");
                    LoadDataGridView();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding transaction: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTransactionID.Text))
            {
                MessageBox.Show("Please select a transaction to update.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Transactions SET StudentID = @StudentID, TokenID = @TokenID, MealID = @MealID, TransactionDate = @TransactionDate WHERE TransactionID = @TransactionID", // Corrected table name
                        con
                    );
                    cmd.Parameters.AddWithValue("@TransactionID", int.Parse(txtTransactionID.Text));
                    cmd.Parameters.AddWithValue("@StudentID", (cmbStudentID.SelectedItem as dynamic).Value);
                    cmd.Parameters.AddWithValue("@TokenID", cmbTokenID.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MealID", (cmbMealID.SelectedItem as dynamic).Value);
                    cmd.Parameters.AddWithValue("@TransactionDate", dtpTransactionDate.Value);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction updated successfully!");
                    LoadDataGridView();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating transaction: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTransactionID.Text))
            {
                MessageBox.Show("Please select a transaction to delete.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Transactions WHERE TransactionID = @TransactionID", // Corrected table name
                        con
                    );
                    cmd.Parameters.AddWithValue("@TransactionID", int.Parse(txtTransactionID.Text));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Transaction deleted successfully!");
                    LoadDataGridView();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting transaction: " + ex.Message);
                }
            }
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransactions.Rows[e.RowIndex];
                txtTransactionID.Text = row.Cells["TransactionID"].Value?.ToString();

                cmbStudentID.SelectedValue = row.Cells["StudentID"].Value;
                cmbTokenID.SelectedItem = row.Cells["TokenID"].Value;
                cmbMealID.SelectedValue = row.Cells["MealID"].Value;

                if (DateTime.TryParse(row.Cells["TransactionDate"].Value?.ToString(), out DateTime transactionDate))
                {
                    dtpTransactionDate.Value = transactionDate;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Close();
        }

        private void ClearFields()
        {
            txtTransactionID.Clear();
            cmbStudentID.SelectedIndex = -1;
            cmbTokenID.SelectedIndex = -1;
            cmbMealID.SelectedIndex = -1;
            dtpTransactionDate.Value = DateTime.Now;
        }
    }
}
