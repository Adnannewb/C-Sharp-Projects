using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            // Open Employee Management Form
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
            this.Close();
        }

        private void btnProcessPayroll_Click(object sender, EventArgs e)
        {
            // Open Payroll Processing Form
            PayrollForm payrollForm = new PayrollForm();
            payrollForm.Show();
            this.Close();
        }

        private void btnManagePayments_Click(object sender, EventArgs e)
        {
            // Open Payment Management Form
            PaymentForm paymentForm = new PaymentForm();
            paymentForm.Show();
            this.Close();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            // Open Reports Viewing Form
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
            this.Close();
        }
    }
}
