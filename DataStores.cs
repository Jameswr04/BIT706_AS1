using System;
using System.IO;

namespace Assessment_1
{
    public static class DataStores
    {
        private static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;

        public static DataStore<Customer> Customers { get; } =
            new DataStore<Customer>(Path.Combine(BasePath, "customers.json"));

        public static DataStore<Animal> Animals { get; } =
            new DataStore<Animal>(Path.Combine(BasePath, "animals.json"));

        public static DataStore<Microchip> Microchips { get; } =
            new DataStore<Microchip>(Path.Combine(BasePath, "microchips.json"));
    }
}
