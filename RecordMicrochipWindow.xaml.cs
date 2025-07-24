using System;
using System.Linq;
using System.Windows;

namespace Assessment_1
{
    public partial class RecordMicrochipWindow : Window
    {
        public RecordMicrochipWindow()
        {
            InitializeComponent();
            if (!DataStores.Microchips.GetAll().Any())
            {
                var chips = new List<Microchip>
                {
                    new Microchip("12345678901234567890", AnimalType.Dog, DateTime.Today),
                    new Microchip("11112222333344445555", AnimalType.Cat, DateTime.Today),
                    new Microchip("99998888777766665555", AnimalType.Dog, DateTime.Today)
                };

                foreach (var chip in chips)
                {
                    DataStores.Microchips.Add(chip);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string customerName = CustomerNameTextBox.Text.Trim();
            string animalName = AnimalNameTextBox.Text.Trim();
            string chipNumber = new string(MicrochipNumberTextBox.Text.Where(char.IsDigit).ToArray());

            if (chipNumber.Length != 20)
            {
                MessageBox.Show("Microchip number must contain exactly 20 digits.");
                return;
            }

            var customer = DataStores.Customers.Get(c => c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                MessageBox.Show("Customer not found.");
                return;
            }

            var animal = customer.Animals.FirstOrDefault(a => a.Name.Equals(animalName, StringComparison.OrdinalIgnoreCase));
            if (animal == null)
            {
                MessageBox.Show("Animal not found.");
                return;
            }

            var microchip = DataStores.Microchips.Get(m => m.Number == chipNumber);
            if (microchip == null)
            {
                MessageBox.Show("Microchip not found in records.");
                return;
            }

            if (microchip.State != MicrochipState.Received)
            {
                MessageBox.Show("Microchip is already used or deactivated.");
                return;
            }

            if (microchip.TargetAnimalType != animal.AnimalType)
            {
                MessageBox.Show("Microchip type does not match animal type.");
                return;
            }

            animal.AssignMicrochip(microchip);
            microchip.AssignToAnimal(animal.Name, DateTime.Today);

            DataStores.Customers.Update(c => c.Name == customer.Name, customer);
            DataStores.Microchips.Update(m => m.Number == chipNumber, microchip);

            MessageBox.Show("Microchip recorded successfully.");
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
