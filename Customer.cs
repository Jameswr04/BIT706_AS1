using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{

    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Animal> Animals { get; set; } = new();

        public Animal Animal
        {
            get => default;
            set
            {
            }
        }

        public DataStore<object> DataStore
        {
            get => default;
            set
            {
            }
        }

        public Customer(string name, string address, string phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Address) &&
                   (!string.IsNullOrWhiteSpace(Phone) || !string.IsNullOrWhiteSpace(Email));
        }

        public void AddAnimal(Animal animal)
        {
            if (animal.IsValid())
            {
                animal.OwnerName = Name;
                Animals.Add(animal);
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Phone ?? "N/A"}, {Email ?? "N/A"}";
        }
    }

}
