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
using Assessment_1;


namespace Assessment_1
{
    public partial class AddAnimalWindow : Window
    {
        public AddAnimalWindow()
        {
            InitializeComponent();

            cbAnimalType.ItemsSource = Enum.GetValues(typeof(AnimalType));
            cbSex.ItemsSource = Enum.GetValues(typeof(Sex));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string ownerName = txtOwnerName.Text.Trim();
            int age;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Animal name is required.");
                return;
            }

            if (cbAnimalType.SelectedItem == null || cbSex.SelectedItem == null)
            {
                MessageBox.Show("Animal type and sex are required.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out age))
            {
                MessageBox.Show("Age must be a valid number.");
                return;
            }

            var customer = DataStores.Customers.Get(c => c.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));

            if (customer == null)
            {
                MessageBox.Show("Owner not found.");
                return;
            }

            Animal animal = new Animal(name, (AnimalType)cbAnimalType.SelectedItem, (Sex)cbSex.SelectedItem, age)
            {
                OwnerName = ownerName
            };

            customer.AddAnimal(animal);

            DataStores.Customers.Update(c => c.Name == ownerName, customer);

            MessageBox.Show("Animal saved to customer record.");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


