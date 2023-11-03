using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class Database
    {
        private Dictionary<string, Person> _persons;
        private Dictionary<string, Class> _classes;

        public void AddPerson(Person person, string id)
        {
            if (_persons.ContainsKey(id))
            {
                throw new Exception("This person is already in the dictionnary");
            }
            _persons.Add(id, person);
        }

        public void RemovePerson(string id)
        {
            if (! _persons.ContainsKey(id))
            {
                throw new Exception("This person is not in the dictionnary");
            }
            _persons.Remove(id);
        }

        public void AddClass(Class @class, string id)
        {
            _classes.Add(id, @class);
        }

        public void RemoveClass(Class @class)
        {
            _classes.Remove(id);
        }
    }
}
