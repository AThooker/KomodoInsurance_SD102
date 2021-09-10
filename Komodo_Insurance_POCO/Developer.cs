using System;

namespace Komodo_Insurance_POCO
{
    public class Developer
    {
        //ID
        public int ID { get; set; }
        //Name
        public string Name { get; set; }
        //PluralSight
        public bool PluralSight { get; set; }
        
        //Empty constructor
        public Developer() { }
        //Full paramters with constructor
        public Developer(int id, string name, bool pluralSight)
        {
            ID = id;
            Name = name;
            PluralSight = pluralSight;
        }
    }

}
