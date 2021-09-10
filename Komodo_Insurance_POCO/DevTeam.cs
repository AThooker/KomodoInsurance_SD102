using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance_POCO
{
    public class DevTeam
    {
        //ID
        public int ID { get; set; }
        //Name
        public string Name { get; set; }
        //Developers
        public List<Developer> Developers { get; set; }
        public DevTeam() { }
        public DevTeam(int id, string name, List<Developer> developers)
        {
            ID = id;
            Name = name;
            Developers = developers;
        }
    }
}
