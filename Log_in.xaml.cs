using MySqlConnector;
using System;
using System.Windows;

namespace EfficientBook
{
    /// <summary>
    /// Interaction logic for Log_in.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public Log_in()
        {
            InitializeComponent();
        }

        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            DataBaseConnections DataCon = new DataBaseConnections();
            DataCon.OpenConnection();
            string sql = "SELECT * FROM `pracownicy`";
            MySqlDataReader reader = DataCon.Read(sql);
            while (reader.Read())
            //
            {
                if (reader[3].ToString() == log_in.Text && reader[4].ToString() == password.Password.ToString())
                {
                    Console.WriteLine(reader[3] + "zalogowano!!" + reader[4]);
                }

            }
            Console.WriteLine("ok");
        }
    }
}
