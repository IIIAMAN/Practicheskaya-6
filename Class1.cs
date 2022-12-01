using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRAKTICHESKAYA_6
{
    public class Human
    {
        public string Name;
        public string Ves;
        public string Rost;

        public Human() { }
        public Human(string name, string ves, string rost)
        {
            Name = name;
            Ves = ves;
            Rost = rost;
        }
    }
}
