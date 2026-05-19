using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class CustomerDashboard : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        private string username;

        public CustomerDashboard(string user)
        {
            InitializeComponent();
            username = user;
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT DISTINCT RouteFrom FROM Buses";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dtRouteFrom = new DataTable();
                    da.Fill(dtRouteFrom);

                    cmbRouteFrom.DataSource = dtRouteFrom;
                    cmbRouteFrom.DisplayMember = "RouteFrom";
                    cmbRouteFrom.ValueMember = "RouteFrom";

                    query = "SELECT DISTINCT RouteTo FROM Buses";
                    da.SelectCommand.CommandText = query;
                    DataTable dtRouteTo = new DataTable();
                    da.Fill(dtRouteTo);

                    cmbRouteTo.DataSource = dtRouteTo;
                    cmbRouteTo.DisplayMember = "RouteTo";
                    cmbRouteTo.ValueMember = "RouteTo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbRouteFrom.SelectedValue == null || cmbRouteTo.SelectedValue == null)
            {
                MessageBox.Show("Please select both 'Route From' and 'Route To'.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Buses WHERE RouteFrom=@from AND RouteTo=@to";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@from", cmbRouteFrom.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@to", cmbRouteTo.SelectedValue.ToString());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBusList.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearchSeats_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBusID.Text.Trim(), out int busID))
            {
                MessageBox.Show("Please enter a valid numeric Bus ID.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM BusSeats WHERE BusID=@busID AND IsBooked=0";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@busID", busID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSeats.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private int GetUserID(string username)
        {
            int userID = -1;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                    userID = Convert.ToInt32(result);
            }
            return userID;
        }

        // Method to fetch available seat number as a string
        private string GetAvailableSeat(int busID)
        {
            string seatNumber = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT TOP 1 SeatNumber FROM BusSeats WHERE BusID = @busID AND IsBooked = 0";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@busID", busID);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    seatNumber = result.ToString();
            }
            return seatNumber;
        }

        // In btnBook_Click method, modify how seatNumber is handled
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvBusList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bus.");
                return;
            }

            if (!int.TryParse(dgvBusList.SelectedRows[0].Cells["BusID"].Value?.ToString(), out int busID))
            {
                MessageBox.Show("Invalid Bus ID.");
                return;
            }

            string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(paymentMethod))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            int userID = GetUserID(username);
            string seatNumber = GetAvailableSeat(busID); // This will now return a string

            if (string.IsNullOrEmpty(seatNumber)) // Check for null or empty seat number
            {
                MessageBox.Show("No available seats on this bus.");
                return;
            }

            decimal ticketPrice = GetTicketPrice(busID);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Insert into Bookings with SeatNumber (string)
                    SqlCommand cmd = new SqlCommand("INSERT INTO Bookings (UserID, BusID, SeatNumber, PaymentAmount, BookingDate) VALUES (@userID, @busID, @seatNumber, @paymentAmount, GETDATE())", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@busID", busID);
                    cmd.Parameters.AddWithValue("@seatNumber", seatNumber); // Insert seatNumber (string)
                    cmd.Parameters.AddWithValue("@paymentAmount", ticketPrice);
                    cmd.ExecuteNonQuery();

                    // Update BusSeats table with SeatNumber (string)
                    cmd = new SqlCommand("UPDATE BusSeats SET IsBooked = 1 WHERE SeatNumber = @seatNumber AND BusID = @busID", con);
                    cmd.Parameters.AddWithValue("@seatNumber", seatNumber); // Use SeatNumber (string)
                    cmd.Parameters.AddWithValue("@busID", busID);
                    cmd.ExecuteNonQuery();

                    // Update AvailableSeats in Buses table
                    cmd = new SqlCommand("UPDATE Buses SET AvailableSeats = AvailableSeats - 1 WHERE BusID = @busID", con);
                    cmd.Parameters.AddWithValue("@busID", busID);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Booking Successful!");
                Loginform loginform = new Loginform();
                loginform.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private decimal GetTicketPrice(int busID)
        {
            decimal price = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT TicketPrice FROM Buses WHERE BusID = @busID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@busID", busID);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    price = Convert.ToDecimal(result);
            }
            return price;
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Loginform loginform = new Loginform();
            loginform.Show();
            this.Close();
        }
    }
}
