using System;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnManageProjects_Click(object sender, EventArgs e)
        {
            Form2 projectsForm = new Form2(); 
            projectsForm.Show();
            this.Hide();
        }

       
        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            Form3 tasksForm = new Form3(); 
            tasksForm.Show();
            this.Hide();
        }

        
        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            Form4 employeesForm = new Form4(); 
            employeesForm.Show();
            this.Hide();
        }

        
        private void btnAssignment_Click(object sender, EventArgs e)
        {
            Form5 assignmentForm = new Form5(); 
            assignmentForm.Show(); 
            this.Hide();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            Environment.Exit(0);
        }



    }
}
