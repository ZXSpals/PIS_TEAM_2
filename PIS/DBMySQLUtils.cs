using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIS
{
    class DBMySQLUtils
    {
        public static MySqlConnection
               GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
