using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Fetch the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;

            string query = "INSERT INTO Users (username, password, role) VALUES (@username, @password, 'User')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration successful!");
                        loginform Form = new loginform();
                        Form.Show();
                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Username already exists.");
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            loginform Form = new loginform();
            Form.Show();
            this.Close();

        }
    }
}
