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
using System.Windows.Shapes;

namespace Assessment_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddCustomerWindow();
            window.ShowDialog();
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddAnimalWindow();
            window.ShowDialog();
        }

        private void RecordMicrochip_Click(object sender, RoutedEventArgs e)
        {
            var window = new RecordMicrochipWindow();
            window.ShowDialog();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

