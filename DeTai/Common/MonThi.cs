using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class MonThi
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public MonThi()
        {

        }

        public MonThi(string iD, string full)
        {
            ID = iD;
            Name = full;
        }
    }
}
