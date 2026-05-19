using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
            this.Close();

        }

        private void btnManageBus_Click(object sender, EventArgs e)
        {
            manageBus manageBus = new manageBus();
            manageBus.Show();
            this.Close();

        }
        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingHistory form = new BookingHistory();
            form.Show();
            this.Close();

        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            Loginform loginForm = new Loginform();
            loginForm.Show();
            this.Close();

        }
    }
}
