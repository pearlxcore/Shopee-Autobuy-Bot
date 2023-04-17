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

            server = "202.71.110.6";
            database = "pearlxc1_db";
            user = "pearlxc1_user";
            password = "aGI6joeg!,]4";
            port = "3306";

            connectionString = "SERVER=143.198.217.144;PORT=3306;DATABASE=pearlxc1_db;UID=pearlxc1_user";
            //connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}", server, port, user, password, database);

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