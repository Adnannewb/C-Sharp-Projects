using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Officer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirportManagementSystem
{
    public partial class Officer_Login : Form
    {
        Database db = new Database();

        public Officer_Login()
        {
            InitializeComponent();
        }

        private void Officer_Login_Load(object sender, EventArgs e)
        {
            // textbox2 = password textbox
            textBox2.PasswordChar = '*';

            // comboBox1 already has:
            // Officer, Staff, User, Admin
            comboBox1.SelectedIndex = 0;

            // Form settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // button1 = Login Button

            string role = comboBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please Fill All Fields");
                return;
            }

            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM LoginTable WHERE Username=@u AND Password=@p AND Role=@r";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login Successful");

                    Officer_Dashboard dashboard = new Officer_Dashboard();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
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

        private void button2_Click(object sender, EventArgs e)
        {
            // button2 = Exit / Back Button

            Application.Exit();
        }
    }
}