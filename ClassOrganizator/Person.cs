using System.Diagnostics;

namespace ClassOrganizator
{
    [DebuggerDisplay("{Serialize()}")]
    internal class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string Serialize() => $"{_firstName} {_lastName}";

    }
}
