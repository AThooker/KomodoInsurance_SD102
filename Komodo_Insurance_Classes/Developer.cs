using System;
using System.Threading;

namespace Komodo_Insurance_Classes
{
    public class Developer
    {
        //ID
        static int nextId;
        public int ID { get; private set; }
        public Developer()
        {
            ID = Interlocked.Increment(ref nextId);
        }
        //Name
        public string Name { get; set; }
        //PluralSight
        public bool PluralSight { get; set; }
        
        //Full paramters with constructor
        public Developer(int id, string name, bool pluralSight)
        {
            ID = Interlocked.Increment(ref nextId);
            Name = name;
            PluralSight = pluralSight;
        }
    }

}
