using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ProjectManagementSystem
{
    public partial class Form5 : Form
    {
        
        private string connectionString = ConfigurationManager.ConnectionStrings["ProjectManagementDB"].ConnectionString;

        public Form5()
        {
            InitializeComponent();
            LoadProjects();
            LoadEmployees();
            LoadAssignments();
            InitializeStatusComboBox();
        }
        private void LoadProjects()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProjectID, ProjectName FROM Projects", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbProjects.DataSource = dt;
                cmbProjects.DisplayMember = "ProjectName";
                cmbProjects.ValueMember = "ProjectID";
            }

            cmbProjects.SelectedIndexChanged += CmbProjects_SelectedIndexChanged; 
        }



        private void LoadTasks(int projectID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT TaskID, TaskName FROM Tasks WHERE ProjectID = @ProjectID", con);
                da.SelectCommand.Parameters.AddWithValue("@ProjectID", projectID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbTasks.DataSource = dt;
                cmbTasks.DisplayMember = "TaskName";
                cmbTasks.ValueMember = "TaskID";
            }
        }
        private void CmbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProjects.SelectedValue is int projectID)
            {
                LoadTasks(projectID); 
            }
        }


        private void LoadEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, Name FROM Employees", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbEmployees.DataSource = dt;
                cmbEmployees.DisplayMember = "Name";
                cmbEmployees.ValueMember = "EmployeeID";
            }
        }

        
        private void LoadAssignments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT a.AssignmentID, t.TaskName, e.Name, a.AssignmentDate, a.Status " +
                                                      "FROM Assignments a " +
                                                      "JOIN Tasks t ON a.TaskID = t.TaskID " +
                                                      "JOIN Employees e ON a.EmployeeID = e.EmployeeID", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAssignments.DataSource = dt;
            }
        }

        
        private void InitializeStatusComboBox()
        {
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("On Hold");
            cmbStatus.Items.Add("Completed");
            cmbStatus.SelectedIndex = 0;  
        }

        
        private void btnAddAssignment_Click(object sender, EventArgs e)
        {
            int taskID = Convert.ToInt32(cmbTasks.SelectedValue);
            int employeeID = Convert.ToInt32(cmbEmployees.SelectedValue);
            DateTime assignmentDate = dtpAssignmentDate.Value; 
            string status = cmbStatus.SelectedItem.ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Assignments (TaskID, EmployeeID, AssignmentDate, Status) " +
                               "VALUES (@TaskID, @EmployeeID, @AssignmentDate, @Status)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TaskID", taskID);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@AssignmentDate", assignmentDate);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery();
            }

           
            LoadAssignments();
        }

        
        private void btnDeleteAssignment_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                int assignmentID = Convert.ToInt32(dgvAssignments.SelectedRows[0].Cells[0].Value);
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM Assignments WHERE AssignmentID = @AssignmentID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@AssignmentID", assignmentID);

                    cmd.ExecuteNonQuery();
                }

                
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Please select an assignment to delete.");
            }
        }

        
        private void btnEditAssignment_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                int assignmentID = Convert.ToInt32(dgvAssignments.SelectedRows[0].Cells[0].Value);
                int taskID = Convert.ToInt32(cmbTasks.SelectedValue);
                int employeeID = Convert.ToInt32(cmbEmployees.SelectedValue);
                DateTime assignmentDate = dtpAssignmentDate.Value;
                string status = cmbStatus.SelectedItem.ToString();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE Assignments SET TaskID = @TaskID, EmployeeID = @EmployeeID, " +
                                   "AssignmentDate = @AssignmentDate, Status = @Status WHERE AssignmentID = @AssignmentID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TaskID", taskID);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@AssignmentDate", assignmentDate);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@AssignmentID", assignmentID);

                    cmd.ExecuteNonQuery();
                }

                
                LoadAssignments();
            }
            else
            {
                MessageBox.Show("Please select an assignment to edit.");
            }
        }

        
        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();  
            
        }

        
    }
}
