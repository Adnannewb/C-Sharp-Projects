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

namespace OnlineBusTicket
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT UserID, Role FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["UserID"]);
                    string role = reader["Role"].ToString();
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (role == "Admin")
                    {
                        AdminDashboard admin = new AdminDashboard();
                        admin.Show();
                    }
                    else
                    {
                        CustomerDashboard customer = new CustomerDashboard(txtUsername.Text);
                        customer.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm(); 
            form.Show();
            this.Hide();
        }
    }
}
