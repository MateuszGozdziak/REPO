using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EfficientBook
{
    internal class DataBaseConnections
    {

        public string connStr = "server=localhost;user=root;database=projektprogramowaniezaawansowane;port=3306;password=";
        private MySqlConnection connection;
        public string sql;

        public bool OpenConnection()
        {
            try
            {
                connection = new MySqlConnection(connStr);
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public MySqlDataReader Read(string sql)
        {
            this.sql = sql;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public bool Write(string sql)
        {
            this.sql = sql;
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }
        public bool Delete_all_rows()
        {
            this.sql = "DELETE FROM `produkty`";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                // ex.message
                return false;
            }
        }

    }
}
