using System;
using System.Collections.Generic;
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
    /// Interaction logic for Page_Klienci_Dodaj.xaml
    /// </summary>
    public partial class Page_Klienci_Dodaj : Page
    {
        public Page_Klienci_Dodaj()
        {
            InitializeComponent();
        }

        private void Button_Page_Klienci_dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBaseConnections DataCon = new DataBaseConnections();
                DataCon.OpenConnection();
                string sql = $"INSERT INTO `klienci`(`Nazwa_Firmy`, `Imie`, `Nazwisko`, `NIP`, `Numer_telefonu`, `Email`, `Adres`) VALUES('{firma.Text}', '{imie.Text}', '{nazwisko.Text}', {nip.Text}, {telefon.Text}, '{email.Text}', '{adres.Text}')";
                DataCon.Write(sql);
                DataCon.CloseConnection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            NavigationService.Navigate(null);
            this.NavigationService.GoBack();
            //this.NavigationService.
            

        }
    }
}
