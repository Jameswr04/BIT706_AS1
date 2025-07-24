using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    public enum MicrochipState
    {
        Received,
        Implanted,
        Deactivated
    }
    public class Microchip
    {
        public string Number { get; set; }
        public AnimalType TargetAnimalType { get; set; }
        public DateTime DateIssued { get; set; }
        public string ImplantedAnimalName { get; set; }
        public DateTime? DateImplanted { get; set; }
        public DateTime? DateDeactivated { get; set; }
        public MicrochipState State { get; set; }

        public DataStore<object> DataStore
        {
            get => default;
            set
            {
            }
        }

        public Microchip(string number, AnimalType targetAnimalType, DateTime dateIssued)
        {
            Number = number;
            TargetAnimalType = targetAnimalType;
            DateIssued = dateIssued;
            State = MicrochipState.Received;
        }

        public void AssignToAnimal(string animalName, DateTime date)
        {
            ImplantedAnimalName = animalName;
            DateImplanted = date;
            State = MicrochipState.Implanted;
        }

        public void Deactivate(DateTime date)
        {
            DateDeactivated = date;
            State = MicrochipState.Deactivated;
        }

        public override string ToString()
        {
            return $"{FormatNumber(Number)}, {TargetAnimalType}, issued {DateIssued:dd-MMM-yyyy}, {State.ToString().ToLower()}";
        }

        public static string FormatNumber(string number)
        {
            return string.Join("-", Enumerable.Range(0, 5).Select(i => number.Substring(i * 4, 4)));
        }
    }


}
