using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EfficientBook
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {



        public Page1()
        {
            InitializeComponent();

            DataBaseConnections DataCon = new DataBaseConnections();
            DataCon.OpenConnection();

            try
            {
                string sql = "SELECT * FROM produkty";

                //Console.WriteLine("Connecting to MySQL...");
                //conn.Open();
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader reader = cmd.ExecuteReader();

                MySqlDataReader reader = DataCon.Read(sql);

                List<Produkt> list_of_product = new List<Produkt>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Produkt produkt = new Produkt();
                        produkt.Id_Produktu = reader.GetInt32(0);
                        produkt.Id_Produktu = reader.GetInt32(0);
                        produkt.Nazwa = reader.GetString(1).ToString();
                        produkt.Ilosc_Dostepnych = reader.GetInt32(2);
                        produkt.Cena_Brutto = reader.GetInt32(3);
                        produkt.Cena_Netto = reader.GetInt32(4);
                        produkt.Kod = reader.GetString(5).ToString();
                        produkt.Marka = reader.GetString(6).ToString();
                        produkt.Vat = reader.GetInt32(7);

                        list_of_product.Add(produkt);
                    }

                    DataGrid_produkty.ItemsSource = list_of_product;

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

        private void ListBox_ID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_ID_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("chyba zaznaczono");
        }

        private void DataGrid_produkty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("select");
        }

        private void DataGrid_produkty_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            Console.WriteLine("add");
        }

        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {


            List<Produkt> list_of_DataGrid = new List<Produkt>();
            list_of_DataGrid = (List<Produkt>)DataGrid_produkty.ItemsSource;
            int Length = list_of_DataGrid.Count - 1;

            DataBaseConnections DataCon = new DataBaseConnections();

            DataCon.OpenConnection();
            DataCon.Delete_all_rows();

            try
            {
                foreach (var item in list_of_DataGrid)
                {
                    Console.WriteLine(item);
                    string sql = $"INSERT INTO `produkty`(`ID_Produktu`, `Nazwa`, `Ilosc_dostepnych`, `Cena_brutto`, `Cena_netto`, `Kod`, `Marka`, `VAT`) VALUES ({item.Id_Produktu}, '{item.Nazwa}', {item.Ilosc_Dostepnych}, {item.Cena_Brutto}, {item.Cena_Netto}, '{item.Kod}', '{item.Marka}', {item.Vat})";
                    DataCon.Write(sql);
                }
            }
            catch (Exception a)
            {
                DataGrid_produkty.ItemsSource = list_of_DataGrid;
                Console.WriteLine(a); ;
            }
        }
    }
}
