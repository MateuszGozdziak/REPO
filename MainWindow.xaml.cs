using System.Windows;

namespace EfficientBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page1 page1 = new Page1();
        Page2 page2 = new Page2();


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
        }
        private void Button_Klienci(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(page2);
        }

    }
}
