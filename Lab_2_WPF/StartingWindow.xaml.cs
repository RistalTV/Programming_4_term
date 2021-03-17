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

namespace Lab_2_WPF
{
    /// <summary>
    /// Логика взаимодействия для StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        public StartingWindow()
        {
            InitializeComponent();
        }
        

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            bool v = NavigationService.Navigate(new Uri("pages/view/1.xaml", UriKind.Relative));
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            bool v = NavigationService.Navigate(new Uri("pages/create/1.xaml", UriKind.Relative));
        }
    }
}
