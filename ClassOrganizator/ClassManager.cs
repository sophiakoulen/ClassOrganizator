using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class ClassManager : BasicManager<Class>
    {
        private PersonManager _personManager;

        public ClassManager(PersonManager personManager)
        {
            _personManager = personManager;
        }

        public void ShowAll()
        {
            foreach (var entry in Dictionary)
            {
                Console.WriteLine($"{entry.Key} - {SerializeOne(entry.Key)}");
            }
        }

        public void ShowOne(int id)
        {
            var @class = Dictionary[id];

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
            foreach (var entry in Dictionary)
            {
                if (entry.Value.TeacherId == personId)
                {
                    Console.Write($"{entry.Value.Name} ");
                }
            }
            Console.Write(Environment.NewLine);

            Console.Write("Is student: ");
            foreach (var entry in Dictionary)
            {
                if (entry.Value.Students.Contains(personId))
                {
                    Console.Write($"{entry.Value.Name}");
                }
            }
            Console.Write(Environment.NewLine);
        }

        public void RemovePerson(int id)
        {
            _personManager.Remove(id);
            RemoveWhereTeacherIs(id);
        }

        public string SerializeOne(int id)
        {
            var @class = Dictionary[id];
            var teacher = _personManager.Get(id);
            return $"Name: {@class.Name}, Teacher: {teacher.Serialize()}";
        }

        private void RemoveWhereTeacherIs(int teacherId)
        {
            foreach(var entry in Dictionary)
            {
                if (entry.Value.TeacherId == teacherId)
                {
                    Remove(entry.Key);
                }
            }
        }

    }
}
