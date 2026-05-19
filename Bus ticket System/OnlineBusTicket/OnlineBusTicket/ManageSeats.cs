using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineBusTicket
{
    public partial class ManageSeats : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        public ManageSeats()
        {
            InitializeComponent();
            
        }

        // Load buses into combobox when the form loads
        private void ManageSeats_Load(object sender, EventArgs e)
        {
            LoadBusNames();
        }

        private void LoadBusNames()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT BusID, BusName FROM Buses";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbBusNames.DisplayMember = "BusName";
                cmbBusNames.ValueMember = "BusID";
                cmbBusNames.DataSource = dt;
            }
        }

        // Add Seat Number for a Bus
        private void AddSeatNumber(int busID, string seatNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO BusSeats (BusID, SeatNumber, IsBooked) VALUES (@BusID, @SeatNumber, 0)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusID", busID);
                    cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Seat {seatNumber} added successfully.");
                    LoadSeats(busID);  // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Edit Seat Number for a Bus
        private void EditSeatNumber(int busID, string oldSeatNumber, string newSeatNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE BusSeats SET SeatNumber = @NewSeatNumber WHERE BusID = @BusID AND SeatNumber = @OldSeatNumber";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusID", busID);
                    cmd.Parameters.AddWithValue("@OldSeatNumber", oldSeatNumber);
                    cmd.Parameters.AddWithValue("@NewSeatNumber", newSeatNumber);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Seat number {oldSeatNumber} updated to {newSeatNumber}.");
                    LoadSeats(busID);  // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Delete Seat Number for a Bus
        private void DeleteSeatNumber(int busID, string seatNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM BusSeats WHERE BusID = @BusID AND SeatNumber = @SeatNumber";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusID", busID);
                    cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Seat {seatNumber} deleted successfully.");
                    LoadSeats(busID);  // Refresh the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Load Seats Data into DataGridView
        private void LoadSeats(int busID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SeatNumber FROM BusSeats WHERE BusID = @BusID";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@BusID", busID);
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

        // Handle Add Seat Button Click
        private void btnAddSeat_Click(object sender, EventArgs e)
        {
            if (cmbBusNames.SelectedIndex == -1 || string.IsNullOrEmpty(txtSeatNumber.Text.Trim()))
            {
                MessageBox.Show("Please select a bus and enter a seat number.");
                return;
            }

            int busID = (int)cmbBusNames.SelectedValue;
            string seatNumber = txtSeatNumber.Text.Trim();

            AddSeatNumber(busID, seatNumber);
        }

        // Handle Edit Seat Button Click
        private void btnEditSeat_Click(object sender, EventArgs e)
        {
            if (dgvSeats.SelectedRows.Count == 0 || string.IsNullOrEmpty(txtSeatNumber.Text.Trim()))
            {
                MessageBox.Show("Please select a seat and enter a new seat number.");
                return;
            }

            int busID = (int)cmbBusNames.SelectedValue;
            string oldSeatNumber = dgvSeats.SelectedRows[0].Cells["SeatNumber"].Value.ToString();
            string newSeatNumber = txtSeatNumber.Text.Trim();

            EditSeatNumber(busID, oldSeatNumber, newSeatNumber);
        }

        // Handle Delete Seat Button Click
        private void btnDeleteSeat_Click(object sender, EventArgs e)
        {
            if (dgvSeats.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a seat to delete.");
                return;
            }

            int busID = (int)cmbBusNames.SelectedValue;
            string seatNumber = dgvSeats.SelectedRows[0].Cells["SeatNumber"].Value.ToString();

            DeleteSeatNumber(busID, seatNumber);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            manageBus manageBus = new manageBus();
            manageBus.Show();
            this.Close();

        }

        // Handle Bus Selection Change in ComboBox
        private void cmbBusNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBusNames.SelectedIndex != -1)
            {
                int busID = (int)cmbBusNames.SelectedValue;
                LoadSeats(busID);  // Load seat numbers for selected bus
            }
        }
    }
}
