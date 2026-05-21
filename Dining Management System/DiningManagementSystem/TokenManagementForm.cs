using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class TokenManagementForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;

        public TokenManagementForm()
        {
            InitializeComponent();
            LoadStudents(); // Load Students into ComboBox on form load
            LoadTokens();   // Load Tokens into DataGridView on form load
        }

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT StudentID, Name FROM Student", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbStudentID.Items.Add(new ComboBoxItem
                    {
                        Text = reader["Name"].ToString(),
                        Value = reader["StudentID"]
                    });
                }
            }
        }

        private void LoadTokens()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT TokenID, StudentID, TokenDate, Status FROM Token", con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvTokens.DataSource = dataTable; // Bind the DataTable to the DataGridView
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Token (StudentID, TokenDate, Status) VALUES (@StudentID, @TokenDate, @Status)", con);
                cmd.Parameters.AddWithValue("@StudentID", ((ComboBoxItem)cmbStudentID.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@TokenDate", dtpTokenDate.Value);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Token added successfully!");
            ClearFields();
            LoadTokens(); // Reload DataGridView
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTokenID.Text))
            {
                MessageBox.Show("Please select a token to update.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Token SET StudentID = @StudentID, TokenDate = @TokenDate, Status = @Status WHERE TokenID = @TokenID", con);
                cmd.Parameters.AddWithValue("@StudentID", ((ComboBoxItem)cmbStudentID.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@TokenDate", dtpTokenDate.Value);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
                cmd.Parameters.AddWithValue("@TokenID", int.Parse(txtTokenID.Text));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Token updated successfully!");
            ClearFields();
            LoadTokens(); // Reload DataGridView
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTokenID.Text))
            {
                MessageBox.Show("Please select a token to delete.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Token WHERE TokenID = @TokenID", con);
                cmd.Parameters.AddWithValue("@TokenID", int.Parse(txtTokenID.Text));
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Token deleted successfully!");
            ClearFields();
            LoadTokens(); // Reload DataGridView
        }

        private void dgvTokens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure the clicked row is valid
            {
                DataGridViewRow row = dgvTokens.Rows[e.RowIndex];
                txtTokenID.Text = row.Cells["TokenID"].Value.ToString();
                cmbStudentID.SelectedItem = cmbStudentID.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Value.ToString() == row.Cells["StudentID"].Value.ToString());
                dtpTokenDate.Value = Convert.ToDateTime(row.Cells["TokenDate"].Value);
                txtStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            AdminDashboard form = new AdminDashboard();
            form.Show();
            this.Close();

        }

        private void ClearFields()
        {
            txtTokenID.Clear();
            txtStatus.Clear();
            cmbStudentID.SelectedIndex = -1;
            dtpTokenDate.Value = DateTime.Now;
        }
    }

    // Custom class for ComboBox items to store both Text and Value
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
