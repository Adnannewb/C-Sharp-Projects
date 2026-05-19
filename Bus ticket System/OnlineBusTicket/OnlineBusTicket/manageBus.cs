using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class manageBus : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

        public manageBus()
        {
            InitializeComponent();
            LoadBusData(); // Load data when the form loads
        }

        // Add Bus
        private void btnAddBus_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Buses (BusName, RouteFrom, RouteTo, TicketPrice, TotalSeats, AvailableSeats) " +
                               "VALUES (@name, @from, @to, @price, @totalSeats, @availableSeats)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtBusName.Text);
                cmd.Parameters.AddWithValue("@from", txtRouteFrom.Text);
                cmd.Parameters.AddWithValue("@to", txtRouteTo.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@totalSeats", txtTotalSeats.Text);
                cmd.Parameters.AddWithValue("@availableSeats", txtAvailableSeats.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Ensure the connection is always closed
            }

            MessageBox.Show("Bus added successfully.");
            LoadBusData(); // Reload bus data after adding
        }

        // Delete Bus
        private void btnDeleteBus_Click(object sender, EventArgs e)
        {
            if (dgvBuses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bus to delete.");
                return;
            }

            try
            {
                // Get the BusID of the selected bus
                string busId = dgvBuses.SelectedRows[0].Cells["BusID"].Value.ToString();

                // Delete the selected bus from the database
                string query = "DELETE FROM Buses WHERE BusID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", busId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Ensure the connection is always closed
            }

            MessageBox.Show("Bus deleted successfully.");
            LoadBusData(); // Reload bus data after deletion
        }

        // Edit Bus (Update bus details including available seats)
        private void btnEditBus_Click(object sender, EventArgs e)
        {
            if (dgvBuses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bus to edit.");
                return;
            }

            try
            {
                string query = "UPDATE Buses SET BusName = @name, RouteFrom = @from, RouteTo = @to, " +
                               "TicketPrice = @price, TotalSeats = @totalSeats, AvailableSeats = @availableSeats " +
                               "WHERE BusID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtBusName.Text);
                cmd.Parameters.AddWithValue("@from", txtRouteFrom.Text);
                cmd.Parameters.AddWithValue("@to", txtRouteTo.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@totalSeats", txtTotalSeats.Text);
                cmd.Parameters.AddWithValue("@availableSeats", txtAvailableSeats.Text);
                cmd.Parameters.AddWithValue("@id", dgvBuses.SelectedRows[0].Cells["BusID"].Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close(); // Ensure the connection is always closed
            }

            MessageBox.Show("Bus details updated.");
            LoadBusData(); // Reload bus data after update
        }

        // Load Bus Data into DataGridView
        private void LoadBusData()
        {
            try
            {
                string query = "SELECT * FROM Buses";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBuses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bus data: " + ex.Message);
            }
        }

        // Navigate Back to Admin Dashboard
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }

        private void btnmanageseats_Click(object sender, EventArgs e)
        {
            ManageSeats manageSeats = new ManageSeats();
            manageSeats.Show();
            this.Close();
        }
    }
}
