using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page1 page1 = new Page1();
        Page2 page2 = new Page2();
        Page_klienci page_klienci = new Page_klienci();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Produkty(object sender, RoutedEventArgs e)
        {
            Main.Navigate(page1);
            //NavigationService.RemoveBackEntry()
        }
        private void Button_Klienci(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(page_klienci);
            //NavigationService.Navigate(null);
        }

    }
}
