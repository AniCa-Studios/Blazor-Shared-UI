using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Singletons
{
    public class Names
    {
        public List<string> Countries { get; set; } = new List<string>() { "Canada", "Philippines" };
        public List<string> Companies { get; set; } = new List<string>() { "Microsoft", "Apple" };
        public string Name { get; set; } = "";
    }
}
