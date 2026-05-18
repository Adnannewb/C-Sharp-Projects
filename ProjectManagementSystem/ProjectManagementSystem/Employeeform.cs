using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class Employeeform : Form
    {
        private string connectionString;

        public Employeeform()
        {
            InitializeComponent();

            
            if (ConfigurationManager.ConnectionStrings["ProjectManagementDB"] != null)
            {
                connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementDB"].ConnectionString;
            }
            else
            {
                MessageBox.Show("Database connection string is missing in the configuration file.");
                return;
            }

            try
            {
                
                LoadAssignments();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during initialization: {ex.Message}");
            }
        }
        private void LoadAssignments()
        {
            if (dgvAssignments == null) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT a.AssignmentID, t.TaskName, e.Name, a.AssignmentDate, a.Status " +
                        "FROM Assignments a " +
                        "JOIN Tasks t ON a.TaskID = t.TaskID " +
                        "JOIN Employees e ON a.EmployeeID = e.EmployeeID", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAssignments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading assignments: {ex.Message}");
            }
        }

        

        

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 back = new Form7();
                back.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning to home: {ex.Message}");
            }
        }
    }
}
