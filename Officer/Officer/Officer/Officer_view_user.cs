using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirportManagementSystem
{
    public partial class Officer_view_user : Form
    {
        Database db = new Database();

        public Officer_view_user()
        {
            InitializeComponent();
        }

        private void Officer_view_user_Load(object sender, EventArgs e)
        {
            // Form Settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // dataGridView1 settings
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Show all users automatically
            LoadUsers();
        }

        // Load All Users Method
        private void LoadUsers()
        {
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM Users";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // button1 = Search Button
        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;

            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM Users WHERE UserId=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // button2 = Delete Button
        private void button2_Click(object sender, EventArgs e)
        {
            string userId = textBox2.Text;

            if (userId == "")
            {
                MessageBox.Show("Please Enter User ID");
                return;
            }

            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "DELETE FROM Users WHERE UserId=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", userId);

                int row = cmd.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("User Deleted Successfully");

                    // Reload Users
                    LoadUsers();

                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // button3 = Back Button
        private void button3_Click(object sender, EventArgs e)
        {
            Officer_Dashboard dashboard = new Officer_Dashboard();

            dashboard.Show();

            this.Hide();
        }
    }
}