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
using System.Xml.Linq;

namespace OnlineBusTicket
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "INSERT INTO Users (Name, Phone, Username, Password, Role) VALUES (@Name, @Phone, @Username, @Password, 'Customer')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loginform loginform = new Loginform();
                    loginform.Show();
                    this.Close();
                }
                catch (SqlException )
                {
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            Loginform loginform = new Loginform();
            loginform.Show();
            this.Close();

        }
    }
}
