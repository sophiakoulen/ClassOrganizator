using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class BasicManager<T>
    {
        private IDictionary<int, T> _dictionary = new Dictionary<int, T>();
        private int _idCount = 0;

        public IReadOnlyDictionary<int, T> Dictionary => _dictionary as IReadOnlyDictionary<int, T>;

        public T Get(int id)
        {
            if (!Exists(id))
            {
                throw new ArgumentException($"Key '{id}' Not found");
            }
            return _dictionary[id];
        }

        public bool Exists(int id)
        {
            return _dictionary.ContainsKey(id);
        }

        public void Add(T item)
        {
            _dictionary[_idCount++] = item;
        }

        public void Remove(int id)
        {
            if (!Exists(id))
            {
                throw new ArgumentException($"Key '{id}' Not found");
            }
            _dictionary.Remove(id);
        }
    }
}
