using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class ClassManager
    {
        private IDictionary<int, Class> _dictionary = new Dictionary<int, Class>();
        public IReadOnlyDictionary<int, Class> Dictionary => _dictionary as IReadOnlyDictionary<int, Class>;

        private int _idCount = 0;

        public void ShowAll(IReadOnlyDictionary<int, Person> personDictionary)
        {
            foreach (var entry in _dictionary)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value.Serialize(personDictionary)}");
            }
        }

        public void ShowOne(int id, IReadOnlyDictionary<int, Person> personDictionary)
        {
            var @class = _dictionary[id];
            var teacher = personDictionary[@class.TeacherId];

            Console.WriteLine($"{@class.Serialize(personDictionary)}");
            Console.WriteLine("Students:");
            foreach (var studentId in @class.Students)
            {
                var student = personDictionary[studentId];
                Console.WriteLine($"\t{studentId} - {student.Serialize()}");
            }
        }

        public Class Get(int id)
        {
            if (! _dictionary.ContainsKey(id))
            {
                throw new Exception("Not found.");
            }
            return _dictionary[id];
        }

        public bool Exists(int id)
        {
            return _dictionary.ContainsKey(id);
        }

        public void Add(Class @class)
        {
            _dictionary[_idCount++] = @class;
        }

        public void Remove(int id)
        {
            if (!_dictionary.ContainsKey(id))
            {
                throw new Exception("Not found.");
            }
            _dictionary.Remove(id);
        }

        public void RemoveWhereTeacherIs(int teacherId)
        {
            foreach(var entry in _dictionary)
            {
                if (entry.Value.TeacherId == teacherId)
                {
                    _dictionary.Remove(entry.Key);
                }
            }
        }
    }
}
