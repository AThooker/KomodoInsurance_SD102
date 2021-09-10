using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_POCO
{
    //Full CRUD for Developers
    public class Developer_Repo
    {
        List<Developer> _developers = new List<Developer>();
        private Developer _developer;
        //CREATE
        public bool CreateDeveloper(Developer developer)
        {
            int initialCount = _developers.Count;
            _developers.Add(developer);
            int newCount = _developers.Count;
            return initialCount < newCount;
        }

        //READ
        public List<Developer> GetDevelopers()
        {
            return _developers;
        }

        //UPDATE
        public Developer UpdateDeveloper(Developer developer)
        {
            _developer.ID = developer.ID;
            _developer.Name = developer.Name;
            _developer.PluralSight = developer.PluralSight;

            return _developer;
        }

        //DELETE
        public bool DeleteDeveloper(int id)
        {
            int initCount = _developers.Count;
            _developers.Remove(GetByID(id));
            int newCount = _developers.Count;
            return initCount > newCount;
        }
        //HELPER
        public Developer GetByID(int id)
        {
            foreach(var developer in _developers)
            {
                if(id == developer.ID)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
