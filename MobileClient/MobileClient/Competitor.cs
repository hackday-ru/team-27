using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient
{
    public class Competitor
    {

        public Competitor(string[] tokens)
        {
            Number = tokens[0].Replace("#","");
            Name = tokens[1];
            Group = tokens[2];
        }

        public string Number { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return Number + " " + Name + " " + Group + " - " + Time.ToString("HH:mm:ss");
        }
    }
}
