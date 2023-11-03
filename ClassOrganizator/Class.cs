using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class Class
    {
        private string _name;
        private Person _teacher;
        private List<string> _students;

        public Class(Person teacher)
        {
            this._teacher = teacher;
        }

        public void addStudent(string userName)
        {
            if (_students.Contains(userName))
            {
                throw new Exception($"student '{userName}' is already a member of this class");
            }
            _students.Add(userName);
        }

        public void removeStudent(string userName)
        {
            if (! _students.Contains(userName))
            {
                throw new Exception($"student '{userName}' is not a member if this class");
            }
            _students.Remove(userName);
        }
    }
}
