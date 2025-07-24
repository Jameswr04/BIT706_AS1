using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assessment_1
{
    public class DataStore<T>
    {
        private List<T> items;
        private readonly string filePath;

        public DataStore(string path)
        {
            filePath = path;

            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
                catch
                {
                    items = new List<T>();
                }
            }
            else
            {
                items = new List<T>();
            }
        }

        public List<T> GetAll() => items;

        public T Get(Func<T, bool> match) => items.FirstOrDefault(match);

        public void Add(T item)
        {
            items.Add(item);
            Save();
        }

        public void Update(Func<T, bool> match, T newItem)
        {
            int index = items.FindIndex(i => match(i));
            if (index >= 0)
            {
                items[index] = newItem;
                Save();
            }
        }

        public void Delete(Func<T, bool> match)
        {
            T item = items.FirstOrDefault(match);
            if (item != null)
            {
                items.Remove(item);
                Save();
            }
        }

        private void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            File.WriteAllText(filePath, JsonSerializer.Serialize(items, options));
        }
    }
}
