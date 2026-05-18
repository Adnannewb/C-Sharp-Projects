using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirportManagementSystem
{
    public partial class Officer_booking : Form
    {
        Database db = new Database();

        public Officer_booking()
        {
            InitializeComponent();
        }

        private void Officer_booking_Load(object sender, EventArgs e)
        {
            // Form Settings
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            LoadFlightNumbers();
            LoadSeatNumbers();
            GenerateBookingID();
        }

        // AUTO GENERATE BOOKING ID
        private void GenerateBookingID()
        {
            textBox1.Text = "BK" + DateTime.Now.Ticks.ToString().Substring(10);
        }

        // LOAD FLIGHT NUMBERS
        private void LoadFlightNumbers()
        {
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "SELECT FlightNumber FROM Flights";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "FlightNumber";
                comboBox1.ValueMember = "FlightNumber";
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

        // LOAD SEAT NUMBERS
        private void LoadSeatNumbers()
        {
            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "SELECT SeatNumber FROM Seats";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "SeatNumber";
                comboBox2.ValueMember = "SeatNumber";
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

        // button1 = Book Button
        private void button1_Click(object sender, EventArgs e)
        {
            string bookingId = textBox1.Text;
            string passengerName = textBox2.Text;
            string flightNumber = comboBox1.Text;
            string journeyDate = dateTimePicker1.Text;
            string seatNumber = comboBox2.Text;

            if (passengerName == "")
            {
                MessageBox.Show("Please Enter Passenger Name");
                return;
            }

            SqlConnection con = db.GetConnection();

            try
            {
                con.Open();

                string query = "INSERT INTO Booking (BookingId, PassengerName, FlightNumber, JourneyDate, SeatNumber) VALUES (@BookingId, @PassengerName, @FlightNumber, @JourneyDate, @SeatNumber)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                cmd.Parameters.AddWithValue("@PassengerName", passengerName);
                cmd.Parameters.AddWithValue("@FlightNumber", flightNumber);
                cmd.Parameters.AddWithValue("@JourneyDate", journeyDate);
                cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Booking Successful");

                // Clear Fields
                textBox2.Clear();

                // Generate New Booking ID
                GenerateBookingID();
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