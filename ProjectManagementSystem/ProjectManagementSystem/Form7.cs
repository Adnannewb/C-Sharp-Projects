using System;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class Form7 : Form
    {
        

        public Form7()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            
            
                AdminLogin adminForm = new AdminLogin(); 
                adminForm.Show();
                this.Hide(); 
            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {

            Employeeform employeesForm = new Employeeform(); 
            employeesForm.Show();
            this.Hide();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Environment.Exit(0);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        
    }
}
