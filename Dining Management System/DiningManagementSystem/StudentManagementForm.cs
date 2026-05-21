using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class StudentManagementForm : Form
    {
        // Directly retrieve the connection string from the App.config
        private string ConnectionString => ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;

        public StudentManagementForm()
        {
            InitializeComponent();
            LoadStudents();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Student (Name, RollNumber, Class, Contact, Address) VALUES (@Name, @RollNumber, @Class, @Contact, @Address)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@RollNumber", txtRollNumber.Text);
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student added successfully.");
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Student";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Student SET Name = @Name, Class = @Class, Contact = @Contact, Address = @Address WHERE RollNumber = @RollNumber";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@RollNumber", txtRollNumber.Text);
                    cmd.Parameters.AddWithValue("@Class", txtClass.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student updated successfully.");
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Student WHERE RollNumber = @RollNumber";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RollNumber", txtRollNumber.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student deleted successfully.");
                    LoadStudents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
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
