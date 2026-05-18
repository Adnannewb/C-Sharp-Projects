using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirportManagementSystem
{
    public partial class Officer_view_booking : Form
    {
        Database db = new Database();

        public Officer_view_booking()
        {
            InitializeComponent();
        }

        // SEARCH BOOKING
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                // SEARCH QUERY
                string query = "SELECT * FROM Booking WHERE BookingID=@BookingID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@BookingID", textBox1.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // OPTIONAL MESSAGE
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No Booking Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // CANCEL BOOKING
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                // DELETE QUERY
                string query = "DELETE FROM Booking WHERE BookingID=@BookingID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@BookingID", textBox2.Text);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                con.Close();

                if (rows > 0)
                {
                    MessageBox.Show("Booking Cancelled Successfully");
                }
                else
                {
                    MessageBox.Show("Booking ID Not Found");
                }

                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // BACK BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            Officer_Dashboard dashboard = new Officer_Dashboard();

            dashboard.Show();

            this.Hide();
        }
    }
}