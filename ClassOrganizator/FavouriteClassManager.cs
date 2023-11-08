using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class FavouriteClassManager
    {
        private PersonManager _personManager;
        private ClassManager _classManager;

        private IDictionary<int, int> _favourites = new Dictionary<int, int>();

        public FavouriteClassManager(PersonManager personManager, ClassManager classManager)
        {
            _personManager = personManager;
            _classManager = classManager;
        }

        public void Set(int personId, int classId)
        {
            if (!_personManager.Exists(personId))
            {
                throw new ArgumentException($"Not found: person with id '{personId}'");
            }
            if (!_classManager.Exists(classId))
            {
                throw new ArgumentException($"Not found: class with id '{classId}'");
            }
            _favourites[personId] = classId;
        }

        public void UnSet(int personId)
        {
            if (!_personManager.Exists(personId))
            {
                throw new ArgumentException($"Not found: person with id '{personId}'");
            }
            _favourites.Remove(personId);
        }

        public void ShowOne(int personId)
        {
            var student = _personManager.Get(personId);
            Class? favouriteClass = null;
            if (_favourites.ContainsKey(personId))
            {
                favouriteClass = _classManager.Get(_favourites[personId]);
            }
            Console.WriteLine($"{student.Serialize()}: {(favouriteClass != null ? favouriteClass.Name : "[No favourite class]")}");
        }

        public void ShowAll()
        {
            foreach (var entry in _favourites)
            {
                var student = _personManager.Get(entry.Key);
                Console.WriteLine($"{student.Serialize()} -  Favourite class: {_classManager.Get(entry.Value).Name}");
            }
        }
    }
}
