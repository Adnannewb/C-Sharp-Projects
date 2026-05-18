using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class AdminLogin : Form
    {
        private const string AdminPassword = "admin123";
        public AdminLogin()
        {
            InitializeComponent();
        }
        

        

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            string enteredPassword = txtPassword.Text;

            if (enteredPassword == AdminPassword)
            {
                Form1 adminForm = new Form1();
                adminForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect password! Access denied.", "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }
    }
}
