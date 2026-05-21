using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class LoginForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DiningManagementDBConnection"].ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Role FROM [User] WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    object role = cmd.ExecuteScalar();
                    if (role != null)
                    {
                        string userRole = role.ToString();
                        MessageBox.Show($"Welcome, {userRole}!");
                        // Open appropriate dashboard based on the role
                        this.Hide();
                        if (userRole == "Admin")
                        {
                            new AdminDashboard().Show();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
