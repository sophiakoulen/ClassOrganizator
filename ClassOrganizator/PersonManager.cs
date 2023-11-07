using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class PersonManager
    {
        private IDictionary<int, Person> _dictionary = new Dictionary<int, Person>();
        private int _idCount = 0;
        public IReadOnlyDictionary<int, Person> Dictionary => _dictionary as IReadOnlyDictionary<int, Person>;


        public void ShowAll()
        {
            foreach (var entry in _dictionary)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value.Serialize()}");
            }
        }

        public Person Get(int id)
        {
            if (!_dictionary.ContainsKey(id))
            {
                throw new ArgumentException($"Key '{id}' Not found");
            }
            return _dictionary[id];
        }

        public bool Exists(int id)
        {
            return _dictionary.ContainsKey(id);
        }

        public void Add(Person person)
        {
            _dictionary[_idCount++] = person;
        }

        public void Remove(int id)
        {
            if (!_dictionary.ContainsKey(id))
            {
                throw new Exception("Not found");
            }
            _dictionary.Remove(id);
        }
    }
}
