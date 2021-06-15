using Lab_2_WPF.ViewModel;
using Library;
using System.Windows;


namespace Lab_2_WPF
{
    /// <summary>
    /// Логика взаимодействия для StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        private MainViewModel Model { get; set; }
        public StartingWindow()
        {
            InitializeComponent();

            this.Model = new MainViewModel();
            this.DataContext = this.Model;

        }

        
    }
    
}
