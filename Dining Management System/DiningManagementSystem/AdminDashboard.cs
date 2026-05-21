using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        private void btnmeal_Click(object sender, EventArgs e)
        {
            MealManagementForm form = new MealManagementForm();
            form.Show();
            this.Close();

        }
        private void btntoken_Click(object sender, EventArgs e)
        {
           TokenManagementForm form = new TokenManagementForm();
            form.Show();
            this.Close();

        }
        private void btnstudent_Click(object sender, EventArgs e)
        {
            StudentManagementForm form = new StudentManagementForm();
            form.Show();
            this.Close();

        }
        private void btnstaff_Click(object sender, EventArgs e)
        {
            StaffManagementForm form = new StaffManagementForm();
            form.Show();
            this.Close();

        }
        private void btntransactions_Click(object sender, EventArgs e)
        {
            TransactionManagementForm form = new TransactionManagementForm();
            form.Show();
            this.Close();

        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Close();

        }
    }

}