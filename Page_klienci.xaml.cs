using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EfficientBook
{
    /// <summary>
    /// Interaction logic for Page_klienci.xaml
    /// </summary>
    public partial class Page_klienci : Page
    {

        List<Klient> list_of_customer = new List<Klient>();

        public Page_klienci()
        {
            InitializeComponent();

            DataBaseConnections DataCon = new DataBaseConnections();
            DataCon.OpenConnection();
            

            try
            {
                string sql = "SELECT * FROM klienci";
                MySqlDataReader reader = DataCon.Read(sql);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Klient klient = new Klient();
                        klient.ID_Klienta = (int)reader[0];
                        klient.Nazwa_Firmy = reader[1].ToString();
                        klient.Imie=reader[2].ToString();
                        klient.Nazwisko = reader[3].ToString();
                        klient.NIP = (int)reader[4];
                        klient.Numer_Telefonu=(int)reader[5];
                        klient.Email = reader[6].ToString();
                        klient.Adres=reader[7].ToString();

                        list_of_customer.Add(klient);
                    }

                    DataGrid_Page_klienci.ItemsSource = list_of_customer;

                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }

            DataCon.CloseConnection();
            Console.WriteLine("Done.");
        }

        private void Button_edytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_wyszukaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Page_Klienci_Dodaj page_Klienci_Dodaj = new Page_Klienci_Dodaj();
            NavigationService.Navigate(page_Klienci_Dodaj);
            //NavigationService.Navigate(null);
        }
        
        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            Klient abc = new Klient();
            try
            {
                abc = (Klient)DataGrid_Page_klienci.SelectedItem;
            }
            catch (Exception)
            {

                Console.WriteLine("dziala");
                return;
            }
            
            int row=list_of_customer.IndexOf(abc);
            list_of_customer.Remove(abc);////usuwa z listy--------------------------
            DataGrid_Page_klienci.ItemsSource = list_of_customer;
            DataGrid_Page_klienci.Items.Refresh();
        }
    }
}
