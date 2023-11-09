using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOrganizator
{
    internal class StorageManager
    {
        public StorageManager(string filePath)
        {

        }

        public PersonManager PersonManager { get; private set; } = new PersonManager();
        public ClassManager ClassManager { get; private set; } = new ClassManager();

        public FavouriteClassManager FavouriteClassManager { get; private set; } = new FavouriteClassManager();

        public void StorageManager.Save()
        {
            
        }
    }
}
