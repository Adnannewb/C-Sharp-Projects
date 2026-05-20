using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            UserManagementForm Form = new UserManagementForm();
            Form.Show();
            this.Close();

        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderHistoryForm Form = new OrderHistoryForm();
            Form.Show();
            this.Close();

        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuManagementForm Form = new MenuManagementForm();
            Form.Show();
            this.Close();

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            loginform Form = new loginform();
            Form.Show();
            this.Close();

        }
    }
}
