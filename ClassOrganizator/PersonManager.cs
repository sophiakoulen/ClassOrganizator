using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class PersonManager : BasicManager<Person>
    {
        public void ShowAll()
        {
            foreach (var entry in Dictionary)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value.Serialize()}");
            }
        }

    }
}
