using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assessment_1
{
    public class Animal
    {
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public string OwnerName { get; set; }
        public AnimalStatus Status { get; set; } = AnimalStatus.Pending;
        public Microchip Microchip { get; set; }

        public Microchip Microchip1
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

        public Animal(string name, AnimalType animalType, Sex sex, int age = 0)
        {
            Name = name;
            AnimalType = animalType;
            Sex = sex;
            Age = age;
        }

        public Animal(string name, string type, string sex, int age)
        {
            Name = name;
            Age = age;

            if (Enum.TryParse(type, true, out AnimalType parsedType))
                AnimalType = parsedType;
            else
                throw new ArgumentException("Invalid animal type");

            if (Enum.TryParse(sex, true, out Sex parsedSex))
                Sex = parsedSex;
            else
                throw new ArgumentException("Invalid sex");
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }

        public void AssignMicrochip(Microchip chip)
        {
            if (chip.TargetAnimalType == this.AnimalType && chip.State == MicrochipState.Received)
            {
                chip.State = MicrochipState.Implanted;
                chip.DateImplanted = DateTime.Now;
                chip.ImplantedAnimalName = Name;

                Microchip = chip;
                Status = AnimalStatus.Microchipped;
            }
        }

        public override string ToString()
        {
            if (Microchip != null)
                return $"{Name}, {Sex.ToString().ToLower()} {AnimalType.ToString().ToLower()}, microchipped [#{Microchip.FormatNumber(Microchip.Number)}]";
            else
                return $"{Name}, {Sex.ToString().ToLower()} {AnimalType.ToString().ToLower()}, pending";
        }
    }
}
