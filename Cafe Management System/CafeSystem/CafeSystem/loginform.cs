using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CafeSystem
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Fetch the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;

            string query = "SELECT * FROM Users WHERE username = @username AND password = @password AND role = @role";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Close();
                        if (role == "Admin")
                        {
                            AdminDashboard adminForm = new AdminDashboard();
                            adminForm.Show();
                        }
                        else
                        {
                            OrderForm orderForm = new OrderForm(GetUserId(username));
                            orderForm.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials.");
                    }
                }
            }
        }

        private int GetUserId(string username)
        {
            // Fetch the connection string from App.config
            string connectionString = ConfigurationManager.ConnectionStrings["CafeDBConnectionString"].ConnectionString;

            string query = "SELECT user_id FROM Users WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm Form = new RegistrationForm();
            Form.Show();
            this.Hide();

        }



    }
}
