using ClassOrganizator;

Console.WriteLine("Welcome to Class Organizator");

/* Actions:
 * - create a class
 * - create a student person
 * - create a teacher person
 * - assign a person to a class
 * - remove a person from a class
 * - see all classes
 * - see one class
 * - delete a class
 * - delete a person
*/

Dictionary<string, Person> person_db = new Dictionary<string, Person>();
Dictionary<string, Class> class_db = new Dictionary<string, Class>();

while (true)
{
    string action = prompt("ctor> ");
    if (action == "CREATE class")
    {
        string id = prompt("Name: ");

        if (class_db.ContainsKey(id))
        {
            Console.Error.WriteLine($"Conflict: a Class with id {id} already exists");
            continue;
        }

        string teacherId = prompt("Teacher's username: ");

        if (!person_db.ContainsKey(teacherId))
        {
            Console.Error.WriteLine($"Not found: no Person with id {teacherId}");
            continue;
        }

        Class @class = new Class(person_db[teacherId]);
        class_db[teacherId] = @class;
    }
    else if (action == "DELETE class")
    {
        string id = prompt("Name: ");

        if (!class_db.ContainsKey(id))
        {
            Console.Error.WriteLine($"Not found: no Class with id {id} exists");
            continue;
        }

        class_db.Remove(id);
    }
    else if (action == "CREATE person")
    {
        Console.Write("Username: ");
        string id = Console.ReadLine();

        if (person_db.ContainsKey(id))
        {
            Console.Error.WriteLine($"Conflict: a person with id {id} already exists");
            continue;
        }

        string firstname = prompt("First name: ");
        string lastname = prompt("Last name: ");

        person_db[id] = new Person(firstname, lastname);
    }
    else if (action == "DELETE person")
    {
        string id = prompt("Userame: ");

        if (!person_db.ContainsKey(id))
        {
            Console.Error.WriteLine($"Not found: no person with id {id} exists");
        }

        person_db.Remove(id);
    }
    else if (action == "SHOW person")
    {
        foreach (KeyValuePair<string, Person> p in person_db)
        {
            Console.WriteLine($"\t{p.Value.Serialize()} ({p.Key})");
        }
    }
    else
    {
        Console.Error.WriteLine("Not implemented");
    }
}

string prompt(string str)
{
    Console.Write(str);
    string line = Console.ReadLine();
    return (line);
}
