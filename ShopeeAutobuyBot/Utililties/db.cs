using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;
using System.Data;

namespace Shopee_Autobuy_Bot
{
    public class Login
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;

        public Login()
{
    connectionString = Environment.GetEnvironmentVariable("SHOPEE_DB_CONNECTION_STRING")
        ?? throw new InvalidOperationException("SHOPEE_DB_CONNECTION_STRING is not configured.");

    connection = new MySqlConnection(connectionString);
}

        public void con()
        {
            connection.Open();
            MessageBox.Show("successful connection");
            connection.Close();
            //try
            //{
            //    connection.Open();
            //    MessageBox.Show("successful connection");
            //    connection.Close();
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message + "\n\n" + connectionString);
            //}
        }
    }
}
