using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class BookingHistory : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        public BookingHistory()
        {
            InitializeComponent();
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            try
            {
                string query = "SELECT B.BusName, B.RouteFrom, B.RouteTo, U.Username, BS.SeatNumber, Bo.PaymentAmount, Bo.BookingDate, Bo.BookingID " +
                               "FROM Bookings Bo " +
                               "INNER JOIN Buses B ON Bo.BusID = B.BusID " +
                               "INNER JOIN Users U ON Bo.UserID = U.UserID " +
                               "INNER JOIN BusSeats BS ON CAST(Bo.SeatNumber AS NVARCHAR(10)) = BS.SeatNumber " +
                               "ORDER BY Bo.BookingDate DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

               
                

                dgvBookingHistory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // Clear all bookings and reset the seat bookings in the database
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                // Clear bookings in the Bookings table
                string clearBookingsQuery = "DELETE FROM Bookings";
                SqlCommand cmd = new SqlCommand(clearBookingsQuery, con, transaction);
                cmd.ExecuteNonQuery();

                // Reset seat bookings in the BusSeats table (Set IsBooked to 0 for all seats)
                string resetSeatsQuery = "UPDATE BusSeats SET IsBooked = 0";
                SqlCommand cmdSeats = new SqlCommand(resetSeatsQuery, con, transaction);
                cmdSeats.ExecuteNonQuery();

                // Commit the transaction
                transaction.Commit();

                MessageBox.Show("All bookings cleared successfully.");
                LoadBookingHistory();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback(); // Rollback in case of error
                }
                MessageBox.Show("Error clearing bookings: " + ex.Message);
            }
            finally
            {
                con.Close(); // Ensure connection is closed
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }
    }
}
