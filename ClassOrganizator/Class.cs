using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class Class
    {
        public readonly string Name;
        public readonly int TeacherId;
        private List<int> _students;

        public IReadOnlyList<int> Students => _students;

        public Class(int teacherId, string name)
        {
            TeacherId = teacherId;
            Name = name;
            _students = new List<int>();
        }

        public void addStudent(int studentId)
        {
            if (_students.Contains(studentId))
            {
                throw new Exception($"student '{studentId}' is already a member of this class");
            }
            _students.Add(studentId);
        }

        public void removeStudent(int studentId)
        {
            if (! _students.Contains(studentId))
            {
                throw new Exception($"student '{studentId}' is not a member if this class");
            }
            _students.Remove(studentId);
        }
    }
}
