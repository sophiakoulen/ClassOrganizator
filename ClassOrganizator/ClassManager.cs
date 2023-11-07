using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class ClassManager
    {
        private PersonManager _personManager;
        private IDictionary<int, Class> _dictionary = new Dictionary<int, Class>();
        private int _idCount = 0;

        public ClassManager(PersonManager personManager)
        {
            _personManager = personManager;
        }

        public IReadOnlyDictionary<int, Class> Dictionary => _dictionary as IReadOnlyDictionary<int, Class>;


        public void ShowAll()
        {
            foreach (var entry in _dictionary)
            {
                Console.WriteLine($"{entry.Key} - {SerializeOne(entry.Key)}");
            }
        }

        public void ShowOne(int id)
        {
            var @class = _dictionary[id];

            Console.WriteLine($"{SerializeOne(id)}");
            Console.WriteLine("Students:");
            foreach (var studentId in @class.Students)
            {
                var student = _personManager.Dictionary[studentId];
                Console.WriteLine($"\t{studentId} - {student.Serialize()}");
            }
        }

        public void ShowOnePersonsClasses(int personId)
        {
            var person = _personManager.Dictionary[personId];

            Console.WriteLine($"{person.Serialize()}");

            Console.Write("Is teaching: ");
            foreach (var entry in _dictionary)
            {
                if (entry.Value.TeacherId == personId)
                {
                    Console.Write($"{entry.Value.Name} ");
                }
            }
            Console.Write(Environment.NewLine);

            Console.Write("Is student: ");
            foreach (var entry in _dictionary)
            {
                if (entry.Value.Students.Contains(personId))
                {
                    Console.Write($"{entry.Value.Name}");
                }
            }
            Console.Write(Environment.NewLine);
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

        private string SerializeOne(int id)
        {
            var @class = _dictionary[id];
            var teacher = _personManager.Get(id);
            return $"Name: {@class.Name}, Teacher: {teacher.Serialize()}";
        }
    }
}
