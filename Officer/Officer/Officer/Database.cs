using System;
using System.Data;
using System.Data.SqlClient;

namespace AirportManagementSystem
{
    public class Database
    {
        // CHANGE YOUR SERVER NAME AND DATABASE NAME HERE
        private string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}