using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komodo_Insurance_Classes
{
    public class DevTeam
    {
        //ID
        static int nextId;
        public int ID { get; private set; }
        //Name
        public string Name { get; set; }
        //Developers
        public List<Developer> Developers { get; set; }
        public DevTeam() 
        {
            ID = Interlocked.Increment(ref nextId);
        }
        public DevTeam(string name, List<Developer> developers)
        {
            ID = Interlocked.Increment(ref nextId);
            Name = name;
            Developers = developers;
        }
    }
}
