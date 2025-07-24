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
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) ||
                (string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(email)))
            {
                MessageBox.Show("Name, address, and at least one contact (phone or email) are required.");
                return;
            }

            var existing = DataStores.Customers.Get(c =>
                (!string.IsNullOrEmpty(phone) && c.Phone == phone) ||
                (!string.IsNullOrEmpty(email) && c.Email == email));

            if (existing != null)
            {
                MessageBox.Show("A customer with the same phone or email already exists.");
                return;
            }

            var customer = new Customer(name, address, phone, email);
            DataStores.Customers.Add(customer);

            MessageBox.Show("Customer added successfully!");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

