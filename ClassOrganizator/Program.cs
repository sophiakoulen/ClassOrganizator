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

var personManager = new PersonManager();
var classManager = new ClassManager(personManager);

while (true)
{
    try
    {

        var action = prompt("ctor> ");
        if (action == "CREATE class")
        {
            var name = prompt("Name: ");
            var teacherId = prompt("Teacher id: ");

            var teacherIdInt = int.Parse(teacherId);

            if (!personManager.Exists(teacherIdInt))
            {
                Console.Error.WriteLine($"Not found: no person with id '{teacherIdInt}' exists");
                continue;
            }

            var @class = new Class(teacherIdInt, name);
            classManager.Add(@class);
        }
        else if (action == "DELETE class")
        {
            var id = prompt("Class id: ");
            classManager.Remove(int.Parse(id));
        }
        else if (action == "CREATE person")
        {

            var firstname = prompt("First name: ");
            var lastname = prompt("Last name: ");

            var person = new Person(firstname, lastname);
            personManager.Add(person);
        }
        else if (action == "DELETE person")
        {
            var id = prompt("id: ");
            classManager.RemovePerson(int.Parse(id));
        }
        else if (action == "SHOW person")
        {
            personManager.ShowAll();
        }
        else if (action == "SHOW class")
        {
            classManager.ShowAll();
        }
        else if (action == "ADD")
        {
            var studentId = prompt("Student id: ");
            var classId = prompt("Class id: ");

            var studentIdInt = int.Parse(studentId);
            var classIdInt = int.Parse(classId);

            var @class = classManager.Get(classIdInt);
            @class.addStudent(studentIdInt);
        }
        else if (action == "REMOVE")
        {
            var studentId = prompt("Student id: ");
            var classId = prompt("Class id: ");

            var studentIdInt = int.Parse(studentId);
            var classIdInt = int.Parse(classId);

            if (!personManager.Exists(studentIdInt))
            {
                Console.Error.WriteLine($"Not found: no person with id '{studentIdInt}' exists");
                continue;
            }

            var @class = classManager.Get(classIdInt);
            @class.removeStudent(studentIdInt);
        }
        else if (action == "SHOW ONE class")
        {
            var classId = prompt("Class id: ");
            classManager.ShowOne(int.Parse(classId));
        }
        else if (action == "SHOW ONE person")
        {
            var personId = prompt("Person id: ");
            classManager.ShowOnePersonsClasses(int.Parse(personId));
        }
        else
        {
            throw new NotImplementedException();
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine(ex.Message);
    }
}

string prompt(string str)
{
    Console.Write(str);
    var line = Console.ReadLine();
    if (line == null)
    {
        Environment.Exit(0);
    }
    return line;
}
