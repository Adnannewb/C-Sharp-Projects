using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AirportManagementSystem
{
    public partial class Officer_add_user : Form
    {
        Database db = new Database();

        public Officer_add_user()
        {
            InitializeComponent();
        }

        private void Officer_add_user_Load(object sender, EventArgs e)
        {
            // Form Settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // dateTimePicker1 format
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        // button1 = Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string nid = textBox3.Text;
            string phone = textBox4.Text;

            string gender = "";

            // radioButton1 = Male
            // radioButton2 = Female

            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                gender = "Female";
            }

            string dob = dateTimePicker1.Text;

            if (name == "" || email == "" || nid == "" || phone == "" || gender == "")
            {
                MessageBox.Show("Please Fill All Fields");
                return;
            }

            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "INSERT INTO Users (FullName, DateOfBirth, Gender, Email, NIDNumber, PhoneNumber) VALUES (@name, @dob, @gender, @email, @nid, @phone)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@nid", nid);
                cmd.Parameters.AddWithValue("@phone", phone);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User Registered Successfully");

                // Clear Fields
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                radioButton1.Checked = false;
                radioButton2.Checked = false;
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

        // button2 = Back Button
        private void button2_Click(object sender, EventArgs e)
        {
            Officer_Dashboard dashboard = new Officer_Dashboard();
            dashboard.Show();

            this.Hide();
        }
    }
}