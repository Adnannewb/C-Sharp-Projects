using System;
using System.Windows.Forms;
using Officer;

namespace AirportManagementSystem
{
    public partial class Officer_Dashboard : Form
    {
        public Officer_Dashboard()
        {
            InitializeComponent();
        }

        private void OfficerDashboard_Load(object sender, EventArgs e)
        {
            // Form Settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // button1 = Add User
        private void button1_Click(object sender, EventArgs e)
        {
            Officer_add_user form = new Officer_add_user();
            form.Show();
            this.Hide();
        }

        // button2 = View User
        private void button4_Click(object sender, EventArgs e)
        {
            Officer_view_user form = new Officer_view_user();
            form.Show();
            this.Hide();
        }

        // button3 = Booking
        private void button2_Click(object sender, EventArgs e)
        {
            Officer_booking form = new Officer_booking();
            form.Show();
            this.Hide();
        }

        // button4 = View Booking
        private void button3_Click(object sender, EventArgs e)
        {
            Officer_view_booking form = new Officer_view_booking();
            form.Show();
            this.Hide();
        }

        // button5 = Logout
        private void button5_Click(object sender, EventArgs e)
        {
            Officer_Login form = new Officer_Login();
            form.Show();
            this.Hide();
        }
    }
}